namespace AtddDemo.Main
{
    public interface IMainView
    {
        void ShowView(MainViewModel viewModel);

        MainViewModel ViewModel { get; }
    }
}