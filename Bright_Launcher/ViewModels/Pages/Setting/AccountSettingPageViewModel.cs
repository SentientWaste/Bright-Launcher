using Bright_Launcher.Services.UI;
using CommunityToolkit.Mvvm.Input;
using Bright_Launcher.Services.Setting;
using CommunityToolkit.Mvvm.Messaging;
using Bright_Launcher.Classes.Datas.Messaging;
using System.Collections.ObjectModel;
using MinecraftLaunch.Classes.Models.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using Bright_Launcher.Classes.Attributes;

namespace Bright_Launcher.ViewModels.Pages.Setting {
    public partial class AccountSettingPageViewModel : SettingPageViewModelBase {
        private DialogService _dialogService;
        private NavigationService _navigationService;

        [ObservableProperty]
        [property:BindToSetting(ConfigName = nameof(Accounts))]
        private ObservableCollection<Account> accounts;

        public AccountSettingPageViewModel(SettingService settingService, DialogService dialogService, NavigationService navigationService) : base(settingService) {
            _dialogService = dialogService;
            _navigationService = navigationService;

            WeakReferenceMessenger.Default.Register<AccountMessage>(this, ReceiveHandle);
        }

        [RelayCommand]
        private void GoBack() {
            _navigationService.Navigation("Setting.LaunchSettingPage");
        }

        [RelayCommand]
        private void OpenAuthenticateDialog() {
            _dialogService.Show("AuthenticateContent");
        }

        private void ReceiveHandle(object obj, AccountMessage accountMessage) {
            (Accounts ??= new()).Add(accountMessage.Account);
        }
    }
}
