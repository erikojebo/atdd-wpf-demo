using AtddDemo.Settings;
using NUnit.Framework;

namespace AtddDemo.Infrastructure
{
    [TestFixture]
    public class ObjectRegistrySpecs
    {
        [SetUp]
        public void SetUp()
        {
            ObjectRegistry.Register<ISettingsView, DummySettingsView>();
        }

        [Test]
        public void Requesting_unregistered_concrete_type_returns_instance_of_requested_type()
        {
            Assert.IsInstanceOf<SettingsViewModel>(ObjectRegistry.Create<SettingsViewModel>());
        }

        [Test]
        public void Requesting_registered_type_returns_instance_of_registered_type()
        {
            Assert.IsInstanceOf<ISettingsView>(ObjectRegistry.Create<DummySettingsView>());
        }

        [Test]
        public void Latest_created_for_requested_unregistered_concrete_type_is_concrete_type()
        {
            var instance = ObjectRegistry.Create<SettingsViewModel>();
            var cachedInstance = ObjectRegistry.GetLatestCreated<SettingsViewModel>();

            Assert.AreSame(instance, cachedInstance);
        }
        
        [Test]
        public void Latest_created_for_requested_registered_type_is_concrete_type()
        {
            var instance = ObjectRegistry.Create<ISettingsView>();
            var cachedInstance = ObjectRegistry.GetLatestCreated<ISettingsView>();

            Assert.AreSame(instance, cachedInstance);
        }
        
        [Test]
        public void Latest_created_for_concrete_type_after_requesting_registered_type_is_concrete_type()
        {
            var instance = ObjectRegistry.Create<ISettingsView>();
            var cachedInstance = ObjectRegistry.GetLatestCreated<DummySettingsView>();

            Assert.AreSame(instance, cachedInstance);
        }
    }
}