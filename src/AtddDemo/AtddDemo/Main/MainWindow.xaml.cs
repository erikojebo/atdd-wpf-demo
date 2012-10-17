namespace AtddDemo.Main
{
    public partial class MainWindow : IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowView(MainViewModel viewModel)
        {
            ViewModel = viewModel;
            Show();
        }

        public MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
            set { DataContext = value; }
        }
    }
}