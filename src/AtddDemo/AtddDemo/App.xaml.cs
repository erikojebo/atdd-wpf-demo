using System.Windows;
using AtddDemo.Infrastructure;
using AtddDemo.Main;

namespace AtddDemo
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var presenter = ObjectRegistry.Create<MainPresenter>();

            presenter.ShowView();

            base.OnStartup(e);
        }
    }
}
