using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practic_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            int input = 1;
            while (input > 0)
            {
                Console.WriteLine("Меню:");
                Console.Write("1 - Случайная матрица\n" +
                              "2 - Сложение матриц\n" +
                              "3 - Игра «Жизнь»\n" +
                              "0 - Выход\n" +
                              "Ввод: ");
                string textInput = Console.ReadLine();
                if (!int.TryParse(textInput, out input))
                {
                    input = 99;
                }
                Console.Clear();
                switch (input)
                {
                    case 1:
                        app.CreateMatrix();
                        app.Waiter();
                        break;
                    case 2:
                        app.UnionMatrix();
                        app.Waiter();
                        break;
                    case 3:
                        app.GameLife();
                        app.Waiter();
                        break;

                }

            }
        }
    }
}
