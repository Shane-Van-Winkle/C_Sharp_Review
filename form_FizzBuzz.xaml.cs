using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //textBox_FizzNodeList.Text = (number * 2).ToString();
            if (correct)
            {
                richTextBox_FizzBuzzOutput.SelectAll();
                richTextBox_FizzBuzzOutput.Selection.Text = "";
                StringBuilder sb_output = new StringBuilder();
                string output = "";

                FizzBuzzData[] fbd_arr = tree.toArray();

                for(int i = 0; i < fbd_arr.Length; i++)
                {
                  Console.WriteLine(i);
                  Console.WriteLine(fbd_arr[i].fizzString + ":" + fbd_arr[i].fizzNumber.ToString());
                }
               

                
                for (int i = 1; i <= runto; i++)
                {

                    for (int j = 0; j < fbd_arr.Length; j++)
                    {
                        if (i % fbd_arr[j].fizzNumber == 0)
                        {
                            sb_output.Append(fbd_arr[j].fizzString);
                           // Console.WriteLine((i % fbd_arr[j].fizzNumber).ToString());
                        }
                    }
                   // Console.WriteLine(sb_output.ToString());
                    
                    if (sb_output.Length == 0)
                    {
                        output = i.ToString() + "\n";
                    }
                    else
                    {
                        output = sb_output.ToString() + "\n";
                    }


                    richTextBox_FizzBuzzOutput.AppendText(output);
                    output = "";
                    sb_output = new StringBuilder();
                   

                }
            }


        }

        private void button_addFizzNode_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            Boolean correct = true;
            try
            {
                number = int.Parse(textBox_Number.Text);
            }
            catch(Exception)
            {
                correct = false;
            }
            //textBox_FizzNodeList.Text = (number * 2).ToString();
            if (correct)
            {
                string fizzString = textBox_String.Text;




                FizzBuzzData fbData = new FizzBuzzData(number, fizzString);


                if (!tree.contains(fbData.fizzNumber).Item1){
                    tree.add(fbData);
                }
                //Console.WriteLine(fizzString);


                //textBox_FizzNodeList.Text = tree.toString();
                // add stuff to the rich text box later
                richTextBox_FizzNodeList.SelectAll();
                richTextBox_FizzNodeList.Selection.Text = "";
                richTextBox_FizzNodeList.AppendText(tree.toString());

            }
        }
    }
}
