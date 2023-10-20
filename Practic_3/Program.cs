using System;

namespace Practic_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            int input = 1;
            while (input > 0)
            {
                Console.WriteLine("Меню:");
                Console.Write("1 - Проверка четности числа\n" +
                              "2 - Подсчёт суммы карт в игре '21'\n" +
                              "3 - Проверка простого числа\n" +
                              "4 - Найти наименьший элемент в последовательности\n" +
                              "5 - Игра 'Угадай число'\n" +
                              "0 - Выход\n" +
                              "Ввод: ");
                string textInput = Console.ReadLine();
                if (!int.TryParse(textInput, out input))
                {
                    input = 99;
                }
                Console.Clear();
                switch (input) {
                    case 1:
                        app.OddOrEven();
                        break;
                    case 2:
                        app.CounterCardsGame21();
                        break;
                    case 3:
                        app.SimpleDigit();
                        break;
                    case 4:
                        app.MinimalDigit();
                        break;
                    case 5:
                        app.GuessNumber();
                        break;

                }

            }
        }
    }
}
