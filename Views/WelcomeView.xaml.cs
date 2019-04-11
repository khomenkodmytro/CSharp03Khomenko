using System.Windows.Controls;
using Lab02Khomenko.Model;
using Lab02Khomenko.ViewModel;


namespace Lab02Khomenko.Views
{
    /// <summary>
    /// Логика взаимодействия для WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView(Storage storage)
        {
            InitializeComponent();
            WelcomeViewModel viewModel = new WelcomeViewModel(storage);
            DataContext = viewModel;
        }
    }
}
