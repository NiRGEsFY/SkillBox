using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_5
{
    internal class Program
    {
        static string[] SplitText(string text)
        {
            var test = text.Split(' ');
            return test;
        }
        static void WordToConsole(string[] text)
        {
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
        static string[] ReverseArray(string[] text)
        {
            string buffer;
            for (int i = 0; i < text.Length/2; i++)
            {
                buffer = text[i];
                text[i] = text[text.Length - i - 1];
                text[text.Length - i - 1] = buffer;
            }
            return text;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();
            WordToConsole(SplitText(input));
            Console.ReadKey();
            WordToConsole(ReverseArray(SplitText(input)));
            Console.ReadKey();
        }
    }
}
