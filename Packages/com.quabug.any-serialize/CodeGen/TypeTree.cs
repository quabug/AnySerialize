using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using UnityEngine.Assertions;

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
            public ISet<TypeDefinition> Interfaces { get; } = new HashSet<TypeDefinition>(new TypeDefinitionTokenComparer());
            public TypeDefinition Type { get; }
            public TypeTreeNode Base { get; set; }
            public List<TypeTreeNode> Subs { get; } = new List<TypeTreeNode>();

            public TypeTreeNode(TypeDefinition type) => Type = type;

            public override string ToString()
            {
                return $"{Type.Name}({Type.Module.Name})";
            }
        }

        private readonly Dictionary<TypeKey, TypeTreeNode> _typeTreeNodeMap;

        private readonly ILPostProcessorLogger _logger;

        /// <summary>
        /// Create a typeDef-tree from a collection of <paramref name="sourceTypes"/>
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
        /// Get all derived class typeDef of <paramref name="baseType"/>.
        /// Ignore generic typeDef argument if <paramref name="baseType"/> is a generic class with certain typeDef of arguments.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any typeDef of classes derived from <paramref name="baseType"/> directly or indirectly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<(TypeDefinition type, IReadOnlyList<int> genericIndices> GetAllDerivedDefinition(TypeDef baseType)
        {
            _typeTreeNodeMap.TryGetValue(baseType.Type, out var node);
            if (node == null) throw new ArgumentException($"{baseType} is not part of this tree");
            return GetDescendantsAndSelf(node).Select(n => n.Type);
        }
        
        public TypeDef FindMostMatchType(in TypeDef baseTypeDef)
        {
            _typeTreeNodeMap.TryGetValue(baseTypeDef.Type, out var self);
            if (self == null) throw new ArgumentException($"{baseTypeDef.Type} is not part of this tree");
            
            var matchType = baseTypeDef;
            Find(self, baseTypeDef);
            
            void Find(TypeTreeNode node, TypeDef parent)
            {
                var generic = node.TypeDef.ResolveGenericArguments(parent);
                if (!node.TypeDef.IsAbstract && node.TypeDef.IsClass && generic.GenericTypes[0].Is)
                {
                }
                
                foreach (var childNode in node.Subs) Find(childNode, generic);
            }
        }
        
        IEnumerable<TypeTreeNode> GetDescendantsAndSelf(TypeTreeNode self)
        {
            yield return self;
            foreach (var childNode in
                from sub in self.Subs
                from type in GetDescendantsAndSelf(sub)
                select type
            ) yield return childNode;
        }

        /// <summary>
        /// Get directly derived class typeDef of <paramref name="baseType"/>.
        /// Ignore generic typeDef argument if <paramref name="baseType"/> is a generic class with certain typeDef argument.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns>Any typeDef of classes derived from <paramref name="baseType"/> directly.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<TypeDefinition> GetDirectDerivedDefinition(TypeDefinition baseType)
        {
            _typeTreeNodeMap.TryGetValue(new TypeKey(baseType), out var node);
            if (node == null) throw new ArgumentException($"{baseType} is not part of this tree");
            return node.Subs.Select(sub => sub.Type);
        }
        
        public IEnumerable<TypeDefinition> GetDirectDerivedDefinition(TypeDef baseType)
        {
            _typeTreeNodeMap.TryGetValue(new TypeKey(baseType.Type), out var node);
            if (node == null) throw new ArgumentException($"{baseType.Type} is not part of this tree");
            return node.Subs.Select(sub => sub.Type);
        }

        /// <summary>
        /// Get all derived class typeDef of <paramref name="rootType"/>.
        /// Will make new TypeReference if derived typeDef is generic.
        /// </summary>
        /// <param name="rootType"></param>
        /// <param name="publicOnly">including public only classes or also including private ones.</param>
        /// <returns>Any typeDef of classes derived from <paramref name="rootType"/> directly or indirectly.</returns>
        public IEnumerable<TypeReference> GetOrCreateAllDerivedReference(TypeReference rootType, bool publicOnly = true)
        {
            return GetDirectDerivedDefinition(rootType.Resolve()).SelectMany(t => RecursiveProcess(t, rootType));

            IEnumerable<TypeReference> RecursiveProcess(TypeDefinition type, TypeReference baseType)
            {
                if (publicOnly && !type.IsPublicOrNestedPublic()) return Enumerable.Empty<TypeReference>();
                var baseCtor = type.GetConstructors().FirstOrDefault(ctor => !ctor.HasParameters);
                if (baseCtor == null) return Enumerable.Empty<TypeReference>();

                IList<TypeReference> genericArguments = Array.Empty<TypeReference>();
                try
                {
                    genericArguments = type.ResolveGenericArguments(baseType).TypeDef.GenericTypes;
                }
                catch
                {
                    // logger.Debug($"cannot resolve {typeReference.ToReadableName()} : {baseGenericType.ToReadableName()}: {ex}");
                    return Enumerable.Empty<TypeReference>();
                }

                baseType = type.HasGenericParameters
                    ? (TypeReference) type.MakeGenericInstanceType(genericArguments.ToArray())
                    : type
                ;

                return baseType.Yield().Concat(
                    GetDirectDerivedDefinition(type).SelectMany(t => RecursiveProcess(t, baseType))
                );
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var pair in _typeTreeNodeMap)
            {
                if (pair.Value.Base == null)
                {
                    var root = pair.Value;
                    ToString(root);
                }
            }
            return builder.ToString();

            void ToString(TypeTreeNode node, int indent = 0)
            {
                for (var i = 0; i < indent; i++) builder.Append("    ");
                builder.AppendLine(node.ToString());
                foreach (var child in node.Subs) ToString(child, indent + 1);
            }
        }

        TypeTreeNode CreateTypeTree(TypeDefinition type)
        {
            if (type == null) return null;
            if (_typeTreeNodeMap.TryGetValue(new TypeKey(type), out var node)) return node;

            var self = new TypeTreeNode(type);
            foreach (var @interface in type.Interfaces)
            {
                // HACK: some interface cannot be resolved? has been stripped by Unity?
                //       e.g. the interface `IEditModeTestYieldInstruction` of `ExitPlayMode`
                //            will resolve to null
                var interfaceDefinition = @interface.InterfaceType.Resolve();
                if (interfaceDefinition == null)
                    _logger.Warning($"Invalid interface definition {@interface.InterfaceType}({@interface.InterfaceType.Module}) on {type}");
                else
                    self.Interfaces.Add(interfaceDefinition);
            }

            var baseTypeDef = type.BaseType?.Resolve();
            if (baseTypeDef == null && type.BaseType != null)
                _logger.Warning($"Invalid base typeDef definition {type.BaseType}({type.BaseType.Module}) on {type.Name}");
            var parent = CreateTypeTree(baseTypeDef);
            var uniqueInterfaces = new HashSet<TypeDefinition>(self.Interfaces, new TypeDefinitionTokenComparer());
            if (parent != null)
            {
                self.Base = parent;
                parent.Subs.Add(self);
                self.Interfaces.UnionWith(parent.Interfaces);
                uniqueInterfaces.ExceptWith(parent.Interfaces);
            }

            foreach (var @interface in uniqueInterfaces)
            {
                var typeKey = new TypeKey(@interface);
                if (!_typeTreeNodeMap.TryGetValue(typeKey, out var implementations))
                {
                    implementations = new TypeTreeNode(@interface);
                    _typeTreeNodeMap.Add(typeKey, implementations);
                }
                implementations.Subs.Add(self);
            }

            try
            {
                _typeTreeNodeMap.Add(new TypeKey(type), self);
            }
            catch
            {
                var duplicate = _typeTreeNodeMap[new TypeKey(type)];
                _logger.Error($"Duplicate typeDef? {type} {duplicate.Type}");
            }
            return self;
        }
    }
}