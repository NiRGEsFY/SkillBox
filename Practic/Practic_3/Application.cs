using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_3
{
    public class Application
    {
        public void OddOrEven()
        {
            Console.Write("Введите число: ");
            string textInput = Console.ReadLine();
            int input = int.Parse(textInput);
            if (input % 2 == 0)
            {
                Console.WriteLine($"Число {input} чётное");
            }
            else
            {
                Console.WriteLine($"Число {input} нечётное");
            }
            Console.WriteLine("Нажмите на кнопку чтобы выйти.");
            Console.ReadKey();
            Console.Clear();
        }
        public void CounterCardsGame21()
        {
            Console.Write("Введите число карт на руках: ");
            string textInput = Console.ReadLine();
            int arrayLenght = int.Parse(textInput);
            if (arrayLenght > 5)
            {
                arrayLenght = 5;
            }
            int[] array = new int[arrayLenght];
            int counter = 0;
            Console.WriteLine("Валет = J\n" +
                  "Дама = Q\n" +
                  "Король = K\n" +
                  "Туз = T");
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write($"Введите номинал карт {i + 1}/{arrayLenght}: ");
                var keyInput = Console.ReadLine();
                Console.WriteLine();
                int buffer = 0;
                
                if (int.TryParse(keyInput, out buffer))
                {
                    if (buffer > 10)
                    {
                        buffer = 10;
                    }
                    else if (buffer < 0)
                    {
                        buffer = 0;
                    }
                    array[i] = buffer;
                }
                else
                {
                    switch (keyInput.First()) 
                    {
                        case 'J':
                        case 'j':
                            array[i] = 2;
                            break;
                        case 'Q':
                        case 'q':
                            array[i] = 3;
                            break;
                        case 'K':
                        case 'k':
                            array[i] = 4;
                            break;
                        case 'T':
                        case 't':
                            array[i] = 11;
                            break;
                    }
                }
            }
            while ((array.Sum() > 21) && (array.Contains(11)))
            {
                for (int i = 0; i < arrayLenght; i++)
                {
                    if (array[i] == 11)
                    {
                        array[i] = 1;
                        break;
                    }
                }
            }
            Console.WriteLine($"Количество очков: {array.Sum()}");
            Console.ReadKey();
            Console.Clear();
        }
        public void SimpleDigit()
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            int digit = int.Parse(input);
            int divider = 2;
            while (digit%divider != 0)
            {
                divider++;
            }
            if (divider == digit)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число не простое");
            }
            Console.WriteLine("Нажмите на кнопку чтобы выйти");
            Console.ReadKey();
            Console.Clear();
        }
        public void MinimalDigit()
        {
            int minDigit;
            Console.Write("Введите длинну последовательности: ");
            string textLenght = Console.ReadLine();
            int lenght = int.Parse(textLenght);
            Console.Write($"Введите число 1/{lenght}: ");
            string input = Console.ReadLine();
            minDigit = int.Parse(input);
            for (int i = 1; i < lenght; i++)
            {
                Console.Write($"Введите число {i + 1}/{lenght}: ");
                input = Console.ReadLine();
                int buffer = int.Parse(input);
                if (minDigit > buffer)
                {
                    minDigit = buffer;
                }
            }
            Console.Write($"Минимальное число в последовательности: {minDigit}\n" +
                          $"Нажмите на кнопку чтобы выйти: ");
            Console.ReadKey();
            Console.Clear();
        }
        public void GuessNumber()
        {
            Random rand = new Random();
            Console.Write("Введите максимальное число: ");
            string textLenght = Console.ReadLine();
            int lenght = int.Parse(textLenght);
            int number = rand.Next(0,lenght);
            int counter = 0;
            while (true)
            {
                counter++;
                Console.WriteLine("Чтобы выйти, введите пустую строку");
                Console.Write("Введите число: ");
                string textInput = Console.ReadLine();
                if (String.IsNullOrEmpty(textInput))
                {
                    Console.Write("Нажмите клавишу чтобы выйти: ");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                int input = int.Parse(textInput);

                if (input == number)
                {
                    Console.WriteLine($"Вы угадали число {number}\n" +
                                      $"Число попыток: {counter}");
                    Console.Write("Нажмите клавишу чтобы выйти: ");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                if (input > number)
                {
                    Console.WriteLine("Число меньше");
                }
                else
                {
                    Console.WriteLine("Число больше");
                }
            }
        }
    }
}
