using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Booking.DataBase;
using System.ComponentModel;

namespace Booking
{
    internal class Program
    {
        static int _StateMenu;
        static void Menu ()
        {
            Console.WriteLine("(0) выход из программы \n" +
                                "(1) Ввод данных \n" +
                                "(2) Вывод данных \n" +
                                "(3) Изменение данных \n" +
                                "(4) Удаление данных \n" +
                                "(5) Сортировка данных \n" +
                                "Ваш выбор: ");
            _StateMenu = Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            Menu();
            Data[] _data = new Data[0]; //массив объектов класса Данные

            while(_StateMenu != 0)
            {
                Data.Reading(ref _data);
                switch (_StateMenu)
                {
                    case 0: //выход из программы
                        //после завершения программы удаляет массив
                        Array.Clear(_data, 0, _data.Length);
                        break;
                    case 1: //Ввод данных
                        Console.Clear();
                        
                        Data.Add(ref _data);
                        Data.Saving(_data);

                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        if (_data.Length > 0)
                        {
                            Console.Clear();
                            Data.GetUsers(ref _data);
                        }
                        else
                        {
                            Console.WriteLine("Данные пусты!");
                        }

                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();

                        if (_data.Length > 0)
                        {
                            Console.WriteLine("(1) инициалы \n" +
                               "(2) дата \n" +
                               "(3) место \n" +
                               "Ваш выбор: ");
                            int _State = Convert.ToInt32(Console.ReadLine());

                            switch(_State)
                            {
                                case 1:
                                    Data.ChangeUserInitialsAdmin(_data);
                                    break;
                                case 2:
                                    Data.ChangeUserDateAdmin(_data);
                                    break;
                                case 3:
                                    Data.ChangeSeatAdmin(_data);
                                    break;
                            }
                            Data.Saving(_data);
                        }
                        else
                        {
                            Console.WriteLine("Данные пусты!");
                        }

                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();

                        if (_data.Length > 0)
                        {
                            Data.RemoveUser(_data, "");
                        }
                        else
                        {
                            Console.WriteLine("Данные пусты!");
                        }

                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();

                        if (_data.Length > 0)
                        {
                            Data.Sorting(_data);
                        }
                        else
                        {
                            Console.WriteLine("Данные пусты!");
                        }

                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Data.IsLoginExist(_data, "nika");
                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        Data.IsPasswordCorrect(_data, "60ilya", "sokola42");
                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Пункты меню выбраны неправильно");
                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                }
                Menu();
            } 
        } 
       
    } 
}
