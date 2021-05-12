using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Review
{
    class custom_stack<T>
    {
        private Node<T> top;

        public custom_stack()
        {
            this.top = null;
        }

        public Boolean isEmpty()
        {
            return this.top == null;
        }

        public void push(T item)
        {
            Node<T> newNode = new Node<T>(item, this.top);

            this.top = newNode;
        }

        public T peek()
        {
            return top.item;
        }

        public T pop()
        {
            T tempReturn = this.top.item;
            this.top = this.top.next;
            return tempReturn;
        }
    }
}
