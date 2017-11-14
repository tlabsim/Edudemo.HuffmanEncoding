using System;
using System.Collections.Generic;

namespace EduDemo.HuffmanCoding
{
    public enum NodeType
    {
        RootWithNoChild,
        RootWithLeftChildOnly,
        RootWithRightChildOnly,
        RootWithBothChild,
        LeftLeaf,
        LeftChildWithLeftChildOnly,
        LeftChildWithRightChildOnly,
        LeftChildWithBothChild,
        RightLeaf,
        RightChildWithLeftChildOnly,
        RightChildWithRightChildOnly,
        RightChildWithBothChild,
    }

    public class HuffmanNode
    {
        public NodeType NodeType
        {
            get;
            set;
        }

        public HuffmanNodeControl NodeControl
        {
            get;
            set;
        }

        public HuffmanNodeControl2 NodeControl2
        {
            get;
            set;
        }

        public char Character
        {
            get;
            set;
        }

        public bool IsCompositeNode
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Frequency
        {
            get;
            set;
        }

        public HuffmanNode Parent
        {
            get;
            set;
        }

        public HuffmanNode LeftChild
        {
            get;
            set;
        }

        public HuffmanNode RightChild
        {
            get;
            set;
        }

        public string Encoding
        {
            get;
            set;
        }

        public HuffmanNode()
        {
            Title = string.Empty;
            Frequency = 0;
        }
    }

    public class HuffmanTree
    {
        public Dictionary<char, HuffmanNode> EncodingDictionary = new Dictionary<char, HuffmanNode>();

        public string Text
        {
            get;
            set;
        }

        public HuffmanNode Root
        {
            get;
            set;
        }

        public List<HuffmanNode> Nodes = new List<HuffmanNode>();

        public List<HuffmanNode> Leafs
        {
            get
            {
                return Nodes.FindAll(n => n.IsCompositeNode == false);
            }
        }

        public int NodeCount
        {
            get
            {
                return Nodes.Count;
            }
        }

        //public int Depth
        //{
        //    get
        //    {
        //        return (int)(Math.Log10(Nodes.Count) / Math.Log10(2)) + 1;
        //    }
        //}

        public int Depth
        {
            get
            {
                return GetChildDepth(this.Root);
            }
        }

        int GetChildDepth(HuffmanNode node)
        {
            if (node == null) return 0;
            return Math.Max(1 + GetChildDepth(node.LeftChild), 1 + GetChildDepth(node.RightChild));            
        }

        public void GetNodeEncodings()
        {
            EncodingDictionary.Clear();
            if (Nodes.Count == 1)
            {
                this.Root.Encoding = "0";
                EncodingDictionary.Add(this.Root.Character, this.Root);
            }
            else
            {
                GetEncoding(this.Root, string.Empty);
            }
        }

        void GetEncoding(HuffmanNode node, string encoding)
        {
            if (node == null) return;
            if (!node.IsCompositeNode)
            {
                node.Encoding = encoding;
                EncodingDictionary.Add(node.Character, node);
            }
            else
            {
                if (node.LeftChild != null)
                {
                    GetEncoding(node.LeftChild, encoding + "0");
                }
                if (node.RightChild != null)
                {
                    GetEncoding(node.RightChild, encoding + "1");
                }

            }
        }        
    }
    
    public class Composition
    {
        public HuffmanNode LeftChild
        {
            get;
            set;
        }

        public HuffmanNode RightChild
        {
            get;
            set;
        }

        public HuffmanNode Parent
        {
            get;
            set;
        }
    }
}
