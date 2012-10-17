using AtddDemo.Services;

namespace AtddDemo.Settings
{
    public class SettingsPresenter
    {
        SettingsWindow _view = new SettingsWindow();
        SettingsViewModel _viewModel = new SettingsViewModel();
        SettingsService _settingsService = new SettingsService();

        public SettingsPresenter()
        {
            _view.ViewModel = _viewModel;
        }

        public void ShowDialog()
        {
            var result = _view.ShowDialog();

            if(result.HasValue && result.Value)
            {
                SaveSettings();
            }
        }

        private void SaveSettings()
        {
            var settings = _viewModel.ToSettings();
            _settingsService.Save(settings);
        }
    }
}