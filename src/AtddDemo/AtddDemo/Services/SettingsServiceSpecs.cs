using AtddDemo.Settings;
using NUnit.Framework;

namespace AtddDemo.Services
{
    [TestFixture]
    public class SettingsServiceSpecs
    {
        private SettingsService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SettingsService();
        }

        [Test]
        public void Empty_file_yields_default_settings()
        {
            var actualSettings = _service.Parse("");
            var expectedSettings = new ServerSettings();

            Assert.AreEqual(expectedSettings, actualSettings);
        }

        [Test]
        public void File_with_only_ip_yields_settings_with_given_ip()
        {
            var actualSettings = _service.Parse("server=localhost");

            Assert.AreEqual("localhost", actualSettings.ServerIp);
        }

        [Test]
        public void File_with_only_port_yields_settings_with_given_port()
        {
            var actualSettings = _service.Parse("port=123");

            Assert.AreEqual(123, actualSettings.Port);
        }

        [Test]
        public void File_with_only_timeout_yields_settings_with_given_timeout()
        {
            var actualSettings = _service.Parse("timeout=12");

            Assert.AreEqual(12, actualSettings.TimeoutInSeconds);
        }

        [Test]
        public void File_with_ip_port_and_timeout_yields_settings_with_given_values()
        {
            var actualSettings = _service.Parse(
@"server=localhost
port=123
timeout=12");

            Assert.AreEqual(12, actualSettings.TimeoutInSeconds);
            Assert.AreEqual(123, actualSettings.Port);
            Assert.AreEqual("localhost", actualSettings.ServerIp);
        }
    }
}