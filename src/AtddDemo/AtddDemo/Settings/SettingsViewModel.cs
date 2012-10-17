using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtddDemo.Mvvm;

namespace AtddDemo.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            ConfirmCommand = new DelegateCommand(() => Presenter.Confirm());
        }

        public SettingsPresenter Presenter { get; set; }

        public DelegateCommand ConfirmCommand
        {
            get { return Get(() => ConfirmCommand); }
            set { Set(() => ConfirmCommand, value); }
        }

        public string ServerIp
        {
            get { return Get(() => ServerIp); }
            set { Set(() => ServerIp, value); }
        }

        public int Port
        {
            get { return Get(() => Port); }
            set { Set(() => Port, value); }
        }

        public int TimeoutInSeconds
        {
            get { return Get(() => TimeoutInSeconds); }
            set { Set(() => TimeoutInSeconds, value); }
        }

        public ServerSettings ToSettings()
        {
            return new ServerSettings
                       {
                           ServerIp = ServerIp,
                           Port = Port,
                           TimeoutInSeconds = TimeoutInSeconds,
                       };
        }

        public void FromSettings(ServerSettings settings)
        {
            ServerIp = settings.ServerIp;
            Port = settings.Port;
            TimeoutInSeconds = settings.TimeoutInSeconds;
        }
    }
}
