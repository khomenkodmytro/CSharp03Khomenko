using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Lab02Khomenko.Model;
using Lab02Khomenko.Tools;

namespace Lab02Khomenko.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly MainModel _mainModel;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private string _isAdult;
        private string _westernZodiac;
        private string _chineseZodiac;
        private string _isBirthdayToday;

        private Visibility _birthdayVisibility;

        private ICommand _backCommand;

        public MainViewModel(Storage storage)
        {
            _mainModel = new MainModel(storage);
            _mainModel.UIPersonChanged += UiOnPersonChanged;
        }

        private void UiOnPersonChanged(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            BirthDate = person.BirthdayDate;
            IsAdult = person.IsAdult ? "Так" : "Ні";
            WesternZodiac = person.SunSign;
            ChineseZodiac = person.ChineseSign;
            IsBirthdayToday = person.IsBirthday ? "Так" : "Ні";
            BirthdayVisibility = person.IsBirthday ? Visibility.Visible : Visibility.Collapsed;
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

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate == value) return;
                _birthDate = value;
                InvokePropertyChanged(nameof(BirthDate));
            }
        }

        public string IsAdult
        {
            get => _isAdult;
            set
            {
                if (_isAdult == value) return;
                _isAdult = value;
                InvokePropertyChanged(nameof(IsAdult));
            }
        }

        public string WesternZodiac
        {
            get => _westernZodiac;
            set
            {
                if (_westernZodiac == value) return;
                _westernZodiac = value;
                InvokePropertyChanged(nameof(WesternZodiac));
            }
        }
        public string ChineseZodiac
        {
            get => _chineseZodiac;
            set
            {
                if (_chineseZodiac == value) return;
                _chineseZodiac = value;
                InvokePropertyChanged(nameof(ChineseZodiac));
            }
        }
        public string IsBirthdayToday
        {
            get => _isBirthdayToday;
            set
            {
                if (_isBirthdayToday == value) return;
                _isBirthdayToday = value;
                InvokePropertyChanged(nameof(IsBirthdayToday));
            }
        }
        public Visibility BirthdayVisibility
        {
            get => _birthdayVisibility;
            set
            {
                if (_birthdayVisibility == value) return;
                _birthdayVisibility = value;
                InvokePropertyChanged(nameof(BirthdayVisibility));
            }
        }

        public ICommand BackCommand
        {
            get => _backCommand ?? (_backCommand = new RelayCommand<object>(BackExecute, BackCanExecute));
            set
            {
                _backCommand = value;
                InvokePropertyChanged(nameof(BackCommand));
            }
        }
        private void BackExecute(object obj)
        {
            _mainModel.ShowWelcome();
        }

        private bool BackCanExecute(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }
    }
}
