using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Review
{
    /* the binary search tree was chosen for two reasons,:
        1) This shows that I can use references, recursion and object orientated design for coding.
        2) Everything stored is able to be recalled in sorted order using in order traversal.
        3) I can use the contains method later for efficiently searching if the tree already contains a node with that number.
    */

    class FizzBuzzTree
    {
        private Node<FizzBuzzData> root;
        
        //create the tree.
        public FizzBuzzTree()
        {
            this.root = null;
        }//end constructor

        //add a new FizzBuzz node tree.
        //input: A new FizzBuzzData item.
        //output: tree has a new data added
        public void add(FizzBuzzData item)
        {
          
            if(this.root == null)
            {
                this.root = new Node<FizzBuzzData>(item);
                
            }//end if
            else
            {
                addHelper(root, item);
            }//end else

        }//end add

        //recursively traverses a tree to place fizzbuzz data item where it needs to go.
        //input: the current node in the tree
        //output: the node is placed in the correct spot in the tree.
        private void addHelper(Node<FizzBuzzData> current, FizzBuzzData item)
        {
            if (current.item.fizzNumber > item.fizzNumber) // item to add is less the current's item, add to the left.
            {
                if (current.left != null)// travel to the left if we can
                {
                    addHelper(current.left, item);
                }//end if
                else //place node at the end
                {
                    current.left = new Node<FizzBuzzData>(item);
                }//end else
            }//end if
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
            }//end else
            
        }//end add helper

        //checks if the item is already inside of the tree
        //input: the int value of the item to check for.
        //output: a tuple boolean(true for "tree contains this number"; false for "does not contain") and a string of the matched value if any.
        public (Boolean, string) contains(FizzBuzzData item)
        {
            return containsHelper(this.root, item);
        }//end contains

        //recursively searches the tree for the item; is a helper for the contains method.
        //same input and output as above
        private (Boolean, string) containsHelper(Node<FizzBuzzData> current, FizzBuzzData item)
        {
            if(current == null)// if the current is not there return false.
            {
                return (false, "");
            }//end if

            if(item.fizzNumber == current.item.fizzNumber) // the item's fizzNumber is the same as the current node's item's fizzNumber.
            {
                return(true, current.item.fizzString);
            }//end if

            // search left because the item's fizzNumber is less than the current node's fizzNumber
            if (item.fizzNumber < current.item.fizzNumber  && current.left != null && containsHelper(current.left, item).Item1)
            {
                return(true, current.left.item.fizzString);
            }//end if

            // search right because the item's fizzNumber is greater than the current node's fizzNumber
            if (item.fizzNumber > current.item.fizzNumber && current.right != null & containsHelper(current.right, item).Item1){
                return (true, current.right.item.fizzString);
            }//end if

            return(false, "");
        }//end containsHelper


        //returns an array of fizzbuzzdata sorted by the fizznumber value
        //input: nothing
        //output a fizzBuzzData array sorted by fizzNumber
        public FizzBuzzData[] toArray()
        {
           
            return toArrayHelper(this.root, new List<FizzBuzzData>());
        }//end toArray

        //recursively traverses the FizzBuzz tree in order to return the Fizzbuzzdata array.
        private FizzBuzzData[] toArrayHelper(Node<FizzBuzzData> current, List<FizzBuzzData> list_output)
        {
            if(current == null)
            {
                return list_output.ToArray();//returns a new empty array so the program can count without any fizz nodes.
            }//end if
            
            toArrayHelper(current.left, list_output);
            //Adds data to the output list based on the current traversed node
            list_output.Add(new FizzBuzzData(current.item.fizzNumber, current.item.fizzString));
            toArrayHelper(current.right, list_output);

            return list_output.ToArray();
        }// end toArrayHelper
        
        //returns a string based on the contents of the tree
        //input: nothing
        //output:
        // a multi-lined string with the fizzNumber and fizzString separated by a colon
        //example:
        /*
         3 : Fizz
         5 : Buzz
         */ 
        public string toString()
        {
            return toStringHelper(root, new StringBuilder(""));
        }//end toString

        private string toStringHelper(Node<FizzBuzzData> current, StringBuilder output)
        {
            if(current == null)
            {
                return "";
            }//end if
            toStringHelper(current.left, output);
            output.Append(current.item.fizzNumber.ToString() + " : " + current.item.fizzString + "\n");
            toStringHelper(current.right, output);

            return output.ToString();
        }//end toStringHelper


    }//end class
}//end namespace
