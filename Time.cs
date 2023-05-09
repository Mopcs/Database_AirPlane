using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataBase
{
    public class Time
    {
        public string clock;

        public Time() { } //создает пустой обьект
        public Time(string clock)
        {
            this.clock = clock;
        }

        public static string Clock()
        {
            string clock;
            clock = DateTime.Now.ToString(); //возвращает время регистрации
            return clock;
        }
    }
}
