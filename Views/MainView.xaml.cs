using System.Windows.Controls;
using Lab02Khomenko.Model;
using Lab02Khomenko.ViewModel;

namespace Lab02Khomenko.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(Storage storage)
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel(storage);
            DataContext = viewModel;
        }
    }
}
