using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Review
{
    class FizzBuzzNode<T>
    {
        public FizzBuzzNode<T> left
        {
            get; set;
        }

        public FizzBuzzNode<T> right
        {
            get; set;
        }
        public int value
        {
            set; get;
        }

        public T item
        {
            get; set;
        }

    }
}
