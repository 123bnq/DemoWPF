using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ISBNConverter;
using StarDebris.Avalonia.MessageBox;
using System;

namespace DemoAvaloniaISBNConverter
{
    public class MainWindow : Window
    {
        ISBNConvertLib cvt = new ISBNConvertLib();
        public MainWindow()
        {
            InitializeComponent();
            var btnConvert = this.Get<Button>("Convert");
            btnConvert.Click += Convert_Click;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            new MessageBox("Hello World", delegate (DialogResult r, EventArgs evt) {

                //if (r.result == MessageBoxButtons.Ok)
                //    Console.WriteLine("Ok clicked");
                //else if (r.result == MessageBoxButtons.Cancel)
                //    Console.WriteLine("Cancel clicked");

            }, MessageBoxStyle.Info, MessageBoxButtons.Ok | MessageBoxButtons.Cancel).Show();
            //if (string.IsNullOrWhiteSpace(ISBNInput.Text))
            //{
            //    MessageBox.Show("No ISBN is given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    if (ISBNInput.Text.Length < 10 || ISBNInput.Text.Length > 13)
            //    {
            //        MessageBox.Show("ISBN length is not exactly given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        string input = ISBNInput.Text.Replace("-", string.Empty);
            //        if ((bool)ISBN10.IsChecked || (bool)ISBN13.IsChecked)
            //        {
            //            var check = cvt.CheckISBN(input);
            //            if (check == null)
            //            {
            //                MessageBox.Show("ISBN length is not exactly given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //            }
            //            else if ((bool)check == false)
            //            {
            //                MessageBox.Show("Wrong ISBN is given. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //            }
            //            else
            //            {
            //                if ((bool)ISBN10.IsChecked)
            //                {
            //                    if (input.Length == 10)
            //                    {
            //                        ISBNOutput.Text = cvt.ISBN10to13(input);
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Wrong ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //                    }

            //                }
            //                else
            //                {
            //                    if (input.Length == 13)
            //                    {
            //                        ISBNOutput.Text = cvt.ISBN13to10(input);
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Wrong ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("No ISBN Type is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //    }
            //}
        }
    }
}
