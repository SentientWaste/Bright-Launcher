namespace Bright_Launcher.Classes.Datas.Messaging {
    public record PropertyChangedMessage {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}
