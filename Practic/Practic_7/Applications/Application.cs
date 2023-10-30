using Microsoft.SqlServer.Server;
using Practic_7.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_7.Applications
{
    public class Application
    {
        Repository repository;
        public Application() 
        {
            string way;
            while (true)
            {
                FileStream stream;
                Console.Clear();
                Console.Write("Укажите путь к файлу: ");
                way = Console.ReadLine();
                try
                {
                    stream = new FileStream(way, FileMode.Open);
                    Console.WriteLine("Файл успешно открыт!");
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
                        stream.Close();
                        break;
                    }
                }
            }
            repository = new Repository(way);
        }
        public void AddWorkerFromConsole()
        {
            Worker worker = new Worker();
            Console.WriteLine("Добавление нового работника");
            Console.Write("Id: ");
            worker.Id = uint.Parse(Console.ReadLine());
            worker.CreateTime = DateTime.Now;
            Console.Write("Возраст: ");
            worker.Age = uint.Parse(Console.ReadLine());
            Console.Write("Высота: ");
            worker.Height = uint.Parse(Console.ReadLine());
            Console.Write("Дата рождения: ");
            worker.BurnTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Место рождения: ");
            worker.BurnPlace = Console.ReadLine();
            FullName fullName = new FullName();
            Console.Write("Имя: ");
            fullName.FirstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            fullName.LastName = Console.ReadLine();
            Console.Write("Отчество: ");
            fullName.Surname = Console.ReadLine();
            worker.FullName = fullName;
            repository.AddWorker(worker);
        }

        private void WorkerListToConsole(List<Worker> workerList)
        {
            Console.WriteLine(" Id || Дата создания || Возраст || Высота || Дата рождения || Место рождения");
            foreach (var worker in workerList)
            {
                Console.WriteLine($"{String.Format("{0,4}", worker.Id)}||" +
                                  $"{String.Format("{0,15}", worker.CreateTime.ToShortDateString())}||" +
                                  $"{String.Format("{0,9}", worker.Age)}||" +
                                  $"{String.Format("{0,8}", worker.Height)}||" +
                                  $"{String.Format("{0,15}", worker.BurnTime.ToShortDateString())}||" +
                                  $"{worker.BurnPlace}");
            }
        }
        public void AllWorkerToConsole()
        {
            var workerList = repository.GetAllWorkers().ToList();
            WorkerListToConsole(workerList);
        }
        public void DeleteWorkerFromConsole()
        {
            AllWorkerToConsole();
            Console.WriteLine("Введите отрицательное число для выхода");
            Console.Write("Введите Id работника которого нужно удалить: ");
            uint input;
            string temp = Console.ReadLine();
            try
            {
                if (int.Parse(temp) < 0)
                    return;
            }
            catch
            {

            }
            while (true)
            {
                if (uint.TryParse(temp, out input))
                {
                    if (repository.DeleteWorker(input))
                    {
                        Console.WriteLine("Работник успешно удален!");
                        return;
                    }
                    else
                        Console.WriteLine("Работник не найден");
                }
                else 
                    Console.WriteLine("Неверный ввод");

            }
        }
        public void WorkerByIdToConsole()
        {
            Console.WriteLine("Введите отрицательное число для выхода");
            Console.Write("Введите Id работника которого нужно показать: ");
            uint input;
            string temp  = Console.ReadLine();
            try
            {
                if (int.Parse(temp) < 0)
                    return;
            }
            catch
            {

            }
            while (true)
            {
                if (uint.TryParse(temp, out input))
                {
                    Worker worker = repository.GetWorkerById(input);
                    if (worker.Id != 0)
                    {
                        Console.WriteLine("Работник найден");
                        Console.WriteLine(string.Join(" || ",
                                                      worker.Id.ToString(),
                                                      worker.CreateTime.ToString(),
                                                      string.Join(" ", worker.FullName.FirstName,
                                                                       worker.FullName.LastName,
                                                                       worker.FullName.Surname),
                                                      worker.Age.ToString(),
                                                      worker.Height.ToString(),
                                                      worker.BurnTime.ToString(),
                                                      worker.BurnPlace.ToString()));
                        return;
                    }
                    Console.WriteLine("Работник не найден\n" +
                                      "Ввод:");
                }
                else
                    Console.Write("Неверный ввод\n" +
                                  "Ввод:");


            }
        }
        public void GetWorkersBetweenTwoDates()
        {
            Console.Write("Введите первую дату: ");
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите вторую дату: ");
            DateTime secondDate = DateTime.Parse(Console.ReadLine());
            WorkerListToConsole(repository.GetWorkersBetweenTwoDates(firstDate, secondDate).ToList());
        }
    }
}
