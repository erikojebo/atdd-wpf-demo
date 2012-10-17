using NUnit.Framework;

namespace AtddDemo.Services
{
    [TestFixture]
    public class SettingsServerSpecs
    {
        private SettingsService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SettingsService();
        }

        [Test]
        public void Empty_file_yields_empty_settings()
        {
            var settings = _service.Parse("");

            Assert.IsNotNull(settings);
        }

        [Test]
        public void File_with_only_ip_yields_settings_with_given_ip()
        {
            var settings = _service.Parse("server:192.168.1.2");

            Assert.AreEqual("192.168.1.2", settings.ServerIp);
        }

        [Test]
        public void File_with_only_port_yields_settings_with_given_port()
        {
            var settings = _service.Parse("port:123");

            Assert.AreEqual(123, settings.Port);
        }
        
        [Test]
        public void File_with_only_timeout_yields_settings_with_given_timeout()
        {
            var settings = _service.Parse("timeout:234");

            Assert.AreEqual(234, settings.TimeoutInSeconds);
        }

        [Test]
        public void File_with_ip_port_and_timeout_sets_all_values()
        {
            var fileContents =
@"server:192.168.1.2
port:123
timeout:234";

            var settings = _service.Parse(fileContents);

            Assert.AreEqual("192.168.1.2", settings.ServerIp);
            Assert.AreEqual(123, settings.Port);
            Assert.AreEqual(234, settings.TimeoutInSeconds);
        }
    }
}