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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Code_Review
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_StringReversal_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(newStringReversalWindow));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void newStringReversalWindow()
        {
            new form_StringReversal().ShowDialog();
        }

        private void button_FizzBuzz_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(newFizzBuzzWindow));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void newFizzBuzzWindow()
        {
            new form_FizzBuzz().ShowDialog();
        }
    }
}
