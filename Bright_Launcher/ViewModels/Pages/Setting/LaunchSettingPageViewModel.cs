using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Bright_Launcher.Services.Setting;
using Bright_Launcher.Classes.Attributes;
using MinecraftLaunch.Classes.Models.Game;
using CommunityToolkit.Mvvm.ComponentModel;
using Bright_Launcher.Services.Launch;
using System.Threading.Tasks;
using Bright_Launcher.Services.UI;

namespace Bright_Launcher.ViewModels.Pages.Setting {
    public partial class LaunchSettingPageViewModel : SettingPageViewModelBase {
        private JavaService _javaService;
        private SettingService _settingService;
        private NavigationService _navigationService;

        public LaunchSettingPageViewModel(SettingService settingService, JavaService javaService, NavigationService navigationService) : base(settingService) {
            _javaService = javaService;
            _settingService = settingService;
            _navigationService = navigationService;
        }
        
        [ObservableProperty]
        [property:BindToSetting(ConfigName = nameof(Javas))]
        private ObservableCollection<JavaEntry> javas;

        [ObservableProperty]
        [property:BindToSetting(ConfigName = nameof(ActiveJava))]
        private JavaEntry activeJava;

        [RelayCommand]
        private async Task FindJava() {
            var result = await Task.Run(() => {
                return _javaService.FindJava();
            });

            Javas = new(result);
        }

        [RelayCommand]
        private void GoAccountPage() {
            _navigationService.Navigation("Setting.AccountSettingPage");
        }
    }
}
