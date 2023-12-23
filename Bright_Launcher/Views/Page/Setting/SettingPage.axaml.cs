using Avalonia.Controls;
using Bright_Launcher.ViewModels.Pages.Setting;
using Microsoft.Extensions.DependencyInjection;

namespace Bright_Launcher.Views.Pages.Setting;

public partial class SettingPage : UserControl {
    public SettingPage() {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<SettingPageViewModel>();
    }
}