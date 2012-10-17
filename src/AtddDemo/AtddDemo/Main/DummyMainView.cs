namespace AtddDemo.Main
{
    public class DummyMainView : IMainView
    {
        private MainViewModel _viewModel;

        public bool HasBeenShown { get; private set; }

        public void ShowView(MainViewModel viewModel)
        {
            HasBeenShown = true;
            _viewModel = viewModel;
        }

        public MainViewModel ViewModel
        {
            get { return _viewModel; }
        }
    }
}