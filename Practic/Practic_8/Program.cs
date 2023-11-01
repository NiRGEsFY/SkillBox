using Practic_8.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            while (true)
            {
                Console.WriteLine("Меню: \n" +
                                  "1 - Работа с листом\n" +
                                  "2 - Телефонная книга\n" +
                                  "3 - Проверка повторов\n" +
                                  "4 - Записная книга\n" +
                                  "0 - Выход\n" +
                                  "Ввод: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        app.WorkWithList();
                        break;
                    case 2:
                        app.BookOfPhone();
                        break;
                    case 3:
                        app.ReplayChecker();
                        break;
                    case 4:
                        app.NoteBookWorker();
                        break;
                }
            }
        }
    }
}
