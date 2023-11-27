using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practic_10.Applications;
using Practic_10.Classes;

namespace Practic_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Role role = new Role();
            Console.WriteLine("Введите роль пользователя.\nДоступные роли: Manager, Consultant, Admin");
            Console.Write("Ввод: ");
            role.RoleName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Меню: \n" +
                                  "1 - Задание 1,2,3\n" +
                                  "2 - Задание видео\n" +
                                  "3 - Изменить роль\n" +
                                  "0 - Выйти и сохранить\n" +
                                  "Ввод: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        using (ApplicationBankA app = new ApplicationBankA(role))
                        {
                            app.MenuForConsole();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        using (ApplicationBankA app = new ApplicationBankA(role))
                        {
                            app.MenuForConsole();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите роль пользователя.\n\"Доступные роли: Manager, Consultant, Admin\"");
                        Console.Write("Ввод: ");
                        role.RoleName = Console.ReadLine();
                        break;
                }
            }
        }
    }
}
