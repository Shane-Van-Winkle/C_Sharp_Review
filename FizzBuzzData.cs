using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Review
{
    class FizzBuzzData
    {
        public int fizzNumber
        {
            get; set;
        }

        public string fizzString
        {
            get; set;
        }

        public FizzBuzzData(int fizzNumber, string fizzString)
        {
            //Console.WriteLine("newData");
            this.fizzNumber = fizzNumber;
            this.fizzString = fizzString;
        }
        /*
       public string toString()
        {
            return this.fizzNumber.ToString() + " : " + this.fizzString;
        }
        */
    }
}
