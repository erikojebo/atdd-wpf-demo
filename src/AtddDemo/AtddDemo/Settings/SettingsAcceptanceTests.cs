using AtddDemo.Infrastructure;
using AtddDemo.Main;
using AtddDemo.Services;
using NUnit.Framework;

namespace AtddDemo.Settings
{
    [Category("AcceptanceTests")]
    [TestFixture]
    public class SettingsAcceptanceTests
    {
        [Test]
        public void Settings_can_be_written_to_disk_and_read_back()
        {
            var expectedSettings = new ServerSettings
                               {
                                   ServerIp = "192.168.1.2",
                                   Port = 123,
                                   TimeoutInSeconds = 456
                               };

            var service = new SettingsService();

            service.Save(expectedSettings);

            var actualSettings = service.Load();

            Assert.AreEqual(expectedSettings, actualSettings);
        }

        [Test]
        public void Changes_made_to_settings_through_the_settings_view_should_remain_after_restarting_the_application()
        {
            ObjectRegistry.Register<IMainView, DummyMainView>();
            ObjectRegistry.Register<ISettingsView, DummySettingsView>();

            var firstSettingsView = ShowSettingsView();

            firstSettingsView.ViewModel.ServerIp = "192.168.123.234";
            firstSettingsView.ViewModel.Port = 8080;
            firstSettingsView.ViewModel.TimeoutInSeconds = 12;

            firstSettingsView.ViewModel.ConfirmCommand.Execute(null);

            Assert.IsFalse(firstSettingsView.IsShown);

            var secondSettingsView = ShowSettingsView();

            Assert.AreEqual("192.168.123.234", secondSettingsView.ViewModel.ServerIp);
            Assert.AreEqual(8080, secondSettingsView.ViewModel.Port);
            Assert.AreEqual(12, secondSettingsView.ViewModel.TimeoutInSeconds);
        }

        private static DummySettingsView ShowSettingsView()
        {
            var mainPresenter = ObjectRegistry.Create<MainPresenter>();

            mainPresenter.ShowView();

            var mainView = ObjectRegistry.GetLatestCreated<DummyMainView>();

            Assert.IsTrue(mainView.HasBeenShown);

            mainView.ViewModel.ShowSettingsViewCommand.Execute(null);

            var settingsView = ObjectRegistry.GetLatestCreated<DummySettingsView>();

            Assert.IsTrue(settingsView.IsShown);
            return settingsView;
        }

        // test for cancel
    }
}