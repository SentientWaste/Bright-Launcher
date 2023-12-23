using Bright_Launcher.Classes.Datas.Messaging;
using Bright_Launcher.Services.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Bright_Launcher.ViewModels.Pages.Setting {
    public partial class SettingPageViewModel : ObservableObject {
        private NavigationService _navigationService;

        public SettingPageViewModel(NavigationService navigationService) {
            _navigationService = navigationService;

            WeakReferenceMessenger.Default.Register<PageMessage>(this, HandleMessage);
            _navigationService.Navigation("Setting.LaunchSettingPage");
        }

        [ObservableProperty]
        private object content;

        [RelayCommand]
        private void Navigation(string name) {
            _navigationService?.Navigation(name);
        }

        private void HandleMessage(object obj, PageMessage message) {
            if (message.PageName.Contains('.') && message.PageName != "Setting.SettingPage") {
                Content = message.Page;
            }
        }
    }
}
