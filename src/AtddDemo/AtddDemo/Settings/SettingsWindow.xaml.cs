namespace AtddDemo.Settings
{
    public partial class SettingsWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        public SettingsViewModel ViewModel
        {
            get { return DataContext as SettingsViewModel; }
            set { DataContext = value; }
        }
    }
}
