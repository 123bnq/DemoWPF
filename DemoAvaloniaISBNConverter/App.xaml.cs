using Avalonia;
using Avalonia.Markup.Xaml;

namespace DemoAvaloniaISBNConverter
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
