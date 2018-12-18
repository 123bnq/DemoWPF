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

namespace DemoWPF.Dialogs
{
    /// <summary>
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        public InputDialog(string question, string defaultAnswer = "")
        {
            InitializeComponent();
            this.Question.Content = question;
            this.TxtAnswer.Text = defaultAnswer;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.TxtAnswer.SelectAll();
            this.TxtAnswer.Focus();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string Answer
        {
            get => TxtAnswer.Text;
        }
    }
}
