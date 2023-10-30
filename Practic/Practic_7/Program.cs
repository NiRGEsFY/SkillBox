using System;
using Practic_7.Applications;

namespace Practic_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            while (true)
            {
                Console.WriteLine("Меню: \n" +
                                  "1 - Добавить работника\n" +
                                  "2 - Вывести всех работников\n" +
                                  "3 - Удалить работника\n" +
                                  "4 - Вывести работника\n" +
                                  "5 - Вывести работников по дням рождения\n" +
                                  "0 - Выход\n" +
                                  "Ввод: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        app.AddWorkerFromConsole();
                        break;
                    case 2:
                        app.AllWorkerToConsole();
                        break;
                    case 3:
                        app.DeleteWorkerFromConsole();
                        break;
                    case 4:
                        app.WorkerByIdToConsole();
                        break;
                    case 5:
                        app.GetWorkersBetweenTwoDates();
                        break;
                }
            }
        }
    }
}
