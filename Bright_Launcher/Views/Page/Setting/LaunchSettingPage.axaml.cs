using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Bright_Launcher.ViewModels.Pages.Setting;
using Microsoft.Extensions.DependencyInjection;

namespace Bright_Launcher.Views.Pages.Setting;

public partial class LaunchSettingPage : UserControl {
    public LaunchSettingPage() {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<LaunchSettingPageViewModel>();
    }
}