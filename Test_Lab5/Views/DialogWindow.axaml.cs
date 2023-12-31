using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Test_Lab5.Views;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}