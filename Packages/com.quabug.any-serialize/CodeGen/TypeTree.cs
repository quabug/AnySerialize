using System;
using System.Buffers;
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
        }

        private class TypeTreeNode
        {
            [NotNull] public TypeDef TypeDef { get; }
            [CanBeNull] public TypeDef BaseDef { get; }
            [NotNull, ItemNotNull] public IReadOnlyList<TypeDef> Interfaces { get; }
            
            public List<TypeTreeNode> ChildrenNodes { get; } = new List<TypeTreeNode>();

            public TypeTreeNode(TypeDefinition type)
            {
                TypeDef = type;
                BaseDef = type.BaseType == null ? null : new TypeDef(type.BaseType);
                Interfaces = type.Interfaces.Select(i => new TypeDef(i)).ToArray();
            }

            public override string ToString()
            {
                return $"{TypeDef.Type.Name}({TypeDef.Type.Module.Name})";
            }
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
        // /// Create a typeDef-tree from a collection of <paramref name="sourceTypes"/>
        // /// </summary>
        // /// <param name="sourceTypes">The source types of tree.</param>
        // /// <param name="baseTypes">Excluded any types from <paramref name="sourceTypes"/> which is not derived from base typeDef.</param>
        // public TypeTree([NotNull] ICollection<TypeDefinition> sourceTypes, [NotNull] ICollection<TypeDefinition> baseTypes)
        // {
        // }

        /// <summary>
        /// Get all derived class type of <paramref name="baseType"/>.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any type of classes derived from <paramref name="baseType"/> directly or indirectly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<TypeDef> GetAllDerivedDefinition(TypeDef baseType)
        {
            _typeTreeNodeMap.TryGetValue(baseType.Type, out var node);
            if (node == null) throw new ArgumentException($"{baseType.Type} is not part of this tree");
            return GetDescendantsAndSelf(node, baseType.GenericArguments).Select(n => n.TypeDef);
        }
        
        public TypeDef FindMostMatchType(TypeDef baseTypeDef)
        {
            throw new NotImplementedException();
            // _typeTreeNodeMap.TryGetValue(baseTypeDef.Type, out var self);
            // if (self == null) throw new ArgumentException($"{baseTypeDef.Type} is not part of this tree");
            //
            // var matchType = baseTypeDef;
            // Find(self, baseTypeDef);
            //
            // void Find(TypeTreeNode node, TypeDef parent)
            // {
            //     var generic = node.TypeDef.ResolveGenericArguments(parent);
            //     if (!node.TypeDef.IsAbstract && node.TypeDef.IsClass && generic.GenericTypes[0].Is)
            //     {
            //     }
            //     
            //     foreach (var childNode in node.Subs) Find(childNode, generic);
            // }
        }
        
        IEnumerable<TypeTreeNode> GetDescendantsAndSelf(TypeTreeNode self, IReadOnlyList<TypeReference> baseGenericTypes)
        {
            // var implementations = self.Type.GetImplementationsOf(new TypeDef(self.Type, baseGenericTypes));
            // if (!implementations.Any()) yield break;
            // yield return self;
            //
            // var implementation = implementations.First();
            // var selfGenericTypes = new TypeReference[self.Type.GenericParameters.Count];
            //
            // self.Type.GenericParameters.Select(p => p.Name)
            //
            foreach (var childNode in
                from sub in self.ChildrenNodes
                from type in GetDescendantsAndSelf(sub)
                select type
            ) yield return childNode;
        }
        
        IEnumerable<TypeTreeNode> GetDescendantsAndSelf(TypeTreeNode self)
        {
            foreach (var childNode in
                from sub in self.ChildrenNodes
                from type in GetDescendantsAndSelf(sub)
                select type
            ) yield return childNode;
        }

        /// <summary>
        /// Get directly derived class type of <paramref name="baseType"/>.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any type of classes derived from <paramref name="baseType"/> directly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<TypeDef> GetDirectDerivedDefinition(TypeDef baseType)
        {
            _typeTreeNodeMap.TryGetValue(new TypeKey(baseType.Type), out var node);
            if (node == null) throw new ArgumentException($"{baseType.Type} is not part of this tree");
            return node.ChildrenNodes.Select(child => child.TypeDef).Where(type => type.IsImplementationOf(baseType));
        }
        
        /// <summary>
        /// Get all derived class type of <paramref name="rootType"/>.
        /// Will make new TypeReference if derived type is generic.
        /// </summary>
        /// <param name="rootType"></param>
        /// <param name="publicOnly">including public only classes or also including private ones.</param>
        /// <returns>Any typeDef of classes derived from <paramref name="rootType"/> directly or indirectly.</returns>
        public IEnumerable<TypeDef> GetOrCreateAllDerivedReference(TypeDef rootType, bool publicOnly = true)
        {
            return GetDirectDerivedDefinition(rootType).SelectMany(type => RecursiveProcess(type, rootType));
        
            IEnumerable<TypeDef> RecursiveProcess(TypeDef type, TypeDef baseType)
            {
                if (publicOnly && !type.Type.IsPublicOrNestedPublic()) return Enumerable.Empty<TypeDef>();
                var baseCtor = type.Type.GetConstructors().FirstOrDefault(ctor => !ctor.HasParameters);
                if (baseCtor == null) return Enumerable.Empty<TypeDef>();

                // TODO: handle multiple derived from same base type
                var implementation = type.GetImplementationsOf(baseType).FirstOrDefault();
                if (implementation == null) return Enumerable.Empty<TypeDef>();
                var genericArguments = ArrayPool<TypeReference>.Shared.Rent(type.GenericArguments.Count);
                for (var i = 0; i < type.GenericArguments.Count; i++)
                {
                    var arg = type.GenericArguments[i];
                    if (arg.IsGenericParameter)
                    {
                        var index = implementation.GenericArguments.FindIndex(t => t.IsGenericParameter && t.Name == arg.Name);
                        var isGenericType = index < 0 || baseType.GenericArguments[index].IsGenericParameter;
                        genericArguments[i] = isGenericType ? arg : baseType.GenericArguments[index];
                    }
                    else if (arg.IsGenericInstance)
                    {
                        genericArguments[i] = arg;
                    }
                }
                baseType = new TypeDef(type.Type, genericArguments.Take(type.GenericArguments.Count));
                ArrayPool<TypeReference>.Shared.Return(genericArguments);

                return baseType.Yield().Concat(
                    GetDirectDerivedDefinition(type).SelectMany(t => RecursiveProcess(t.Type, baseType))
                );
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var pair in _typeTreeNodeMap)
            {
                if (pair.Value.BaseDef == null)
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
            if (_typeTreeNodeMap.TryGetValue(new TypeKey(type), out var node)) return node;

            var self = new TypeTreeNode(type);
            foreach (var @base in type.Interfaces.Select(i => i.InterfaceType).Append(type.BaseType).Where(@base => @base != null))
            {
                // HACK: some interface cannot be resolved? has been stripped by Unity?
                //       e.g. the interface `IEditModeTestYieldInstruction` of `ExitPlayMode`
                //            will resolve to null
                var definition = @base.Resolve();
                if (definition == null)
                    _logger.Warning($"Invalid type definition {@base}({@base.Module}) on {type}");
                
                var parentNode = CreateTypeTree(definition);
                parentNode.ChildrenNodes.Add(self);
            }

            try
            {
                _typeTreeNodeMap.Add(new TypeKey(type), self);
            }
            catch
            {
                var duplicate = _typeTreeNodeMap[new TypeKey(type)];
                _logger.Error($"Duplicate type? {type} {duplicate.TypeDef.Type}");
            }
            return self;
        }
    }
}