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
    /// Interaction logic for form_StringReversal.xaml
    /// </summary>
    public partial class form_StringReversal : Window
    {
        public form_StringReversal()
        {
            InitializeComponent();
        }

        private void button_Submit_Click(object sender, RoutedEventArgs e)
        {
            Task<string> task_Reverse;
            string string_input = textbox_Input.Text;
            if (checkbox_BuiltInStack.IsChecked == true)
            {
            
                task_Reverse = Task.Run(() => method_StandardReverse(string_input));

            }
            else
            {
                task_Reverse = Task.Run(() => method_CustomReverse(string_input));
            }

            

            textbox_Output.Text = task_Reverse.Result;
        }

        public string method_StandardReverse(string string_Unreversed)
        {
            Stack<char> stack_Unreversed = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            //string string_Reversed = "";
           
            foreach(char c in string_Unreversed)
            {
                stack_Unreversed.Push(c);
            }    

            while(stack_Unreversed.Count > 0)
            {  
              sb.Append(stack_Unreversed.Pop());

            }
            
            return sb.ToString(); 
        }

        public string method_CustomReverse(string string_Unreversed)
        {
            custom_stack<char> stack_Unreversed = new custom_stack<char>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in string_Unreversed)
            {
                stack_Unreversed.push(c);
            }
            while(stack_Unreversed.isEmpty() == false)
            {
                sb.Append(stack_Unreversed.pop());
            }

            return sb.ToString();
        }

    }



}
