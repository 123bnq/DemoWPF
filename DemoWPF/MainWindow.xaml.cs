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
            List.Items.Add("Hello");
            List.Items.Add(10);
            //List.Items.Add(pnlMainPanel.FindResource(aNumber).ToString());
            //List.Items.Add(this.FindResource(strHelloWorld).ToString());
            //List.Items.Add(Application.Current.FindResource(strApp));
        }
    }
}
