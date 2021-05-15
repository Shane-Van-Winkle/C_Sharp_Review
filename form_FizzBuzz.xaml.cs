using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Code_Review
{
    /// <summary>
    /// Interaction logic for form_FizzBuzz.xaml
    /// </summary>
    public partial class form_FizzBuzz : Window
    {
        public form_FizzBuzz()
        {
            InitializeComponent();
        }

        FizzBuzzTree tree = new FizzBuzzTree();

        delegate void addDelegate();
        delegate void runFizzBuzzDelegate();


        //When the "Run" button is clicked, it has to run the fizzbuzz while using the fizzbuzz nodes in the tree.
        private void button_RunClick(object sender, RoutedEventArgs e)
        {
            int runto = 0;
            Boolean correct = true;
            try
            {
                runto = int.Parse(textBox_RunTo.Text);
            }
            catch (Exception)
            {
                correct = false;
            }

            if (correct)
            {

                Thread t = new Thread(() => runFizz(runto));
                t.Start();
            }//end runclick
        }



        void runFizz(int runto)
        {

           // runFizzBuzzDelegate run = runto; 
            //clear the output to prepare for the new text
            Dispatcher.Invoke(new Action(() =>
            {
                richTextBox_FizzBuzzOutput.SelectAll();
                richTextBox_FizzBuzzOutput.Selection.Text = "";
            }), System.Windows.Threading.DispatcherPriority.ContextIdle// can remove this line
            );

            StringBuilder sb_output = new StringBuilder();
            string output = "";

            FizzBuzzData[] fbd_arr = tree.toArray();
            /*
            for (int i = 0; i < fbd_arr.Length; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(fbd_arr[i].fizzString + ":" + fbd_arr[i].fizzNumber.ToString());
            }
            */
            for (int i = 1; i <= runto; i++)
            {

                for (int j = 0; j < fbd_arr.Length; j++)
                {
                    if (i % fbd_arr[j].fizzNumber == 0)
                    {
                        sb_output.Append(fbd_arr[j].fizzString);
                        // Console.WriteLine((i % fbd_arr[j].fizzNumber).ToString());
                    }
                }//end for
                 // Console.WriteLine(sb_output.ToString());

                if (sb_output.Length == 0)
                {
                    output = i.ToString() + "\n";
                }
                else
                {
                    output = sb_output.ToString() + "\n";
                }

                //clear the output to prepare for the new text
                Dispatcher.Invoke(new Action(() =>
                {
                    richTextBox_FizzBuzzOutput.AppendText(output);
                }));
                output = "";
                sb_output = new StringBuilder();


            }//end for
        }

        private void button_addFizzNode_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            Boolean correct = true;
            try
            {
                number = int.Parse(textBox_Number.Text);
            }
            catch (Exception)
            {
                correct = false;
            }
            //textBox_FizzNodeList.Text = (number * 2).ToString();
            if (correct)
            {
                string fizzString = textBox_String.Text;

                FizzBuzzData fbData = new FizzBuzzData(number, fizzString);
               
                Task task_add = Task.Run(() => addFizzNode(fbData));
                
            }//end if
        }//end addfizz node

        void addFizzNode(FizzBuzzData fbData)
        {

            if (!tree.contains(fbData).Item1)
            {
                tree.add(fbData);
            }//end if
             //Console.WriteLine(fizzString);


            //textBox_FizzNodeList.Text = tree.toString();
            // add stuff to the rich text box later
            //have to use Dispatcher.Invoke to update UI elements.
            Dispatcher.Invoke(new Action(() =>
            {
                richTextBox_FizzNodeList.SelectAll();
                richTextBox_FizzNodeList.Selection.Text = "";
                richTextBox_FizzNodeList.AppendText(tree.toString());
            })); 
        }//end addFizzNode
    }

}//end class
