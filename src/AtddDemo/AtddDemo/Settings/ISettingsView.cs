namespace AtddDemo.Settings
{
    public interface ISettingsView
    {
        void ShowView(SettingsViewModel viewModel);

        SettingsViewModel ViewModel { get; }
        void Close();
    }
}