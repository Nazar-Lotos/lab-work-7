using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_7
{
    internal class Program
    {
        static List<ElectronicDevice> electronicDevices;
        static void Main(string[] args)
        {
            electronicDevices = new List<ElectronicDevice>();
            FileStream fs = new FileStream("Televisions.televisions", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);

            try
            {
                ElectronicDevice tv;
                Console.WriteLine("\tЧИТАЄМО ДАНІ З ФАЙЛУ...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    tv = new Television();
                    for (int i = 1; i <= 6; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                tv.Brand = reader.ReadString();
                                break;
                            case 2:
                                tv.Model = reader.ReadString();
                                break;
                            case 3:
                                tv.ScreenSize = reader.ReadInt32();
                                break;
                            case 4:
                                tv.Resolution = reader.ReadString();
                                break;
                            case 5:
                                tv.IsSmartTV = reader.ReadBoolean();
                                break;
                            case 6:
                                tv.SoundPower = reader.ReadInt32();
                                break;
                        }
                    }
                    electronicDevices.Add(tv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }

            Console.WriteLine("Несортований перелік телевізорів: {0}", electronicDevices.Count);
            PrintTelevisions();

            electronicDevices.Sort(); 
            Console.WriteLine("\nСортований перелік телевізорів за брендом: {0}", electronicDevices.Count);
            PrintTelevisions();

            Console.WriteLine("\nДодаємо новий запис: Samsung Q90");
            electronicDevices.Add(new Television("Samsung", "Q90", 55, "4K", true, 40));

            Console.WriteLine("\nПерелік телевізорів: {0}", electronicDevices.Count);
            PrintTelevisions();

            Console.WriteLine("\nВидаляємо останнє значення");
            electronicDevices.RemoveAt(electronicDevices.Count - 1);

            Console.WriteLine("\nПерелік телевізорів: {0}", electronicDevices.Count);
            PrintTelevisions();

            while(true) Console.ReadKey();
        }

        static void PrintTelevisions()
        {
            foreach(Television television in electronicDevices) 
            {
                Console.WriteLine(television.Info().Replace('і', 'i'));
            }
            Console.WriteLine();
        }
    }
}
