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

        public static int leftCount = 0, rightCount = 0;
        bool result = false;
        public void Insert(T item)
        {
            T currentNodeValue = this.Nodedata;
            //To assigning value to left and right by using if else statement

            if ((currentNodeValue.CompareTo(item)) > 0) 
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

        //Creating Display method to display binary tree
        public void Display()
        {
            if (this.leftTree != null)
            {
                leftCount++;
                this.leftTree.Display();
            }
            Console.WriteLine(this.Nodedata.ToString() + " ");

            if (this.rightTree != null)
            {
                rightCount++;
                this.rightTree.Display();
            }
        }

        public void Size()
        {
            Console.WriteLine("Size" + " " + (1 + rightCount + leftCount ));
        }
        public bool IfExists(T element, BinaryTree<T> node)
        {
            if (node == null)
                return false;
            if (node.Nodedata.Equals(element))
            {
                Console.WriteLine("Found the element in BinarySearch Tree" + " " + node.Nodedata);
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
