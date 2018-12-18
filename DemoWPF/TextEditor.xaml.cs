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
    /// Interaction logic for TextEditor.xaml
    /// </summary>
    public partial class TextEditor : Window
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void TxtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = TxtEditor.GetLineIndexFromCharacterIndex(TxtEditor.CaretIndex);
            int col = TxtEditor.CaretIndex - TxtEditor.GetCharacterIndexFromLineIndex(row);
            LbCursorPosition.Text = $"Line {row + 1}, Char {col + 1}";
        }
    }
}
