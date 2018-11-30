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

namespace DemoWPF
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

        private void pnlMainPanel_MouseUp(object sender, MouseButtonEventArgs args)
        {
            MessageBox.Show($"Position {args.GetPosition(this).ToString()}, {pnlMainPanel.RenderSize}");
        }

        private void PosUp_MouseEnter(object sender, MouseEventArgs e)
        {
            PosUp.Background = Brushes.WhiteSmoke;
            PosUp.Foreground = Brushes.Black;
        }

        private void PosUp_MouseLeave(object sender, MouseEventArgs e)
        {
            PosUp.Background = Brushes.Red;
            PosUp.Foreground = Brushes.White;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (List.Items.Count >= 10)
            {
                List.Items.Clear();
            }
            List.Items.Add(pnlMainPanel.FindResource("aNumber").ToString());
            List.Items.Add(pnlMainPanel.FindResource("strHelloWorld").ToString());
            //List.Items.Add(pnlMainPanel.FindResource("strApp").ToString());
            List.Items.Add(this.FindResource("strApp").ToString());
            //List.Items.Add(Application.Current.FindResource("strApp"));
            
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                e.Handled = true;
                MessageBox.Show($"Name is set", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtStatus.Clear();
            TextBox textBox = sender as TextBox;
            if (textBox.SelectionLength > 0)
            {
                txtStatus.Text = new StringBuilder($"Selection starts at character #{textBox.SelectionStart+1}\nSelection is {textBox.SelectionLength} charater(s) long\n" +
                    $"Selected Text: '{textBox.SelectedText}'").ToString();
            }
        }

        private void cbAll_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool condition = (cbAll.IsChecked == true);
            cbA.IsChecked = condition;
            cbB.IsChecked = condition;
            cbC.IsChecked = condition;
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAll.IsChecked = null;
            if((cbA.IsChecked == true) && (cbB.IsChecked==true) && (cbC.IsChecked == true))
            {
                cbAll.IsChecked = true;
            }
            if ((cbA.IsChecked == false) && (cbB.IsChecked == false) && (cbC.IsChecked == false))
            {
                cbAll.IsChecked = false;
            }
        }
    }
}
