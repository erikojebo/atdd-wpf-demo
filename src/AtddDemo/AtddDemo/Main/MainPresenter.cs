using AtddDemo.Infrastructure;
using AtddDemo.Settings;

namespace AtddDemo.Main
{
    public class MainPresenter
    {
        private IMainView _view;
        private MainViewModel _viewModel;
        private readonly SettingsPresenter _settingsPresenter;

        public MainPresenter()
        {
            _settingsPresenter = ObjectRegistry.Create<SettingsPresenter>();
        }

        public void ShowView()
        {
            _view = ObjectRegistry.Create<IMainView>();
            _viewModel = ObjectRegistry.Create<MainViewModel>();
            _viewModel.Presenter = this;

            _view.ShowView(_viewModel);
        }

        public void ShowSettingsView()
        {
            _settingsPresenter.ShowView();
        }
    }
}