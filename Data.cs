using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Booking.DataBase
{ 
    internal class Data
    {
        //поля класса
        User user = new User();
        Seat seat = new Seat();
        Time time = new Time();
        Food food = new Food();

        public Data() { } //создает пустой обьект

        public Data(User _user, Seat _seat, Time time, Food food) //конструктор с параметрами
        {
            user = _user;
            seat = _seat;
            this.time = time;
            this.food = food;
        }

        public void Entry(User _user, Seat _seat, Time _time, Food _food) //ввод данных
        {
            user = _user;
            seat = _seat;
            time = _time;
            food = _food;
        }

        public void Print()
        {
            Console.WriteLine($"Логин пользователя: " + user.login);
            Console.WriteLine($"пароль пользователя: " + user.password);
            Console.WriteLine($"ФИО: " + user.surname + " " + user.name + " " + user.patronymic);
            Console.WriteLine($"Дата рождения: {user.day} {user.month} {user.year} ");
            Console.WriteLine($"Место посадки: {seat.row} {seat.boon} {seat.comfortable} ");
            Console.WriteLine($"время регистрации пользователя: {time.clock}");
        }

        public User GetUser() { return user; } // вывод из класса пользователя
        public User GetDate() { return user; } // вывод из класса пользователя даты
        public User GetLogin() { return user; } //вывод из класса пользователя логин
        public User GetPassword() { return user; } //вывод из класса пользователя пароль
        public Seat GetSeat() {  return seat; } // вывод из класса места
        public Time GetTime() { return time; } // вывод из класса время
        public Food GetFood() { return food; } // вывод из класса время

        public static void Saving(Data[] _data) //запись в файл
        {
            string FileMain;

            //Console.WriteLine("Введите название файла");
            //FileMain = Console.ReadLine();
            FileMain = "maintable.txt";

            Console.Clear();

            StreamWriter inform = new StreamWriter(FileMain, false);

            try
            {
                //если открыли без ошибок
                inform.WriteLine(_data.Length);

                foreach (Data k in _data)
                {
                    inform.WriteLine(k.GetLogin().login);
                    inform.WriteLine(k.GetPassword().password);
                    inform.WriteLine(k.GetUser().surname);
                    inform.WriteLine(k.GetUser().name);
                    inform.WriteLine(k.GetUser().patronymic);

                    inform.WriteLine(k.GetDate().day + " " + k.GetDate().month + " " + k.GetDate().year);

                    inform.WriteLine(k.GetSeat().row + " " + k.GetSeat().boon + " " + k.GetSeat().comfortable);

                    inform.WriteLine(k.GetFood().IDeat);
                    inform.WriteLine(k.GetTime().clock);
                }
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом {inform}!");
            }
            finally
            {
                inform.Close();
            }

        }
        public static void Add(ref Data[] _data) //добавление данных в массив
        {
            int NumOfAdded = _data.Length;//сколько объектов в массиве

            //временные переменные
            User user = new User();
            Seat seat = new Seat();
            Time time = new Time();
            Food food = new Food();

            //проверка на пустоту массива
            if (NumOfAdded == 0)
            {
                //выделяем новую память на объекты
                _data = new Data[NumOfAdded + 1];

                for (int i = 0; i < _data.Length; i++)
                {
                    _data[i] = new Data();
                }

                Console.Write("Введите ФИО: ");
                user.surname = Console.ReadLine();
                user.name = Console.ReadLine();
                user.patronymic = Console.ReadLine();

                Console.Write("Введите логин: ");
                user.login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                user.password = Console.ReadLine();

                Console.Write("Введите дату рождения: ");
                user.day = Convert.ToInt32(Console.ReadLine());
                user.month = Convert.ToInt32(Console.ReadLine());
                user.year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите место: ");
                seat.row = Console.ReadLine();
                seat.boon = Console.ReadLine();
                seat.comfortable = Console.ReadLine();

                Console.Write("Введите меню: ");
                Console.Write("(1) Рис с курицей \n" +
                    "(2) Макароны с говяжьими тефтелями \n" +
                    "(3) Семга с овощами \n" +
                    "(4) Бананы в карамели \n" +
                    "(5) Рататуй \n" +
                    "Ваш выбор: ");
                food.IDeat = Convert.ToInt32(Console.ReadLine());

                time.clock = Time.Clock();

                _data[NumOfAdded].Entry(user, seat, time, food); //добавляем данные
            }
            else
            {
                Data[] buf_data = (Data[])_data.Clone(); //клонируем массив, так как он очищается

                _data = new Data[NumOfAdded + 1];

                for (int i = 0; i < _data.Length; i++)
                {
                    _data[i] = new Data();
                }

                //копируем данные
                for (int j = 0; j < buf_data.Length; j++)
                {
                    _data[j] = buf_data[j];
                }

                Console.Write("Введите ФИО: ");
                user.surname = Console.ReadLine();
                user.name = Console.ReadLine();
                user.patronymic = Console.ReadLine();

                Console.Write("Введите логин: ");
                user.login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                user.password = Console.ReadLine();

                Console.Write("Введите дату рождения: ");
                user.day = Convert.ToInt32(Console.ReadLine());
                user.month = Convert.ToInt32(Console.ReadLine());
                user.year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите место: ");
                seat.row = Console.ReadLine();
                seat.boon = Console.ReadLine();
                seat.comfortable = Console.ReadLine();

                Console.Write("Введите меню: ");
                Console.Write("(1) Рис с курицей \n" +
                    "(2) Макароны с говяжьими тефтелями \n" +
                    "(3) Семга с овощами \n" +
                    "(4) Бананы в карамели \n" +
                    "(5) Рататуй \n" +
                    "Ваш выбор: ");
                food.IDeat = Convert.ToInt32(Console.ReadLine());

                time.clock = Time.Clock();

                _data[NumOfAdded].Entry(user, seat, time, food); //добавляем данные n-го элемента


                //после завершения программы удаляет временный массив
                Array.Clear(buf_data, 0, buf_data.Length);
            }
            Console.Clear();
            Console.WriteLine("Данные успешно добавлены!");     
        } //уже не нужно

        public static void Reading(ref Data[] _data) //чтение 
        {
            string FileMain;
            string FileFood;
            FileMain = "maintable.txt";
            FileFood = "food.txt";

            Console.Clear();

            StreamReader reading = new StreamReader(FileMain); //для чтения
            StreamReader ReadingFood = new StreamReader(FileFood); //для чтения

            try
            {
                //если открыли без ошибок
                int num_of_data = Convert.ToInt32(reading.ReadLine());
                int num_of_lines = 0; //номер строки, с которой считываем

                //выделяем новую память
                _data = new Data[num_of_data];
                for (int j = 0; j < _data.Length; j++)
                {
                    _data[j] = new Data();

                    _data[j].user.login = "";
                    _data[j].user.password = "";

                    _data[j].user.name = "";
                    _data[j].user.surname = "";
                    _data[j].user.patronymic = "";

                    _data[j].user.day = 0;
                    _data[j].user.year = 0;
                    _data[j].user.month = 0;

                    _data[j].seat.row = "";
                    _data[j].seat.boon = "";
                    _data[j].seat.comfortable = "";

                    _data[j].food.IDeat = 0;

                    _data[j].time.clock = "";
                }

                for (int i = 0; i < _data.Length; i++)
                {
                    //считывание информации
                    while (!reading.EndOfStream)
                    {
                        if (num_of_lines == 0)
                        {
                            _data[i].user.login = reading.ReadLine();
                            num_of_lines++;
                        }
                        else if (num_of_lines == 1)
                        {
                            _data[i].user.password = reading.ReadLine();
                            num_of_lines++;
                        }
                        else if (num_of_lines == 2)
                        {
                            _data[i].user.surname = reading.ReadLine();
                            num_of_lines++;
                        }
                        else if (num_of_lines == 3)
                        {
                            _data[i].user.name = reading.ReadLine();
                            num_of_lines++;
                        }
                        else if (num_of_lines == 4)
                        {
                            _data[i].user.patronymic = reading.ReadLine();
                            num_of_lines++;
                        }
                        else if (num_of_lines == 5)
                        {
                            string line = reading.ReadLine();
                            string[] splitline = line.Split(' ');

                            _data[i].user.day = Convert.ToInt32(splitline[0]);
                            _data[i].user.month = Convert.ToInt32(splitline[1]);
                            _data[i].user.year = Convert.ToInt32(splitline[2]);
                            num_of_lines++;
                        }
                        else if (num_of_lines == 6)
                        {
                            string line = reading.ReadLine();
                            string[] splitline = line.Split(' ');

                            _data[i].seat.row = splitline[0];
                            _data[i].seat.boon = splitline[1];
                            _data[i].seat.comfortable = splitline[2];
                            num_of_lines++;

                        }
                        else if (num_of_lines == 7)
                        {
                            int FoodLines = 0;
                            _data[i].food.IDeat = Convert.ToInt32(reading.ReadLine());
                            try
                            {
                                while (!ReadingFood.EndOfStream)
                                {
                                    if(_data[i].food.IDeat != Convert.ToInt32(ReadingFood.ReadLine()))
                                    {
                                        FoodLines++;
                                    }
                                    else
                                    {
                                        FoodLines++;
                                        _data[i].food.EatName = ReadingFood.ReadLine();
                                    }

                                }
                            }
                            catch
                            {
                                Console.WriteLine($"Ошибка при работе с файлом {ReadingFood}!");
                            }
                            finally
                            {
                                ReadingFood.Close();
                            } 
                            num_of_lines++;
                        }
                        else if (num_of_lines == 8)
                        {
                            _data[i].time.clock = reading.ReadLine();
                            _data[i].Entry(_data[i].user, _data[i].seat, _data[i].time, _data[i].food);
                            i++;
                            num_of_lines = 0;
                        }

                    }
                }
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом {reading}!");
            }
            finally
            {
                reading.Close();
            }
        }

        public static void ChangeUserInitialsAdmin(Data[] _data, string login, string _surname, string _name, string _patronymic) //меняем инициалы пользователя
        {
            int[] result = new int[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    _data[i].user.surname = _surname;
                    _data[i].user.name = _name;
                    _data[i].user.patronymic = _patronymic;
                    Saving(_data);
                    break;
                }
            }

        }

        public static void ChangeUserDateAdmin(Data[] _data, string login, int _day, int _month, int _year) //меняем дату рождения пользователя
        {
            int[] result = new int[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    _data[i].user.day = _day;
                    _data[i].user.month = _month;
                    _data[i].user.year = _year;
                    Saving(_data);
                    break;
                }
            }
        }
        
        public static void SortingInitialsAdmin(Data[] _data) //сортировка данных по фамилии
        {
            Data buf_data;
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = i + 1; j < _data.Length; j++)
                {
                    int result = String.Compare(_data[i].GetUser().surname, _data[j].GetUser().surname);
                    if (result > 0)
                    {
                        buf_data = _data[i];
                        _data[i] = _data[j];
                        _data[j] = buf_data;
                    }
                }
            }
            Saving(_data);
        }

        public static void SortingDateAdmin(Data[] _data) //сортировка данных по году
        {
            Data buf_data;
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = i + 1; j < _data.Length; j++)
                {
                    if (_data[i].GetDate().year > _data[j].GetDate().year)
                    {
                        buf_data = _data[i];
                        _data[i] = _data[j];
                        _data[j] = buf_data;
                    }
                }
            }
            Saving(_data);
        }

        public static void SortingSeatAdmin(Data[] _data) //сортировка данных по ряду в самолете
        {
            Data buf_data;
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = i + 1; j < _data.Length; j++)
                {
                    int result = String.Compare(_data[i].GetSeat().row, _data[j].GetSeat().row);
                    if (result > 0)
                    {
                        buf_data = _data[i];
                        _data[i] = _data[j];
                        _data[j] = buf_data;
                    }
                }
            }
            Saving(_data);
        }

        public static void SortingComfortSeatAdmin(Data[] _data) //сортировка данных по комфортности места
        {
            Data buf_data;
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = i + 1; j < _data.Length; j++)
                {
                    int result = String.Compare(_data[i].GetSeat().comfortable, _data[j].GetSeat().comfortable);
                    if (result > 0)
                    {
                        buf_data = _data[i];
                        _data[i] = _data[j];
                        _data[j] = buf_data;
                    }
                }
            }
            Saving(_data);
        }

        public static void UserInfo(Data[] _data, string login) //вывод информации о конкретном человеке по логину
        {
            int[] result = new int[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    _data[i].Print();
                    break;
                }
            }
        }

        //ФУНКЦИИ, КОТОРЫЕ ВЫ СКАЗАЛИ ДОБАВИТЬ
        public static void IsLoginExist(Data[] _data, string login) //существует ли такой логин в БД
        {
            int[] result = new int[_data.Length];
            int total = 0;

            for (int i = 0; i < _data.Length; i++)
            {
                total = 0;

                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    total = 1;
                    Console.WriteLine("True");
                    break;
                }
            }
            if (total == 0)
            {
                Console.WriteLine("False");
            }
        }

        public static void IsPasswordCorrect(Data[] _data, string login, string password) //существует ли связка логина и пароля в БД 
        {
            int[] resultLogin = new int[_data.Length];
            int[] resultPassword = new int[_data.Length];
            int total = 0;

            for (int i = 0; i < _data.Length; i++)
            {
                total = 0;

                string LoginCompare = _data[i].GetLogin().login;
                string PasswordCompare = _data[i].GetPassword().password;

                resultLogin[i] = Convert.ToInt32(login.Equals(LoginCompare));
                resultPassword[i] = Convert.ToInt32(password.Equals(PasswordCompare));

                if (resultLogin[i] == 1 && resultPassword[i] == 1)
                {
                    total = 1;
                    Console.WriteLine("True");
                    break;
                }
            }

            if (total == 0)
            {
                Console.WriteLine("False");
            }
        }
        public static void AddUser(ref Data[] _data,
        string _login, string _password,
        string _surname, string _name, string _patronymic,
        int _day, int _month, int _year) //добавить пользователя в БД
        {
            int NumOfAdded = _data.Length;//сколько объектов в массиве

            //временные переменные
            User user = new User();
            Seat seat = new Seat();
            Time time = new Time();
            Food food = new Food();

            //проверка на пустоту массива
            if (NumOfAdded == 0)
            {
                //выделяем новую память на объекты
                _data = new Data[NumOfAdded + 1];

                for (int i = 0; i < _data.Length; i++)
                {
                    _data[i] = new Data();
                }

                user.login = _login;
                user.password = _password;

                user.surname = _surname;
                user.name = _name;
                user.patronymic = _patronymic;

                user.day = _day;
                user.month = _month;
                user.year = _year;

                seat.row = "";
                seat.boon = "";
                seat.comfortable = "";

                food.IDeat = 0;

                time.clock = Time.Clock();

                _data[NumOfAdded].Entry(user, seat, time, food); //добавляем данные
            }
            else
            {
                Data[] buf_data = (Data[])_data.Clone(); //клонируем массив, так как он очищается

                _data = new Data[NumOfAdded + 1];

                for (int i = 0; i < _data.Length; i++)
                {
                    _data[i] = new Data();
                }

                //копируем данные
                for (int j = 0; j < buf_data.Length; j++)
                {
                    _data[j] = buf_data[j];
                }

                user.login = _login;
                user.password = _password;

                user.surname = _surname;
                user.name = _name;
                user.patronymic = _patronymic;

                user.day = _day;
                user.month = _month;
                user.year = _year;

                seat.row = "";
                seat.boon = "";
                seat.comfortable = "";


                food.IDeat = 0;

                time.clock = Time.Clock();

                _data[NumOfAdded].Entry(user, seat, time, food); //добавляем данные n-го элемента

                //после завершения программы удаляет временный массив
                Array.Clear(buf_data, 0, buf_data.Length);
            }
            Console.Clear();
            Console.WriteLine("Данные успешно добавлены!");

        }

        public static void RemoveUser(Data[] _data, string login) //удалить пользователя по логину в БД
        {
            
            Data[] buf_data = (Data[])_data.Clone();
            int[] resultLogin = new int[buf_data.Length]; // массив проверки логина

            int size2 = _data.Length - 1;
            _data = new Data[size2];

            int k = 0;

            for (int i = 0; i < buf_data.Length; i++)
            {
                string LoginCompare = buf_data[i].GetLogin().login;

                resultLogin[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (resultLogin[i] == 0)
                {
                    _data[k] = buf_data[i];
                    k++;
                }
            }

            Array.Clear(buf_data, 0, buf_data.Length);
            Saving(_data);
        }

        public static void GetUsers(ref Data[] _data) //вернуть всех пользователей, их вывод
        {
            string FileMain;
            FileMain = "maintable.txt";

            StreamReader reading = new StreamReader(FileMain);

            int i = 1;
            int strings = Convert.ToInt32(reading.ReadLine());

            foreach (Data k in _data)
            {
                if (i <= strings)
                {
                    Console.WriteLine("Данные № " + i++);
                    k.Print();
                    Console.WriteLine("____________________________________________");
                }
            }
            reading.Close();
        }

        public static void SelectSeat(Data[] _data, string login, string _row, string _boon, string _comfortable)
        //пользователю по логину передается его место
        {
            int[] result = new int[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    _data[i].seat.row = _row;
                    _data[i].seat.boon = _boon;
                    _data[i].seat.comfortable = _comfortable;
                    Saving(_data);
                    break;
                }
            }

        }

        public static void SelectMenu(Data[] _data, string login, int _IDeat)
        //пользователю по логину передается его выбор меню
        {
            int[] result = new int[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                string LoginCompare = _data[i].GetLogin().login;

                result[i] = Convert.ToInt32(login.Equals(LoginCompare));

                if (result[i] == 1)
                {
                    _data[i].food.IDeat = _IDeat;
                    Saving(_data);
                    break;
                }
            }

        }

        //ФУНКЦИИ, КОТОРЫЕ ВЫ СКАЗАЛИ ДОБАВИТЬ
    }
}
