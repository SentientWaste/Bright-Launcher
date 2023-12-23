using System.Collections.Generic;
using Bright_Launcher.Services.Setting;
using MinecraftLaunch.Classes.Interfaces;
using MinecraftLaunch.Classes.Models.Game;
using MinecraftLaunch.Components.Resolver;

namespace Bright_Launcher.Services.Launch {
    public class GameService {
        private SettingService _settingService;

        public GameEntry ActiveGameEntry { get; set; }

        public IGameResolver GameResolver { get; private set; }

        public GameService(SettingService settingService) { 
            _settingService = settingService;
            GameResolver = new GameResolver(".minecraft");
        }

        public IEnumerable<GameEntry> Load() {
            return GameResolver.GetGameEntitys();
        }
    }
}
