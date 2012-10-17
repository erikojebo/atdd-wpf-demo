using AtddDemo.Mvvm;

namespace AtddDemo.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ShowSettingsViewCommand = new DelegateCommand(() => Presenter.ShowSettingsView());
        }

        public MainPresenter Presenter { get; set; }

        public DelegateCommand ShowSettingsViewCommand
        {
            get { return Get(() => ShowSettingsViewCommand); }
            set { Set(() => ShowSettingsViewCommand, value); }
        }
    }
}