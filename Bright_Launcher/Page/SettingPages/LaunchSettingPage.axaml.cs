using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Bright_Launcher;

public partial class LaunchSettingPage : UserControl
{
    public LaunchSettingPage()
    {
        InitializeComponent();
    }


    private void AccountP(object sender, RoutedEventArgs e)
    {
        SettingPage.SP.FrameX.Content = new Account();
    }
}