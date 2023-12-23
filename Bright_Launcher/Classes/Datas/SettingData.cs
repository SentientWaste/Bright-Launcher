using MinecraftLaunch.Classes.Models.Auth;
using MinecraftLaunch.Classes.Models.Game;
using System.Collections.ObjectModel;

namespace Bright_Launcher.Classes.Datas {
    public record SettingData {
        public JavaEntry ActiveJava { get; set; }

        public ObservableCollection<JavaEntry> Javas { get; set; }

        public ObservableCollection<Account> Accounts { get; set; }

        public Account Account { get; set; }
    }
}
