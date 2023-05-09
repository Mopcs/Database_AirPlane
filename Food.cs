using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataBase
{
    public class Food
    {
        public int IDeat;
        public string EatName;

        public Food() { } //создает пустой обьект

        public Food(int _IDeat, string _EatName) //конструктор с параметрами
        {
            IDeat = _IDeat;
            EatName = _EatName;
        }
    }
}
