using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for Converter.xaml
    /// </summary>
    public partial class Converter : Window, INotifyPropertyChanged
    {
        //Converter cvt = new Converter();

        private bool _myField;
        //Converter cvt = new Converter();

        public Converter()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
              {
                  this.DateText.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy HH:mm:ss");
              }, this.Dispatcher);

            this.DataContext = this;
            this.MyProperty = (TxtB_Editor != null) && (TxtB_Editor.SelectionLength > 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool MyProperty {
            get => _myField;
            set {
                if(_myField != value)
                {
                    _myField = value;
                    this.NotifyPropertyChanged("MyProperty");
                }
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New Command is used", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    TxtB_Editor.Cut();
        //}

        //private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = (TxtB_Editor != null) && (TxtB_Editor.SelectionLength > 0);
        //    this.MyProperty = (TxtB_Editor != null) && (TxtB_Editor.SelectionLength > 0);
        //}

        //private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    TxtB_Editor.Paste();
        //}

        //private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = Clipboard.ContainsText();
        //}
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                return (bool)value == true ? "yes" : "no";
            }
            return "no";
        }
    }
}
