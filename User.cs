using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataBase
{
    public class User
    {
        public string surname;
        public string name;
        public string patronymic;
        public string login;
        public string password;

        public int day;
        public int month;
        public int year;
        public User() { } //создает пустой обьект

        public User(string _surname, string _name, string _patronymic, 
            string _login, string _password,
            int _day, int _month, int _year) //конструктор с параметрами
        {
            surname = _surname;
            name = _name;
            patronymic = _patronymic;

            login = _login;
            password = _password;

            day = _day;
            month = _month;
            year = _year;
        }
    }
}
