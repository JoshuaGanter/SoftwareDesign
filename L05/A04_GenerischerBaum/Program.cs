using System;
using System.Collections.Generic;
using System.Linq;

namespace A04_GenerischerBaum
{
    class TreeNode<T>
    {
        private T _Content;
        private TreeNode<T> Parent;
        private List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode(T content)
        {
            _Content = content;
        }

        public TreeNode(T content, TreeNode<T> parent)
        {
            _Content = content;
            parent.AppendChild(this);
        }

        public void AppendChild(TreeNode<T> node)
        {
            Children.Add(node);
            node.Parent = this;
        }

        public void RemoveChild(TreeNode<T> node)
        {
            Children.Remove(node);
        }

        public void PrintTree()
        {
            Console.WriteLine(GetTreeString());
        }

        private string GetTreeString(string prefix = "")
        {
            string result = _Content.ToString();

            if (Children.Count != 0)
            {
                TreeNode<T> lastChild = Children.Last();
                foreach (TreeNode<T> child in Children)
                {
                    if (lastChild == child)
                    {
                        result += "\n" + prefix + "└─ " + child.GetTreeString(prefix + "   ");
                    }
                    else
                    {
                        result += "\n" + prefix + "├─ " + child.GetTreeString(prefix + "|  ");
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return _Content.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode<string>("I am the Godfather.");
            var child1 = new TreeNode<string>("And I'm a son of him.", root);
            var child2 = new TreeNode<string>("Hey, me too!", root);
            var gchild11 = new TreeNode<string>("And I'm the daugther of a son of the Godfather. Yay!", child1);
            var gchild12 = new TreeNode<string>("Another brick in the wall.", child1);
            var ggchild121 = new TreeNode<string>("I'm still an ancestor of the Godfather!", gchild12);
            var gggchild1211 = new TreeNode<string>("I'm just a regular guy. U mad?", ggchild121);

            root.PrintTree();

            Console.WriteLine("");
            ggchild121.RemoveChild(gggchild1211);
            gchild11.AppendChild(gggchild1211);
            root.PrintTree();

            // This would cause an infinite loop, since the child element (re)refers to it's root.
            //gggchild1211.AppendChild(root);
            //root.PrintTree();
        }
    }
}
