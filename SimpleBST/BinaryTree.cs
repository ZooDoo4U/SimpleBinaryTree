using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBST
{
    public class BinaryTree<TData>
        where TData : IComparable
    {
        private BinaryTree<TData> left;
        private BinaryTree<TData> right;

        private readonly TData data;

        public TData Data
        {
            get { return data; }
        }

        public BinaryTree()
        {
            left = null;
            right = null;
        }

        public BinaryTree(TData data)
        {
            left = null;
            right = null;
            this.data = data;
        }

        /// <summary>
        /// Searches the tree for an element matching TData
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The node</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when we can't find the node</exception>
        public BinaryTree<TData> FindNode(TData data)
        {
            if (this.data.CompareTo(data) == 0)
                return this;
            else if (this.data.CompareTo(data) < 0 && this.right != null)
                return this.right.FindNode(data);
            else if (this.data.CompareTo(data) > 0 && this.left != null)
                return this.left.FindNode(data);

            throw new System.ArgumentOutOfRangeException("data", "Couldn't find " + data.ToString() + " in the BST");
        }

        public void AddNode(TData data)
        {
            if (this.data.CompareTo(data) == 0)
                throw new ArgumentException(data.ToString() + " already exists in the BST");
            else if(this.data.CompareTo(data) < 0)
            {
                if(this.right == null)
                {
                    this.right = new BinaryTree<TData>(data);
                    return;
                }
                else
                {
                    this.right.AddNode(data);
                }
            }
            else // this.data.CompareTo(data) > 0
            {
                if(this.left == null)
                {
                    this.left = new BinaryTree<TData>(data);
                    return;
                }
                else
                {
                    this.left.AddNode(data);
                }
            }
        }
    }
}