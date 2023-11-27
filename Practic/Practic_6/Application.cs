using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Practic_6
{
    internal class Application
    {
        string _way;
        public void Initialization()
        {
            while (true)
            {
                FileStream stream;
                Console.Clear();
                Console.Write("Укажите путь к файлу: ");
                string way = Console.ReadLine();
                try
                {
                    stream = new FileStream(way, FileMode.Open);
                    Console.WriteLine("Файл успешно открыт!");
                    _way = way;
                    stream.Close();
                    break;
                }
                catch
                {
                    Console.Write("Файл не найден, создать файл?" +
                                  "Y/N: ");
                    char answer = Console.ReadLine().First();
                    if (answer == 'Y' || answer == 'y')
                    {
                        stream = new FileStream(way, FileMode.Create);
                        Console.WriteLine("Файл успешно создан!");
                        _way = way;
                        stream.Close();
                        break;
                    }
                }
            }
        }
        public void Start()
        {
            int input = 1;
            while (input > 0)
            {
                Console.Write("Меню работы с файлом:\n" +
                              "1 - Вывести файл\n" +
                              "2 - Добавить запись\n" +
                              "0 - Выход\n" +
                              "Ввод: ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    input = 1;
                    Console.Clear();
                    Console.WriteLine("Некоректный ввод");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        ReadFile();
                        Pause();
                        break;
                    case 2:
                        WriteFile();
                        Pause();
                        break;
                }
            }
        }
        private void Pause() 
        {
            Console.Write("Для продолжения нажмите на кнопку: ");
            Console.ReadKey();
            Console.Clear();
        }
        private void ReadFile() 
        {
            using (StreamReader stream = new StreamReader(_way))
            {
                Console.WriteLine($"{String.Format("{0,4}", "Id")} | " +
                  $"{String.Format("{0,25}", "Edit time")} | " +
                  $"{String.Format("{0,30}", "Name")} | " +
                  $"{String.Format("{0,3}", "Age")} | " +
                  $"{String.Format("{0,6}", "Height")} | " +
                  $"{String.Format("{0,13}", "Date born")} | " +
                  $"{String.Format("{0,20}", "Born plase")} | ");
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] output = line.Split('#');
                    Console.WriteLine($"{String.Format("{0,4}", output[0])} | " +
                                      $"{String.Format("{0,25}", output[1])} | " +
                                      $"{String.Format("{0,30}", output[2])} | " +
                                      $"{String.Format("{0,3}", output[3])} | " +
                                      $"{String.Format("{0,6}", output[4])} | " +
                                      $"{String.Format("{0,13}", output[5])} | " +
                                      $"{String.Format("{0,20}", output[6])} | ");
                }
            }
        }
        private void WriteFile()
        {
            using (StreamWriter stream = new StreamWriter(_way,true))
            {
                string output = String.Empty;
                Console.Write("Введите Id: ");
                output += $"{Console.ReadLine()}#";
                output += $"{DateTime.Now}#";
                Console.Write("Введите ФИО: ");
                output += $"{Console.ReadLine()}#";
                Console.Write("Введите возраст: ");
                output += $"{Console.ReadLine()}#";
                Console.Write("Введите рост: ");
                output += $"{Console.ReadLine()}#";
                Console.Write("Введите Дату рождения: ");
                output += $"{Console.ReadLine()}#";
                Console.Write("Место рождения: ");
                output += $"{Console.ReadLine()}\n";
                stream.Write(output);
            }
        }
    }
}
