using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Firjan.Integracao.Dynamics.Domain.Models.Utility
{
    public abstract partial class Enums<T>
    {
        private static readonly Dictionary<Type, IEnumerable<Enums<T>>> _allValuesCache = new Dictionary<Type, IEnumerable<Enums<T>>>();
        public T Id { get; set; }
        public string Name { get; set; }

        protected Enums(T key, string name)
        {
            Id = key;
            Name = name;
        }

        public bool IsEqualTo(Enums<T> compareTo)
        {
            return (Name == compareTo.Name || Id.Equals(compareTo.Id));
        }

        public static Enums<T> Parse<TEnumeration>(T toParse) where TEnumeration : Enums<T>
        {
            foreach (Enums<T> s in GetValues<TEnumeration>())
            {
                if (toParse.Equals(s.Id))
                    return s;
            }
            return null;
        }

        public static IEnumerable<TEnumeration> GetValues<TEnumeration>()
            where TEnumeration : Enums<T>
        {
            var enumerationType = typeof(TEnumeration);
            if (_allValuesCache.TryGetValue(enumerationType, out var value))
            {
                return value.Cast<TEnumeration>();
            }
            return AddValueToCache(enumerationType, enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic)
                .Select(p => p.GetValue(enumerationType)).Cast<TEnumeration>());
        }

        private static IEnumerable<TEnumeration> AddValueToCache<TEnumeration>(Type key, IEnumerable<TEnumeration> value) where TEnumeration : Enums<T>
        {
            _allValuesCache.Add(key, value);
            return value;
        }
    }

    public abstract partial class Enumeration : IConvertible, IComparable, IFormattable
    {
        public string Name { get; set; }
        public char? Key { get; set; }

        protected Enumeration(char? key, string displayName)
        {
            Key = key;
            Name = displayName;
        }

        #region Equality members

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }
            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Key.Equals(otherValue.Key);
            return typeMatches && valueMatches;
        }

        protected bool Equals(Enumeration other)
        {
            return string.Equals(Name, other.Name) && Key == other.Key;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Key.GetHashCode();
            }
        }

        #endregion

        #region Implementation of IComparable

        public int CompareTo(object other)
        {
            return Key.GetValueOrDefault().CompareTo(((Enumeration)other).Key);
        }

        #endregion

        #region ToString methods

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }
            if (string.Compare(format, "G", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Name;
            }
            if (string.Compare(format, "D", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Key.ToString();
            }
            if (string.Compare(format, "X", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return string.Format("X8", Key);
            }

            throw new FormatException("Invalid format");
        }

        public override string ToString()
        {
            return ToString("G");
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(format);
        }

        #endregion

        #region Implementation of IConvertible

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(Key, provider);
        }
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(Key, provider);
        }
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(Key, provider);
        }
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(Key, provider);
        }
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(Key, provider);
        }
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(Key, provider);
        }
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(Key, provider);
        }
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(Key, provider);
        }
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(Key, provider);
        }
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(Key, provider);
        }
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(Key, provider);
        }
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(Key, provider);
        }
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(Key, provider);
        }
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("Invalid cast.");
        }
        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString();
        }
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(this, conversionType, provider);
        }
        #endregion


    }

    public abstract partial class Enumeration
    {
        private static readonly Dictionary<Type, IEnumerable<Enumeration>> _allValuesCache =
            new Dictionary<Type, IEnumerable<Enumeration>>();

        #region Parse overloads

        public static TEnumeration Parse<TEnumeration>(string name) where TEnumeration : Enumeration
        {
            return Parse<TEnumeration>(name, false);
        }

        public static TEnumeration Parse<TEnumeration>(string name, bool ignoreCase) where TEnumeration : Enumeration
        {
            return ParseImpl<TEnumeration>(name, ignoreCase, true);
        }

        private static TEnumeration ParseImpl<TEnumeration>(string name, bool ignoreCase, bool throwEx) where TEnumeration : Enumeration
        {
            var value = GetValues<TEnumeration>().FirstOrDefault(entry => StringComparisonPredicate(entry.Name, name, ignoreCase));
            if (value == null && throwEx)
            {
                throw new InvalidOperationException($"Requested value {name} was not found.");
            }
            return value;
        }

        #endregion

        #region TryParse overloads

        public static bool TryParse<TEnumeration>(string name, out TEnumeration value)
            where TEnumeration : Enumeration
        {
            return TryParse(name, false, out value);
        }

        public static bool TryParse<TEnumeration>(string name, bool ignoreCase, out TEnumeration value)
            where TEnumeration : Enumeration
        {
            value = ParseImpl<TEnumeration>(name, ignoreCase, false);
            return value != null;
        }

        #endregion

        #region Format overloads

        public static string Format<TEnumeration>(TEnumeration value, string format)
            where TEnumeration : Enumeration
        {
            return value.ToString(format);
        }

        #endregion

        #region GetNames

        public static IEnumerable<string> GetNames<TEnumeration>()
            where TEnumeration : Enumeration
        {
            return GetValues<TEnumeration>().Select(e => e.Name);
        }

        #endregion

        #region GetValues

        public static TEnumeration FromKey<TEnumeration>(char? key) where TEnumeration : Enumeration
        {
            return GetValues<TEnumeration>().Where(e => e.Key == key).FirstOrDefault();
        }

        public static IEnumerable<TEnumeration> GetValues<TEnumeration>()
            where TEnumeration : Enumeration
        {
            var enumerationType = typeof(TEnumeration);
            if (_allValuesCache.TryGetValue(enumerationType, out var value))
            {
                return value.Cast<TEnumeration>();
            }
            return AddValueToCache(enumerationType, enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic)
                .Select(p => p.GetValue(enumerationType)).Cast<TEnumeration>());
        }

        private static IEnumerable<TEnumeration> AddValueToCache<TEnumeration>(Type key, IEnumerable<TEnumeration> value) where TEnumeration : Enumeration
        {
            _allValuesCache.Add(key, value);
            return value;
        }

        #endregion

        #region IsDefined overloads

        public static bool IsDefined<TEnumeration>(string name)
            where TEnumeration : Enumeration
        {
            return IsDefined<TEnumeration>(name, false);
        }

        public static bool IsDefined<TEnumeration>(string name, bool ignoreCase)
            where TEnumeration : Enumeration
        {
            return GetValues<TEnumeration>().Any(e => StringComparisonPredicate(e.Name, name, ignoreCase));
        }

        #endregion

        #region Helpers

        private static bool StringComparisonPredicate(string item1, string item2, bool ignoreCase)
        {
            var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return string.Compare(item1, item2, comparison) == 0;
        }

        #endregion
    }

    public static class Enumerations
    {
        public static IEnumerable<T> Apply<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var e in source)
            {
                action(e);
                yield return e;
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source,Action<T> action)
        {
            foreach (T element in source)
                action(element);

            return source;
        }
    }

    public static class EnumerableExtensions
    {

        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await funcBody(partition.Current); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }

        public static Task ForEachAsync<TSource>(
            this IEnumerable<TSource> items,
            Func<TSource, Task> action,
            int maxDegreesOfParallelism)
        {
            var actionBlock = new ActionBlock<TSource>(action, new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxDegreesOfParallelism
            });

            foreach (var item in items)
            {
                actionBlock.Post(item);
            }

            actionBlock.Complete();

            return actionBlock.Completion;
        }

        public static Task ForEachAsyncs<T>(
            this IEnumerable<T> source,
            Func<T, Task> operation,
            int maxDegreeOfParallelism
            )
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            EnsureValidMaxDegreeOfParallelism(maxDegreeOfParallelism);

            var tasks = from partition in Partitioner.Create(source).GetPartitions(maxDegreeOfParallelism)
                        select Task.Run(async () =>
                        {
                            using (partition)
                            {
                                while (partition.MoveNext())
                                {
                                    await operation(partition.Current).ConfigureAwait(false);
                                }
                            }
                        });
            return Task.WhenAll(tasks);
        }

        public static async Task<IEnumerable<TResult>> ForEachAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            int maxDegreeOfParallelism,
            Func<TSource, Task<TResult>> operation)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            EnsureValidMaxDegreeOfParallelism(maxDegreeOfParallelism);

            var resultsByPositionInSource = new ConcurrentDictionary<long, TResult>();

            var tasks = from partition in Partitioner.Create(source).GetOrderablePartitions(maxDegreeOfParallelism)
                        select Task.Run(async () =>
                        {
                            using (partition)
                            {
                                while (partition.MoveNext())
                                {
                                    var positionInSource = partition.Current.Key;
                                    var item = partition.Current.Value;

                                    var result = await operation(item).ConfigureAwait(false);

                                    resultsByPositionInSource.TryAdd(positionInSource, result);
                                }
                            }
                        });
            await Task.WhenAll(tasks).ConfigureAwait(false);

            return Enumerable.Range(0, resultsByPositionInSource.Count)
                .Select(position => resultsByPositionInSource[position]);
        }

        private static void EnsureValidMaxDegreeOfParallelism(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxDegreeOfParallelism),
                    $"Invalid value for the maximum degree of parallelism: {maxDegreeOfParallelism}. The maximum degree of parallelism must be a positive integer.");
            }
        }
    }
          
    /// <summary>
	/// An object which implements this interface is considered a node in a tree.
	/// </summary>
	public interface ITreeNode<T>
        where T : class
    {

        /// <summary>
        /// A unique identifier for the node.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// The parent of this node, or null if it is the root of the tree.
        /// </summary>
        T Parent
        {
            get;
            set;
        }

        /// <summary>
        /// The children of this node, or an empty list if this is a leaf.
        /// </summary>
        IList<T> Children
        {
            get;
            set;
        }

    }

    /// <summary>
    /// A helper class for objects which implement <see cref="ITreeNode{T}"/>, providing
    /// methods to convert flat lists to and from hierarchical trees, iterators, and
    /// other utility methods.
    /// </summary>
    public static class TreeHelper
    {

        #region Tree structure methods

        /// <summary>
        /// Converts an array of ITreeNode objects into a forest of trees.  The returned list will
        /// contain only the root nodes, with each root having a populated <see cref="ITreeNode{T}.Children">Children</see>
        /// property.
        /// </summary>
        /// <param name="flatNodeList">
        /// An array of list of node objects, where the <see cref="ITreeNode{T}.Parent">Parent</see> 
        /// property of each node is either null for root nodes, or an instantiated object with its
        /// <see cref="ITreeNode{T}.Id">Id</see> property set.
        /// </param>
        public static IList<T> ConvertToForest<T>(this IEnumerable<T> flatNodeList)
            where T : class, ITreeNode<T>
        {

            // first, put every TreeNode into a dictionary so that we can easily find tree nodes later.
            Dictionary<int, T> dictionary = new Dictionary<int, T>();
            foreach (T node in flatNodeList)
            {
                dictionary.Add(node.Id, node);
                // while we're looping, it's a good time to create the Children list
                node.Children = new List<T>();
            }


            // Now, go through each TreeNode. If Parent is null, then it is a root node of a tree,
            // so add it to the 'rootNodes' List, which is what will be returned from this method.
            // If Parent is not null, then find the parent from the dictionary, and set that to be it's Parent.
            List<T> rootNodes = new List<T>();

            foreach (T node in flatNodeList)
            {

                if (node.Parent == null)
                { // this is a root node; add it to the rootNodes list.
                    rootNodes.Add(node);
                }
                else
                { // this is not a root node; add it as a child of its parent.


                    if (!dictionary.ContainsKey(node.Parent.Id))
                    {
                        // In this case, this node's parent is not in the flatNodeList.
                        // By continuing, we are just ignoring this node (it won't be
                        // returned in the tree).  Another option would be to throw an
                        // exception here.
                        continue;
                    }

                    // make the parent reference for this node a reference to a fully populated parent.
                    node.Parent = dictionary[node.Parent.Id];

                    // add this node to the child list of its parent.
                    node.Parent.Children.Add(node);

                }
            }


            return rootNodes;
        }



        /// <summary>
        /// Converts a heirachacle Array of Tree Nodes into a flat array of nodes. The order
        /// of the returned nodes is the same as a depth-first traversal of each tree.
        /// </summary>
        /// <remarks>The relationships between Parent/Children are retained.</remarks>
        public static List<T> ConvertToFlatArray<T>(this IEnumerable<T> trees)
            where T : class, ITreeNode<T>
        {
            List<T> treeNodeList = new List<T>();
            foreach (T rootNode in trees)
            {
                foreach (T node in DepthFirstTraversal(rootNode))
                {
                    treeNodeList.Add(node);
                }
            }
            return treeNodeList;
        }

        #endregion




        #region Search methods

        /// <summary>Finds the TreeNode with the given Id in the given tree by searching the descendents.
        /// Returns null if the node cannot be found.</summary>
        public static T FindDescendant<T>(this T searchRoot, int id)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(searchRoot, "searchRoot");

            foreach (T child in DepthFirstTraversal(searchRoot))
            {
                if (child.Id == id)
                {
                    return child;
                }
            }
            return null;
        }

        /// <summary>Finds the TreeNode with the given id from the given forest of trees.
        /// Returns null if the node cannot be found.</summary>
        public static T FindTreeNode<T>(this IEnumerable<T> trees, int id)
            where T : class, ITreeNode<T>
        {

            foreach (T rootNode in trees)
            {
                if (rootNode.Id == id)
                {
                    return rootNode;
                }
                T descendant = FindDescendant(rootNode, id);
                if (descendant != null)
                {
                    return descendant;
                }
            }

            return null;
        }

        #endregion


        #region Useful tree properties


        /// <summary>
        /// Checks whether there is a loop from the current node up the tree back to the current node.
        /// It is recommended that this is checked to be false before saving the node to your data store.
        /// </summary>
        /// <example>
        /// The most simple example of a hierarchy loop is were there are 2 nodes, "A" and "B", and "A" 
        /// is "B"'s parent, and "B" is "A"'s parent. This is not allowed, and should not be saved. , 
        /// </example>
        public static bool HasHeirachyLoop<T>(this T node)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            T tempParent = node.Parent;
            while (tempParent != null)
            {
                if (tempParent.Id == node.Id)
                {
                    return true;
                }
                tempParent = tempParent.Parent;
            }
            return false;

        }


        /// <summary>Returns the root node of the tree that the given TreeNode belongs in</summary>
        public static T GetRootNode<T>(this T node)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            T cur = node;
            while (cur.Parent != null)
            {
                cur = cur.Parent;
            }
            return cur;
        }


        /// <summary>
        /// Gets the depth of a node, e.g. a root node has depth 0, its children have depth 1, etc.
        /// </summary>
        public static int GetDepth<T>(this T node)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            int depth = 0;
            while (node.Parent != null)
            {
                ++depth;
                node = node.Parent;
            }
            return depth;
        }



        /// <summary>
        /// Gets the type of node that the specified node is.
        /// </summary>
        public static NodeType GetNodeType<T>(this T node)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            if (node.Parent == null)
            {
                return NodeType.Root;
            }
            else if (node.Children.Count == 0)
            {
                return NodeType.Leaf;
            }
            return NodeType.Internal;
        }

        #endregion


        #region Iterators


        /// <summary>
        /// Returns an Iterator which starts at the given node, and climbs up the tree to
        /// the root node.
        /// </summary>
        /// <param name="startNode">The node to start iterating from.  This will be the first node returned by the iterator.</param>
        public static IEnumerable<T> ClimbToRoot<T>(this T startNode)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(startNode, "startNode");

            T current = startNode;
            while (current != null)
            {
                yield return current;
                current = current.Parent;
            }
        }

        /// <summary>
        /// Returns an Iterator which starts at the root node, and goes down the tree to
        /// the given node node.
        /// </summary>
        /// <param name="startNode">The node to start iterating from.  This will be the first node returned by the iterator.</param>
        public static List<T> FromRootToNode<T>(this T node)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            List<T> nodeToRootList = new List<T>();
            foreach (T n in ClimbToRoot(node))
            {
                nodeToRootList.Add(n);
            }
            nodeToRootList.Reverse();
            return nodeToRootList;
        }


        /// <summary>
        /// Returns an Iterator which starts at the given node, and traverses the tree in
        /// a depth-first search manner.
        /// </summary>
        /// <param name="startNode">The node to start iterating from.  This will be the first node returned by the iterator.</param>
        public static IEnumerable<T> DepthFirstTraversal<T>(this T startNode)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(startNode, "node");

            yield return startNode;
            foreach (T child in startNode.Children)
            {
                foreach (T grandChild in DepthFirstTraversal(child))
                {
                    yield return grandChild;
                }
            }
        }

        /// <summary>
        /// Returns an Iterator which traverses a forest of trees in a depth-first manner.
        /// </summary>
        /// <param name="trees">The forest of trees to traverse.</param>
        public static IEnumerable<T> DepthFirstTraversalOfList<T>(this IEnumerable<T> trees)
            where T : class, ITreeNode<T>
        {
            foreach (T rootNode in trees)
            {
                foreach (T node in DepthFirstTraversal(rootNode))
                {
                    yield return node;
                }
            }
        }


        /// <summary>
        /// Gets the siblings of the given node. Note that the given node is included in the
        /// returned list.  Throws an <see cref="Exception" /> if this is a root node.
        /// </summary>
        /// <param name="node">The node whose siblings are to be returned.</param>
        /// <param name="includeGivenNode">If false, then the supplied node will not be returned in the sibling list.</param>
        public static IEnumerable<T> Siblings<T>(this T node, bool includeGivenNode)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            if (GetNodeType(node) == NodeType.Root)
            {
                if (includeGivenNode)
                {
                    yield return node;
                }
                yield break;
            }

            foreach (T sibling in node.Parent.Children)
            {
                if (!includeGivenNode && sibling.Id == node.Id)
                { // current node is supplied node; don't return it unless it was asked for.
                    continue;
                }
                yield return sibling;
            }

        }


        /// <summary>
        /// Traverses the tree in a breadth-first fashion.
        /// </summary>
        /// <param name="node">The node to start at.</param>
        /// <param name="returnRootNode">If true, the given node will be returned; if false, traversal starts at the node's children.</param>
        public static IEnumerable<T> BreadthFirstTraversal<T>(this T node, bool returnRootNode)
            where T : class, ITreeNode<T>
        {
            EnsureTreePopulated(node, "node");

            if (returnRootNode)
            {
                yield return node;
            }

            foreach (T child in node.Children)
            {
                yield return child;
            }


            foreach (T child in node.Children)
            {
                foreach (T grandChild in BreadthFirstTraversal(child, false))
                {
                    yield return grandChild;
                }
            }

        }

        #endregion


        #region Private methods

        [System.Diagnostics.Conditional("DEBUG")]
        private static void EnsureTreePopulated<T>(T node, string parameterName)
            where T : class, ITreeNode<T>
        {
            if (node == null)
            {
                throw new ArgumentNullException(parameterName, "The given node cannot be null.");
            }
            if (node.Children == null)
            {
                throw new ArgumentException("The children of " + parameterName + " is null. Have you populated the tree fully by calling TreeHelper<T>.ConvertToForest(IEnumerable<T> flatNodeList)?", parameterName);
            }
        }

        #endregion


    }

    /// <summary>
    /// A type of tree node.
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// A node which is at the root of the tree, i.e. it has no parents.
        /// </summary>
        Root,

        /// <summary>
        /// A node which has parent and children.
        /// </summary>
        Internal,

        /// <summary>
        /// A node with no children.
        /// </summary>
        Leaf
    }
}
