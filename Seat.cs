using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Booking.DataBase
{
    public class Seat
    {
        public string row;
        public string boon;
        public string comfortable;

        public Seat() { } //создает пустой обьект

        public Seat(string _row, string _boon, string _comfortable) //конструктор с параметрами
        {
            row = _row;
            boon = _boon;
            comfortable = _comfortable;
        }
    }
}
