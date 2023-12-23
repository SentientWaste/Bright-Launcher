using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Bright_Launcher.ViewModels.DialogContents;

namespace Bright_Launcher.Views.DialogContent {
    public partial class AuthenticateContent : UserControl {
        public AuthenticateContent() {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetService<AuthenticateContentViewModel>();
        }
    }
}
