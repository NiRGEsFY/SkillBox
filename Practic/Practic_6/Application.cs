using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_6
{
    internal class Application
    {
        
        public void Initialization()
        {
            while (true)
            {
                FileStream _stream;
                Console.Clear();
                Console.Write("Укажите путь к файлу: ");
                string way = Console.ReadLine();
                try
                {
                    _stream = new FileStream(way, FileMode.Open);
                    Console.WriteLine("Файл успешно открыт!");
                    break;
                }
                catch
                {
                    Console.Write("Файл не найден, создать файл?" +
                                  "Y/N: ");
                    char answer = Console.ReadLine().First();
                    if (answer == 'Y' || answer == 'y')
                    {
                        _stream = new FileStream(way, FileMode.Create);
                        Console.WriteLine("Файл успешно создан!");
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
                        Pause();
                        break;
                }
            }
            _stream.Close();
        }
        private void Pause() 
        {
            Console.Write("Для продолжения нажмите на кнопку: ");
            Console.ReadKey();
        }
        private void ReadFile() 
        {
            byte[] buffer = new byte[_stream.Length];
            _stream.Read(buffer, 0, buffer.Length);
            string output = Encoding.Default.GetString(buffer);
            Console.WriteLine(output);
        }
    }
}
