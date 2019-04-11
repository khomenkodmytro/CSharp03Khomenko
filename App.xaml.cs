using Lab02Khomenko.Windows;
using System.Windows;
using Lab02Khomenko.Model;
using Lab02Khomenko.Navigation;
using ContentWindow = Lab02Khomenko.Windows.ContentWindow;

namespace Lab02Khomenko
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Storage storage = new Storage();
            Windows.ContentWindow contentWindow = new ContentWindow();

            NavigationModel navigationModel = new NavigationModel(contentWindow, storage);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate(ModesEnum.Welcome);
        }
    }
}
