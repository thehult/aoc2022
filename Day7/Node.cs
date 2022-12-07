using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Node
    {
        public Node? Parent { get; set; }
        public Dictionary<string, Node> Children { get; set; } = new Dictionary<string, Node>();

        public string Name { get; set; } = string.Empty;
        public bool IsDir { get; init; } = false;

        private int _size = 0;
        public int Size {
            get
            {
                return _size + Children.Sum(c => c.Value.Size);
            }
            init
            {
                _size = value;
            }
        }
        public string Path => Parent == null ? $"{Name}" : $"{Parent.Path}/{Name}";
        public Node Root => Parent == null ? this : Parent.Root;


        /**
         * Traversion methods
         */
        private void Find(Func<Node, bool> predicate, IList<Node> nodes)
        {
            if(predicate(this))
                nodes.Add(this);
            foreach (var c in Children)
                c.Value.Find(predicate, nodes);
        }

        public IEnumerable<Node> Find(Func<Node, bool> predicate)
        {
            var nodes = new List<Node>();
            Find(predicate, nodes);
            return nodes;
        }


        /**
         * Static methods
         */
        public static Node CreateDir(Node? parent, string name)
        {
            var newNode = new Node
            {
                Parent = parent,
                Name = name,
                IsDir = true
            };
            parent?.Children.Add(name, newNode);
            return newNode;
        }
        public static Node CreateFile(Node? parent, string name, int size)
        {
            var newNode = new Node
            {
                Parent = parent,
                Name = name,
                Size = size
            };
            parent?.Children.Add(name, newNode);
            return newNode;
        }

        public static Node CreateTreeFromInput(Input input)
        {
            Node? currentNode = Node.CreateDir(null, "/");
            foreach (var line in input)
            {
                var a = line.ReadToken();
                if (a == "$")
                {
                    var cmd = line.ReadToken();
                    if(cmd == "cd")
                    {
                        var arg = line.ReadToken();
                        if (arg == "..")
                            currentNode = currentNode?.Parent ?? currentNode;
                        else if (arg == "/")
                            currentNode = currentNode?.Root;
                        else
                            currentNode = currentNode?.Children[arg];
                    }                    
                }
                else if (a == "dir")
                {
                    var d = line.ReadToken();
                    Node.CreateDir(currentNode, d);
                }
                else
                {
                    var n = line.ReadToken();
                    Node.CreateFile(currentNode, n, int.Parse(a));
                }
            }
            return currentNode.Root;
        }
    }
}
