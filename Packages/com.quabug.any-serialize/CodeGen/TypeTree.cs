using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace AnySerialize.CodeGen
{
    /// <summary>
    ///
    /// create tree structure for types
    ///
    /// "X": class
    /// "<-": inherit from
    /// "X(I)": X implement interface I
    ///
    ///   A <-+-- B(I) <---- C
    ///       |
    ///       +-- D(I) <-+-- E(I)
    ///                 |
    ///                 +-- F
    ///
    /// type tree structure: A ( B ( C ) + D ( E + F ) )
    /// interface chain: I(B, D, E)
    /// </summary>
    public class TypeTree
    {
        class TypeDefinitionTokenComparer : IEqualityComparer<TypeDefinition>
        {
            public bool Equals(TypeDefinition x, TypeDefinition y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x == null || y == null) return false;
                return new TypeKey(x).Equals(new TypeKey(y));
            }

            public int GetHashCode(TypeDefinition obj)
            {
                return new TypeKey(obj).GetHashCode();
            }
        }

        readonly struct TypeKey : IEquatable<TypeKey>
        {
            public readonly string ModuleName;
            public readonly MetadataToken Token;

            public TypeKey(TypeDefinition typeDefinition)
            {
                ModuleName = typeDefinition.Module.Name;
                Token = typeDefinition.MetadataToken;
            }

            public bool Equals(TypeKey other)
            {
                return ModuleName == other.ModuleName && Token.Equals(other.Token);
            }

            public override bool Equals(object obj)
            {
                return obj is TypeKey other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (ModuleName.GetHashCode() * 397) ^ Token.GetHashCode();
                }
            }

            public static implicit operator TypeKey(TypeDefinition typeDefinition) => new TypeKey(typeDefinition);
            public static implicit operator TypeKey(TypeReference typeReference) => new TypeKey(typeReference.Resolve());
        }

        private class TypeTreeNode
        {
            [NotNull] public TypeDefinition Type { get; }
            public List<TypeTreeNode> ChildrenNodes { get; } = new List<TypeTreeNode>();
            public TypeTreeNode(TypeDefinition type) => Type = type;
            public override string ToString() => $"{Type.Name}({Type.Module.Name})";
        }

        private readonly Dictionary<TypeKey, TypeTreeNode> _typeTreeNodeMap;

        private readonly ILPostProcessorLogger _logger;

        /// <summary>
        /// Create a type-tree from a collection of <paramref name="sourceTypes"/>
        /// </summary>
        /// <param name="sourceTypes">The source types of tree.</param>
        /// <param name="logger">logger</param>
        public TypeTree([NotNull] IEnumerable<TypeDefinition> sourceTypes, ILPostProcessorLogger logger = null)
        {
            _logger = logger ?? new ILPostProcessorLogger();
            if (logger != null) _logger = logger;
            _typeTreeNodeMap = new Dictionary<TypeKey, TypeTreeNode>();
            foreach (var type in sourceTypes.Where(t => t.IsClass || t.IsInterface)) CreateTypeTree(type);
        }

        // TODO:
        // /// <summary>
        // /// Create a type-tree from a collection of <paramref name="sourceTypes"/>
        // /// </summary>
        // /// <param name="sourceTypes">The source types of tree.</param>
        // /// <param name="baseTypes">Excluded any types from <paramref name="sourceTypes"/> which is not derived from base type.</param>
        // public TypeTree([NotNull] ICollection<TypeDefinition> sourceTypes, [NotNull] ICollection<TypeDefinition> baseTypes)
        // {
        // }

        /// <summary>
        /// Get all derived class type of <paramref name="baseType"/>.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any type of classes derived from <paramref name="baseType"/> directly or indirectly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<TypeReference> GetAllDerivedDefinition(TypeReference baseType)
        {
            _typeTreeNodeMap.TryGetValue(baseType.Resolve(), out var node);
            if (node == null) throw new ArgumentException($"{baseType} is not part of this tree");
            return GetDescendants(node, baseType);
        }
        
        IEnumerable<TypeReference> GetDescendantsAndSelf(TypeTreeNode self, TypeReference @base)
        {
            return CreateTypeWithBaseGenericArguments(self.Type, @base).SelectMany(t => t.type.Yield().Concat(GetDescendants(self, t.type)));
        }

        IEnumerable<TypeReference> GetDescendants(TypeTreeNode self, TypeReference @base)
        {
            return self.ChildrenNodes.SelectMany(child => GetDescendantsAndSelf(child, @base));
        }

        /// <summary>
        /// Get directly derived class type of <paramref name="baseType"/>.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any type of classes derived from <paramref name="baseType"/> directly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<TypeReference> GetDirectDerivedDefinition(TypeReference baseType)
        {
            _typeTreeNodeMap.TryGetValue(baseType, out var node);
            if (node == null) throw new ArgumentException($"{baseType} is not part of this tree");
            return node.ChildrenNodes.Select(child => child.Type);
        }
        
        /// <summary>
        /// Get all derived class type of <paramref name="rootType"/>.
        /// Will make new TypeReference if derived type is generic.
        /// </summary>
        /// <param name="rootType"></param>
        /// <returns>Any type of classes derived from <paramref name="rootType"/> directly or indirectly.</returns>
        public IEnumerable<(TypeReference derivedType, TypeReference implementation)> GetOrCreateAllDerivedReferences(TypeReference rootType)
        {
            return GetOrCreateDirectDerivedReferences(rootType).SelectMany(t => t.Yield().Concat(GetOrCreateAllDerivedReferences(t.derivedType)));
        }
        
        /// <summary>
        /// Get directly derived class type of <paramref name="rootType"/>.
        /// Will make new TypeReference if derived type is generic.
        /// </summary>
        /// <param name="rootType"></param>
        /// <returns>Any type of classes derived from <paramref name="rootType"/> directly.</returns>
        public IEnumerable<(TypeReference derivedType, TypeReference implementation)> GetOrCreateDirectDerivedReferences(TypeReference rootType)
        {
            return GetDirectDerivedDefinition(rootType)
                .SelectMany(type => CreateTypeWithBaseGenericArguments(type, rootType))
                .Where(t => t.type != null && t.type.IsMatchTypeConstraints())
            ;
        }

        private IEnumerable<(TypeReference type, TypeReference implementation)> CreateTypeWithBaseGenericArguments(TypeReference self, TypeReference baseType)
        {
            return self.GetImplementationsOf(baseType).Select(implementation => (CreateTypeFromImplementation(implementation), implementation));

            TypeReference CreateTypeFromImplementation(TypeReference implementation)
            {
                if (!self.IsGenericType()) return self;
                
                // TODO: array pool on MacOS not working?
                //       (0,0): error System.TypeLoadException: Could not load type 'System.Buffers.ArrayPool`1' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
                // var genericArguments = ArrayPool<TypeReference>.Shared.Rent(self.GenericParameters.Count);
                var genericArguments = new TypeReference[self.GenericParameters.Count];
                self.GetGenericParametersOrArguments(genericArguments);
                for (var i = 0; i < self.GenericParameters.Count; i++)
                {
                    var arg = genericArguments[i];
                    if (arg.IsGenericParameter)
                    {
                        var index = implementation.GetGenericParametersOrArguments().FindIndex(t =>  t.IsGenericParameter && t.Name == arg.Name);
                        var isGenericType = index < 0 || !baseType.IsGenericInstance;
                        genericArguments[i] = isGenericType ? arg : ((GenericInstanceType)baseType).GenericArguments[index];
                    }
                }

                if (genericArguments.Take(self.GenericParameters.Count).All(arg => arg.IsGenericParameter)) return self;
                
                var instance = new GenericInstanceType(self);
                foreach (var arg in genericArguments.Take(self.GenericParameters.Count)) instance.GenericArguments.Add(arg);
                return instance;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var pair in _typeTreeNodeMap)
            {
                if (pair.Value.Type.BaseType == null)
                {
                    var root = pair.Value;
                    WriteString(root);
                }
            }
            return builder.ToString();
        
            void WriteString(TypeTreeNode node, int indent = 0)
            {
                for (var i = 0; i < indent; i++) builder.Append("    ");
                builder.AppendLine(node.ToString());
                foreach (var child in node.ChildrenNodes) WriteString(child, indent + 1);
            }
        }

        TypeTreeNode CreateTypeTree(TypeDefinition type)
        {
            if (type == null) return null;
            if (_typeTreeNodeMap.TryGetValue(type, out var node)) return node;

            var self = new TypeTreeNode(type);
            foreach (var @base in type.Interfaces.Select(i => i.InterfaceType).Append(type.BaseType).Where(@base => @base != null))
            {
                // HACK: some interface cannot be resolved? has been stripped by Unity?
                //       e.g. the interface `IEditModeTestYieldInstruction` of `ExitPlayMode`
                //            will resolve to null
                var definition = @base.Resolve();
                if (definition == null)
                {
                    _logger.Warning($"Invalid type definition {@base}({@base.Module}) on {type}");
                }
                else
                {
                    var parentNode = CreateTypeTree(definition);
                    parentNode.ChildrenNodes.Add(self);
                }
            }

            try
            {
                _typeTreeNodeMap.Add(type, self);
            }
            catch
            {
                var duplicate = _typeTreeNodeMap[type];
                _logger.Error($"Duplicate type? {type} {duplicate.Type}");
            }
            return self;
        }
    }
}