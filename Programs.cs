using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Database_AirPlane.DataBase;

namespace Database_AirPlane
{
    internal class Program
    {
        static int _StateMenu;
        static void Menu()
        {
            Console.WriteLine("(0) выход из программы \n" +
                                "(1) Ввод данных \n" +
                                "(2) Вывод данных \n" +
                                "(3) Изменение данных \n" +
                                "(4) Добавление данных \n" +
                                "(5) Удаление данных \n" +
                                "(6) Сортировка данных \n" +
                                "Ваш выбор: ");
            _StateMenu = Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            Menu();
            int _action;
            Data[] _data = new Data[0]; //массив объектов класса Данные

            while (_StateMenu != 0)
            {
                switch (_StateMenu)
                {
                    case 0:
                        //после заавершения программы удаляет массив
                        Array.Clear(_data, 0, _data.Length);
                        break;
                    case 1:
                        Console.Clear();

                        //выбираем способ ввода данных
                        Console.Write("(1) Ввод данных \n" +
                            "(2) Чтение из файла \n" +
                            "Ваш выбор: ");

                        _action = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        if (_action == 1)
                        {
                            Data.Add(ref _data);
                        }
                        else
                        {
                            Data.Reading(ref _data);
                        }
                        Console.ReadLine(); //задержка консоли
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();

                        if (_data.Length > 0)
                        {
                            //выбираем способ ввода данных
                            Console.Write("(1) Ввод данных \n" +
                                "(2) Запись данных \n" +
                                "Ваш выбор: ");

                            _action = Convert.ToInt32(Console.ReadLine());

                            Console.Clear();

                            if (_action == 1)
                            {
                                Data.Conclusion(_data);
                            }
                            else
                            {
                                Data.Saving(_data);
                            }
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
                            Data.Change(_data);
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
                            Data.Add(ref _data);
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
                            Data.Delete(_data);
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
