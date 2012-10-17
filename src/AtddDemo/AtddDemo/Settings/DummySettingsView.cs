namespace AtddDemo.Settings
{
    public class DummySettingsView : ISettingsView
    {
        private SettingsViewModel _viewModel;

        public bool IsShown { get; private set; }

        public void ShowView(SettingsViewModel viewModel)
        {
            IsShown = true;

            _viewModel = viewModel;
        }

        public void Close()
        {
            IsShown = false;
        }

        public SettingsViewModel ViewModel
        {
            get { return _viewModel; }
        }
    }
}