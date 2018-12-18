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

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for ColorRGBPreview.xaml
    /// </summary>
    public partial class ColorRGBPreview : Window
    {
        public ColorRGBPreview()
        {
            InitializeComponent();
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color backgroundColor = Color.FromRgb((byte)Red.Value, (byte)Green.Value, (byte)Blue.Value);
            this.Background = new SolidColorBrush(backgroundColor);
        }
    }
}
