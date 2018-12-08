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

namespace ISBNConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISBNConvertLib cvt = new ISBNConvertLib();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ISBNInput.Text))
            {
                MessageBox.Show("No ISBN is given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ISBNInput.Text.Length < 10 || ISBNInput.Text.Length > 13)
                {
                    MessageBox.Show("ISBN length is not exactly given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string input = ISBNInput.Text.Replace("-", string.Empty);
                    if ((bool)ISBN10.IsChecked || (bool)ISBN13.IsChecked)
                    {
                        var check = cvt.CheckISBN(input);
                        if (check == null)
                        {
                            MessageBox.Show("ISBN length is not exactly given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if ((bool)check == false)
                        {
                            MessageBox.Show("Wrong ISBN is given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            if ((bool)ISBN10.IsChecked)
                            {
                                if (input.Length == 10)
                                {
                                    ISBNOutput.Text = cvt.ISBN10to13(input);
                                }
                                else
                                {
                                    MessageBox.Show("Wrong ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }

                            }
                            else
                            {
                                if (input.Length == 13)
                                {
                                    ISBNOutput.Text = cvt.ISBN13to10(input);
                                }
                                else
                                {
                                    MessageBox.Show("Wrong ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
