using AtddDemo.Infrastructure;
using AtddDemo.Services;

namespace AtddDemo.Settings
{
    public class SettingsPresenter
    {
        private ISettingsView _view;
        private SettingsViewModel _viewModel;
        private readonly SettingsService _settingsService;

        public SettingsPresenter()
        {
            _settingsService = ObjectRegistry.Create<SettingsService>();
        }

        public void ShowView()
        {
            _view = ObjectRegistry.Create<ISettingsView>();
            _viewModel = ObjectRegistry.Create<SettingsViewModel>();
            _viewModel.Presenter = this;

            var settings = _settingsService.Load();

            _viewModel.FromSettings(settings);

            _view.ShowView(_viewModel);
        }

        public void Confirm()
        {
            SaveSettings();
            _view.Close();
        }

        private void SaveSettings()
        {
            var settings = _viewModel.ToSettings();
            _settingsService.Save(settings);
        }
    }
}