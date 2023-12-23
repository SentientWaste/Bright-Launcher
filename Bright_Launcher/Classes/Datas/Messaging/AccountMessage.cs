using MinecraftLaunch.Classes.Models.Auth;

namespace Bright_Launcher.Classes.Datas.Messaging {
    public record AccountMessage {
        public Account Account { get; set; }
    }
}
