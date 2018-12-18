using DemoWPF.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            users.Add(new User() { Name = "Tom" });
            users.Add(new User() { Name = "Jerry" });

            lbUsers.ItemsSource = users;
        }

        private void pnlMainPanel_MouseUp(object sender, MouseButtonEventArgs args)
        {
            MessageBox.Show($"Position {args.GetPosition(this).ToString()}");
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
            bool differ = true;
            string[] items = new string[List.Items.Count];
            List.Items.CopyTo(items, 0);
            if (List.Items.Count >= 6)
            {
                List.Items.Clear();
            }
            if (comboBox.SelectedItem != null)
            {
                if (items.Length > 0)
                {
                    foreach (var item in items)
                    {
                        if (comboBox.SelectedItem.ToString() == item)
                        {
                            differ = false;
                        }
                    }
                    if (differ)
                    {
                        List.Items.Add(comboBox.SelectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Existinng Item is added. Choose another Item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    List.Items.Add(comboBox.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("No item is chosen. Please check again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //List.Items.Add(pnlMainPanel.FindResource("aNumber").ToString());
            //List.Items.Add(pnlMainPanel.FindResource("strHelloWorld").ToString());
            //List.Items.Add(pnlMainPanel.FindResource("strApp").ToString());
            //List.Items.Add(this.FindResource("strApp").ToString());
            //List.Items.Add(Application.Current.FindResource("strApp"));

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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
                txtStatus.Text = new StringBuilder($"Selection starts at character #{textBox.SelectionStart + 1}\nSelection is {textBox.SelectionLength} charater(s) long\n" +
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
            if ((cbA.IsChecked == true) && (cbB.IsChecked == true) && (cbC.IsChecked == true))
            {
                cbAll.IsChecked = true;
            }
            if ((cbA.IsChecked == false) && (cbB.IsChecked == false) && (cbC.IsChecked == false))
            {
                cbAll.IsChecked = false;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login pnlLogin = new Login();
            pnlLogin.Owner = this;
            pnlLogin.txtUser.Focus();
            pnlLogin.ShowDialog();
        }

        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            List.Items.Clear();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = txtWidth.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            binding = txtHeight.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New User" });
        }

        private void btnChangeUSer_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                (lbUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                users.Remove((User)lbUsers.SelectedItem);
            }
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            Converter convertWindow = new Converter();
            convertWindow.Owner = this;
            convertWindow.ShowDialog();
        }

        private void BtnReadText_Click(object sender, RoutedEventArgs e)
        {
            OpenFileWindow window = new OpenFileWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnEnterName_Click(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog("Please enter your name:", "Johnny English");
            inputDialog.Owner = this;
            if(inputDialog.ShowDialog() == true)
            {
                LbName.Text = inputDialog.Answer;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void BtnTextEditor_Click(object sender, RoutedEventArgs e)
        {
            new TextEditor
            {
                Owner = this,
                Background = Brushes.WhiteSmoke
            }.ShowDialog();
        }

        private void BtnColorPreview_Click(object sender, RoutedEventArgs e)
        {
            new ColorRGBPreview() { Owner = this }.ShowDialog();
        }
    }

    public class User : INotifyPropertyChanged
    {
        private string _name;
        public string Name {
            get => _name;
            set
            {
                if(this._name != value)
                {
                    this._name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
