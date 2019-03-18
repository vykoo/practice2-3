using System;

namespace Sukhoviy02.Models
{
    public class Person
    {
        Model Model = new Model();

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date = DateTime.Today;

        public Person(string name, string surname, string email, DateTime date)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Date = date;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime date)
        {
            Name = name;
            Surname = surname;
            Date = date;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
            }
        }

        public bool IsAdult
        {
            get { return Model.CalculateAge(Date) >= 18; }
        }

        public string SunSign
        {
            get { return Model.WesternAstrological(Date); }
        }

        public string ChineseSign
        {
            get { return Model.ChineseAstrological(Date); }
        }

        public bool IsBirthday
        {
            get { return Model.CheckForBirthday(Date); }
        }

    }
}