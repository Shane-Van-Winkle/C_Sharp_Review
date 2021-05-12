using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Review
{
    class FizzBuzzTree
    {
        private Node<FizzBuzzData> root;

        public FizzBuzzTree()
        {
            this.root = null;
        }

        //add a new item to the tree if given an item.
        public void add(FizzBuzzData item)
        {
            if(this.root == null)
            {
                this.root = new Node<FizzBuzzData>(item);
            }
            else
            {
                addHelper(root, item);
            }

        }

        //recursively traverses a tree to place fizzbuzz data item where it needs to go.
        private void addHelper(Node<FizzBuzzData> current, FizzBuzzData item)
        {
            if (current.item.fizzNumber > item.fizzNumber) // item to add is less the current's item, add to the left.
            {
                if (current.left != null)// travel to the left if we can
                {
                    addHelper(current.left, item);
                }
                else //place node at the end
                {
                    current.left = new Node<FizzBuzzData>(item);
                }
            }// end if
            else //item to add is greater than the current's item, add to the right.
            {
                if(current.right != null)
                {
                    addHelper(current.right, item);
                }
                else
                {
                    current.right = new Node<FizzBuzzData>(item);
                }
            }// end else
            
        }// end add helper

        public (Boolean, string) contains(int item)
        {
            return containsHelper(this.root, item);
        }

        private (Boolean, string) containsHelper(Node<FizzBuzzData> current, int item)
        {
            if(current == null)
            {
                return (false, "");
            }

            if(current.item.fizzNumber == item)
            {
                return(true, current.item.fizzString);
            }

            if (current.item.fizzNumber > item && current.left != null && containsHelper(current.left, item).Item1)
            {
                return(true, current.left.item.fizzString);
            }

            if (current.item.fizzNumber < item && current.right != null & containsHelper(current.right, item).Item1){
                return (true, current.right.item.fizzString);
            }

            return(false, "");
        }


        public FizzBuzzData[] toArray()
        {
           
            return toArrayHelper(this.root, new List<FizzBuzzData>());
        }

        private FizzBuzzData[] toArrayHelper(Node<FizzBuzzData> current, List<FizzBuzzData> list_output)
        {
            if(current == null)
            {
                return null;
            }     
            toArrayHelper(current.left, list_output);
            FizzBuzzData data = new FizzBuzzData(current.item.fizzNumber, current.item.fizzString);
            list_output.Add(data);
       
            toArrayHelper(current.right, list_output);

            return list_output.ToArray();
        }

        public string toString()
        {
            return toStringHelper(root, new StringBuilder(""));
        }

        private string toStringHelper(Node<FizzBuzzData> current, StringBuilder output)
        {
            if(current == null)
            {
                return "";
            }
            toStringHelper(current.left, output);
            output.Append(current.item.fizzNumber + " : " + current.item.fizzString + "\n");
            toStringHelper(current.right, output);

            return output.ToString();
        }


    }
}
