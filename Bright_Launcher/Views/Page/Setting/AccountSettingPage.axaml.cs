using Avalonia.Controls;
using Bright_Launcher.ViewModels.Pages.Setting;
using Microsoft.Extensions.DependencyInjection;

namespace Bright_Launcher.Views.Pages.Setting;

public partial class AccountSettingPage : UserControl {
    public AccountSettingPage() {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<AccountSettingPageViewModel>();
    }
}