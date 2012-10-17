using AtddDemo.Mvvm;

namespace AtddDemo
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowSettingsWindowCommand = new DelegateCommand(Presenter.ShowSettingsWindow);
        }

        public MainWindowPresenter Presenter { get; set; }

        public DelegateCommand ShowSettingsWindowCommand
        {
            get { return Get(() => ShowSettingsWindowCommand); }
            set { Set(() => ShowSettingsWindowCommand, value); }
        }
    }
}