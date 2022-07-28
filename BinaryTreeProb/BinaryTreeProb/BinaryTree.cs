using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTreeProb
{

    class BinaryTree<T> where T : IComparable<T>
    {
        public T Nodedata
        {
            get; set;
        }
        public BinaryTree<T> leftTree { get; set; }
        public BinaryTree<T> rightTree { get; set; }

        public BinaryTree(T nodeData)
        {
            this.Nodedata = nodeData;
            this.rightTree = null;
            this.leftTree = null;

        }
        int leftCount = 0, rightCount = 0;
        bool result = false;
        public void Insert(T item)
        {
            T currentNodeValue = this.Nodedata;
            if ((currentNodeValue.CompareTo(item)) > 0) // "A".CompareTo("a")
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinaryTree<T>(item);
                }
                else
                    this.leftTree.Insert(item);

            }
            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinaryTree<T>(item);
                }
                else
                    this.rightTree.Insert(item);
            }
        }


        public void Display()
        {
            if (this.leftTree != null)
            {
                this.leftCount++;
                this.leftTree.Display();
            }
            Console.WriteLine(this.Nodedata.ToString());
            if (this.rightTree != null)
            {
                this.rightCount++;
                this.rightTree.Display();
            }
        }

        public void GetSize()
        {
            Console.WriteLine("Size" + " " + (1 + this.leftCount + this.rightCount));
        }

        public bool IfExists(T element, BinaryTree<T> node)
        {
            if (node == null)
                return false;
            if (node.Nodedata.Equals(element))
            {
                Console.WriteLine("Found the element in Binary Search Tree" + " " + node.Nodedata);
                result = true;
            }
            else
                Console.WriteLine("Current element is {0} in Binary Search Tree", node.Nodedata);
            if (element.CompareTo(node.Nodedata) < 0)
                IfExists(element, node.leftTree);
            if (element.CompareTo(node.Nodedata) > 0)
                IfExists(element, node.rightTree);
            return result;
        }
    }
}
