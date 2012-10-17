using AtddDemo.Infrastructure;
using AtddDemo.Main;

namespace AtddDemo.Settings
{
    public partial class SettingsWindow : ISettingsView
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        public void ShowView(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;

            this.Owner = ObjectRegistry.GetLatestCreated<MainWindow>();
            ShowDialog();
        }

        public SettingsViewModel ViewModel
        {
            get { return DataContext as SettingsViewModel; }
            set { DataContext = value; }
        }
    }
}
