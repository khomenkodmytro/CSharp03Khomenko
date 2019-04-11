using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Lab02Khomenko.Model;
using Lab02Khomenko.Tools;

namespace Lab02Khomenko.ViewModel
{
    class WelcomeViewModel : INotifyPropertyChanged
    {
        private readonly WelcomeModel _welcomeModel;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private ICommand _proceedCommand;

        public WelcomeViewModel(Storage storage)
        {
            _welcomeModel = new WelcomeModel(storage);
            _date = DateTime.Today.Date;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                InvokePropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (_surname == value) return;
                _surname = value;
                InvokePropertyChanged(nameof(Surname));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value) return;
                _email = value;
                InvokePropertyChanged(nameof(Email));
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date == value) return;
                _date = value;
                InvokePropertyChanged(nameof(Date));
            }
        }
        public ICommand ProceedCommand
        {
            get =>
                _proceedCommand ??
                (_proceedCommand = new RelayCommand<object>(ProceedExecute, ProceedCanExecute));
            set
            {
                _proceedCommand = value;
                InvokePropertyChanged(nameof(ProceedCommand));
            }
        }

        private bool ProceedCanExecute(object obj)
        {
            return !(string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Surname) ||
                string.IsNullOrWhiteSpace(Email));
        }

        private void ProceedExecute(object obj)
        {
            try
            {
                _welcomeModel.Login(Name, Surname, Email, Date);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }

    }
}
