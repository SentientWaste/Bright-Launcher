using Bright_Launcher.Classes.Datas.Messaging;
using Bright_Launcher.Services.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MinecraftLaunch.Components.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bright_Launcher.ViewModels.DialogContents {
    public partial class AuthenticateContentViewModel : ObservableObject {
        private DialogService _dialogService;
        private NavigationService _navigationService;

        public AuthenticateContentViewModel(DialogService dialogService,NavigationService navigationService) { 
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AuthenticateCommand))]
        private string userName;

        [RelayCommand]
        private void Cancel() {
            _dialogService.Close();
        }

        [RelayCommand(CanExecute = nameof(CanExecuteAuthenticate))]
        private void Authenticate() {
            OfflineAuthenticator authenticator = new(UserName);
            WeakReferenceMessenger.Default.Send(new AccountMessage {
                Account = authenticator.Authenticate()
            });
        }


        private bool CanExecuteAuthenticate() => !string.IsNullOrEmpty(UserName);
    }
}
