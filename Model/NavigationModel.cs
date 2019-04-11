using Lab02Khomenko.Views;
using Lab02Khomenko.Windows;
using System;
using ContentWindow = Lab02Khomenko.Windows.ContentWindow;
using MainView = Lab02Khomenko.Views.MainView;
using WelcomeView = Lab02Khomenko.Views.WelcomeView;

namespace Lab02Khomenko.Model
{
    public enum ModesEnum
    {
        Main,
        Welcome
    }

    class NavigationModel
    {
        private readonly Windows.ContentWindow _contentWindow;
        private readonly Views.MainView _mainView;
        private readonly Views.WelcomeView _welcomeView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _mainView = new MainView(storage);
            _welcomeView = new WelcomeView(storage);
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                case ModesEnum.Welcome:
                    _contentWindow.ContentControl.Content = _welcomeView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
