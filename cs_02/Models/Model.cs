using System;
using System.Text.RegularExpressions;
using System.Windows;
using Practice4.Exceptions;

namespace Sukhoviy02.Models
{
    public class Model
    {
        DateTime zeroTime = new DateTime(1, 1, 1);
        DateTime today = DateTime.Today;

        public void CheckEmail(string email)
        {
            string pattern =
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                throw new BadEmailException("Invalid email!");
            }
        }

        public void CheckBirthdayInFuture(DateTime date)
        {
            if (DateTime.Compare(date, DateTime.Today) > 0)
            {
                throw new BirthdayInFutureException("Birthday In Future!");
            }
        }

        public void CheckIfTooOld(DateTime date)
        {
            int age = CalculateAge(date);
            if (age > 135)
            {
                throw new TooOldException("Too old!");
            }
        }

        public int CalculateAge(DateTime date)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime today = DateTime.Today;
            TimeSpan span = today - date;
            int age = (zeroTime + span).Year - 1;

            return age;
        }

        public bool CheckForBirthday(DateTime date)
        {
            DateTime today = DateTime.Today;
            if (today.Month == date.Month && today.Day == date.Day)
            {
                MessageBox.Show("Happy birthday!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private enum WesternNames
        {
            Козерог,
            Водолей,
            Рыбы,
            Овен,
            Телец,
            Близнецы,
            Рак,
            Лев,
            Дева,
            Весы,
            Скорпион,
            Стрелец
        }

        public string WesternAstrological(DateTime date)
        {
            switch (date.Month)
            {
                case 1: return ((date.Day <= 20) ? WesternNames.Козерог : WesternNames.Водолей).ToString(); break;
                case 2: return ((date.Day <= 19) ? WesternNames.Водолей : WesternNames.Рыбы).ToString(); break;
                case 3: return ((date.Day <= 21) ? WesternNames.Рыбы : WesternNames.Овен).ToString(); break;
                case 4: return ((date.Day <= 20) ? WesternNames.Овен : WesternNames.Телец).ToString(); break;
                case 5: return ((date.Day <= 21) ? WesternNames.Телец : WesternNames.Близнецы).ToString(); break;
                case 6: return ((date.Day <= 22) ? WesternNames.Близнецы : WesternNames.Рак).ToString(); break;
                case 7: return ((date.Day <= 23) ? WesternNames.Рак : WesternNames.Лев).ToString(); break;
                case 8: return ((date.Day <= 23) ? WesternNames.Лев : WesternNames.Дева).ToString(); break;
                case 9: return ((date.Day <= 24) ? WesternNames.Дева : WesternNames.Весы).ToString(); break;
                case 10: return ((date.Day <= 23) ? WesternNames.Весы : WesternNames.Скорпион).ToString(); break;
                case 11: return ((date.Day <= 23) ? WesternNames.Скорпион : WesternNames.Стрелец).ToString(); break;
                case 12: return ((date.Day <= 22) ? WesternNames.Стрелец : WesternNames.Козерог).ToString(); break;
                default: return "Error";
            }
        }

        private enum ChineseNames
        {
            Крыса,
            Бык,
            Тигр,
            Заяц,
            Дракон,
            Змея,
            Лошадь,
            Овца,
            Обезьяна,
            Петух,
            Собака,
            Кабан
        }

        public string ChineseAstrological(DateTime date)
        {
            int year = date.Year;
            int resultNumber = (year - 4) % 12;

            switch (resultNumber)
            {
                case 0: return ChineseNames.Крыса.ToString();
                case 1: return ChineseNames.Бык.ToString();
                case 2: return ChineseNames.Тигр.ToString();
                case 3: return ChineseNames.Заяц.ToString();
                case 4: return ChineseNames.Дракон.ToString();
                case 5: return ChineseNames.Змея.ToString();
                case 6: return ChineseNames.Лошадь.ToString();
                case 7: return ChineseNames.Овца.ToString();
                case 8: return ChineseNames.Обезьяна.ToString();
                case 9: return ChineseNames.Петух.ToString();
                case 10: return ChineseNames.Собака.ToString();
                case 11: return ChineseNames.Кабан.ToString();
                default: return "Error";
            }

        }

    }
}
