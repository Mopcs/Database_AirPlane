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
            Console.WriteLine("(0) ����� �� ��������� \n" +
                                "(1) ���� ������ \n" +
                                "(2) ����� ������ \n" +
                                "(3) ��������� ������ \n" +
                                "(4) ���������� ������ \n" +
                                "(5) �������� ������ \n" +
                                "(6) ���������� ������ \n" +
                                "��� �����: ");
            _StateMenu = Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            Menu();
            int _action;
            Data[] _data = new Data[0]; //������ �������� ������ ������

            while (_StateMenu != 0)
            {
                switch (_StateMenu)
                {
                    case 0:
                        //����� ����������� ��������� ������� ������
                        Array.Clear(_data, 0, _data.Length);
                        break;
                    case 1:
                        Console.Clear();

                        //�������� ������ ����� ������
                        Console.Write("(1) ���� ������ \n" +
                            "(2) ������ �� ����� \n" +
                            "��� �����: ");

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
                        Console.ReadLine(); //�������� �������
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();

                        if (_data.Length > 0)
                        {
                            //�������� ������ ����� ������
                            Console.Write("(1) ���� ������ \n" +
                                "(2) ������ ������ \n" +
                                "��� �����: ");

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
                            Console.WriteLine("������ �����!");
                        }

                        Console.ReadLine(); //�������� �������
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
                            Console.WriteLine("������ �����!");
                        }

                        Console.ReadLine(); //�������� �������
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
                            Console.WriteLine("������ �����!");
                        }

                        Console.ReadLine(); //�������� �������
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
                            Console.WriteLine("������ �����!");
                        }

                        Console.ReadLine(); //�������� �������
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
                            Console.WriteLine("������ �����!");
                        }

                        Console.ReadLine(); //�������� �������
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("������ ���� ������� �����������");
                        Console.ReadLine(); //�������� �������
                        Console.Clear();
                        break;
                }

                Menu();
            }
        }

    }
}
