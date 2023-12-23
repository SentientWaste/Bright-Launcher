using DialogHostAvalonia;
using System;

namespace Bright_Launcher.Services.UI {
    public class DialogService {
        private readonly string _baseNameSpace = "Bright_Launcher.Views.DialogContent.";

        public async void Show(string url) {
            var dialogContent = App.ServiceProvider
                .GetService(Type.GetType($"{_baseNameSpace}{url}"));

            if (DialogHost.IsDialogOpen("dialogHost"))
                return;

            await DialogHost.Show(dialogContent, "dialogHost");
        }

        public void Close() {
            DialogHost.Close("dialogHost");
        }
    }
}
