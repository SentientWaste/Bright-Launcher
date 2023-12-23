using System.Diagnostics;
using Bright_Launcher.Services.Setting;
using MinecraftLaunch.Classes.Interfaces;
using MinecraftLaunch.Components.Launcher;
using MinecraftLaunch.Classes.Models.Event;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;

namespace Bright_Launcher.Services.Launch {
    public class LaunchService {
        private ILauncher _launcher;
        private GameService _gameService;
        private SettingService _settingService;

        public LaunchService(SettingService settingService, GameService gameService) { 
            _gameService = gameService;
            _settingService = settingService;
        }

        public async void LaunchGame() {
            _launcher = new Launcher(_gameService.GameResolver, Build());

            var result = await _launcher.LaunchAsync(_gameService.ActiveGameEntry.Id);
            if(result != null) {
                result.OutputLogReceived += OnOutputLogReceived;
            }
        }

        private LaunchConfig Build() => new(_settingService.Data.Account) {
            JvmConfig = new(_settingService.Data.ActiveJava.JavaPath) {
                MaxMemory = 1024,
            },
            LauncherName = "BrightLauncher",
        };

        private void OnOutputLogReceived(object sender, LogReceivedEventArgs e) {
            Debug.WriteLine(e.Text);
        }
    }
}
