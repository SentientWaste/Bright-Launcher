using System.Linq;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Bright_Launcher.Services.Launch;
using MinecraftLaunch.Classes.Models.Game;
using CommunityToolkit.Mvvm.ComponentModel;
using Bright_Launcher.Services.Setting;
using MinecraftLaunch.Classes.Models.Auth;
using Bright_Launcher.ViewModels.Pages.Setting;
using Bright_Launcher.Classes.Attributes;

namespace Bright_Launcher.ViewModels.Pages {
    public partial class LaunchPageViewModel : SettingPageViewModelBase {
        private GameService _gameService;
        private LaunchService _launchService;
        private SettingService _settingService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LaunchCommand))]
        private GameEntry gameEntry;

        [ObservableProperty]
        private ObservableCollection<GameEntry> gameEntries;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LaunchCommand))]
        [property:BindToSetting(ConfigName = nameof(Account))]
        private Account account;

        public ObservableCollection<Account> Accounts => _settingService.Data.Accounts;

        public LaunchPageViewModel(LaunchService launchService, GameService gameService, SettingService settingService) : base(settingService) {
            _gameService = gameService;
            _launchService = launchService;
            _settingService = settingService;

            PropertyChanged += OnPropertyChanged;
            GameEntries = [.. gameService.Load()];
        }

        [RelayCommand(CanExecute = nameof(CanExecuteLaunch))]
        private void Launch() {
            _launchService.LaunchGame();
        }

        private bool CanExecuteLaunch() => GameEntry is not null && Account is not null;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName is nameof(GameEntry)) {
                _gameService.ActiveGameEntry = GameEntry;
            }
        }
    }
}

