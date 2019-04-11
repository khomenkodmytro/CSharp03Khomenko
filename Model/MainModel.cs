using System;
using Lab02Khomenko.Navigation;

namespace Lab02Khomenko.Model
{
    class MainModel
    {
        private Storage _storage;
        public event Action<Person> UIPersonChanged;

        public MainModel(Storage storage)
        {
            _storage = storage;
            storage.PersonChanged += OnPersonChanged;
        }
        private void OnPersonChanged(Person person)
        {
            UIPersonChanged?.Invoke(person);
        }

        internal void ShowWelcome()
        {
            NavigationManager.Instance.Navigate(ModesEnum.Welcome);
        }
    }
}
