using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class is a dual purpose node, binary search tree (left and right) and a node list(next)
namespace Code_Review
{
    class Node<T>
    {
        public T item
        {
            get; set;
        }
        public Node<T> next
        {
            get; set;
        }

        public Node<T> left
        {
            get; set;
        }

        public Node<T> right
        {
            get; set;
        }

        public Node(T item, Node<T> next)
        {
            this.item = item;
            this.next = next;
            this.left = null;
            this.right = null;
        }

        public Node(T item)
        {
            this.item = item;
            this.left = null;
            this.next = null;
            this.right = null;
        }

        public Node()
        {
        }

        public string toString()
        {
            if(this.next == null)
            {
                return "" + item.ToString() + ", null";
            }
            else
            {
                return "( " + item.ToString() + ", " + this.next.toString() + ")";
            }
        }  

    }
}
