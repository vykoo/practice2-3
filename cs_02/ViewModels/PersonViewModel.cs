using System;
using System.Windows;
using Practice4.Exceptions;
using Sukhoviy02.Models;
using Sukhoviy02.Tools;

namespace Sukhoviy02.ViewModels
{
    class PersonViewModel : ObservableItem
    {
        private RelayCommand<object> _calculateCommand;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date = DateTime.Today;

        private bool _isAdult = false;
        private string _western;
        private string _chinese;
        private bool _birthday = true;
   
        public Model Model { get; private set; }
        public Person Person { get; private set; }

        public PersonViewModel()
        {
            Model = new Model();
        }

        private void Refresh_data()
        {
            try
            {
                Model.CheckEmail(Email);
                Model.CheckBirthdayInFuture(Date);
                Model.CheckIfTooOld(Date);

                Person = new Person(Name, Surname, Email, Date);

                IsAdultte = Person.IsAdult;
                Western = Person.SunSign;
                Chinese = Person.ChineseSign;
                Birthday = Person.IsBirthday;
            }
            catch (BirthdayInFutureException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            catch (BadEmailException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            catch (TooOldException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(
                           o =>
                           {
                               Refresh_data();

                           }, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname)
                && !string.IsNullOrWhiteSpace(_email) && !(_date == DateTime.MinValue);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdultte
        {
            get { return _isAdult; }
            set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }

        public string Western
        {
            get { return _western; }
            set
            {
                _western = value;
                OnPropertyChanged();
            }
        }

        public string Chinese
        {
            get { return _chinese; }
            set
            {
                _chinese = value;
                OnPropertyChanged();
            }
        }

        public bool Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
    }
}
