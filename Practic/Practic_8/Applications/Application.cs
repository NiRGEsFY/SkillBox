using System;
using System.Collections.Generic;
using Practic_8.Items;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Practic_8.Applications
{
    public class Application
    {
        public Application() 
        {
            
        }
        private void AnimWaiting(int time,int count, List<string> words)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < count; i++)
            {
                foreach (string word in words)
                {
                    Console.Clear();
                    Console.WriteLine(word);
                    Thread.Sleep(time);
                }
            }
            Console.CursorVisible = true;
        }
        private void ListToConsole<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
        }
        private void FillListRndDigit(ref List<int> list, int count,int min, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(rnd.Next(min, max));
            }
        }
        private void Waiter()
        {
            Console.Write("Нажмина на любую клавишу чтобы выйти: ");
            Console.ReadKey();
            Console.Clear();
        }
        public void WorkWithList()
        {
            Console.Clear();
            Random rnd = new Random();
            var list = new List<int>();
            AnimWaiting(250,3,new List<string> { "Создание списка", "Создание списка.", "Создание списка..", "Создание списка..." });
            FillListRndDigit(ref list,100,0,100);
            Console.WriteLine("Все цифры в списке:");
            ListToConsole(list);
            Console.WriteLine("\nВсе цифры в списке после удаления:");
            list.RemoveAll(x => x > 25 && x < 50);
            ListToConsole(list);
            Console.WriteLine();
            Waiter();
        }
        private void InputBookOfPhone(ref Dictionary<string, string> bookOfPhone)
        {
            while (true)
            {
                Console.WriteLine("Для выхода введите пустую строку.");
                Console.Write("Введите номер телефона: ");
                string inputNumber = Console.ReadLine();
                if (String.IsNullOrEmpty(inputNumber))
                    return;
                Console.Write("Введите ФИО:");
                string inputFullName = Console.ReadLine();
                if (String.IsNullOrEmpty(inputFullName))
                    return;
                bookOfPhone.Add(inputNumber, inputFullName);
            }
        }
        private void FindNumberInBookOfPhone(Dictionary<string, string> bookOfPhone)
        {
            Console.Write("Поиск номера телефона.\n" +
                          "Введите номер телефона:");
            string findOfUserPhone = Console.ReadLine();
            string phoneNumber;
            if(bookOfPhone.TryGetValue(findOfUserPhone, out phoneNumber))
            {
                Console.WriteLine($"Номером телефона владеет пользователь: {phoneNumber}");
                return;
            }
            Console.WriteLine("Пользователь не найден.");
        }
        public void BookOfPhone()
        {
            Console.Clear();
            Dictionary<string, string> bookOfPhone = new Dictionary<string, string>();
            Console.WriteLine("Телефонная книга.");
            InputBookOfPhone(ref bookOfPhone);
            FindNumberInBookOfPhone(bookOfPhone);
            Waiter();
        }
        private void FillHashSet(ref HashSet<int> checker)
        {
            Console.WriteLine("Заполнение HashSet.");
            while (true)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    return;
                int digit = int.Parse(input);
                if (checker.Add(digit))
                    Console.WriteLine("Элемент добавлен в коллекцию");
                else
                    Console.WriteLine("Элемент не был добавлен в коллекцию");
            }
        }
        public void ReplayChecker()
        {
            Console.Clear();
            Console.WriteLine("Проверка повторов.");
            HashSet<int> checker = new HashSet<int>();
            FillHashSet(ref checker);
            Waiter();
        }

        private void InitializationNoteBook(ref NoteBook noteBook, string notesWay)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(NoteBook));
            try
            {
                using (var file = new FileStream(notesWay, FileMode.Open))
                {
                    noteBook = mySerializer.Deserialize(file) as NoteBook;
                }
            }
            catch 
            {
                using (var file = new FileStream(notesWay, FileMode.Create))
                {

                }
            }
        }
        private void NoteBookToConsole(NoteBook noteBook)
        {
            Console.WriteLine("Пользователи в записной книге.");
            foreach (var item in noteBook.Notes)
            {
                Console.WriteLine($"{item.FullName.FirstName} {item.FullName.LastName} {item.FullName.Surname}:\n" +
                                  $"ул.{item.Address.Street} д.{item.Address.HouseNumber} кв.{item.Address.ApartmentNumber}\n" +
                                  $"моб.{item.PhoneNumbers.MobilePhone} дом.{item.PhoneNumbers.FlatPhone}\n" +
                                  $"===");
            }
        }
        private void AddUserInNoteBook(ref NoteBook noteBook)
        {

            Console.WriteLine("Добавление пользователей в записную книгу.\n" +
                              "Для выхода введите пустую строку.");
            while (true)
            {
                Console.WriteLine("Добавление нового пользователя");
                UserNote user = new UserNote();
                string input;
                Console.Write("Введите Имя: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.FullName.FirstName = input;
                Console.Write("Введите Фамилию: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.FullName.LastName = input;
                Console.Write("Введите Отчество: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.FullName.Surname = input;
                Console.Write("Введите Улицу: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.Address.Street = input;
                Console.Write("Введите Номер дома: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.Address.HouseNumber = int.Parse(input);
                Console.Write("Введите Номер квартиры: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.Address.ApartmentNumber = int.Parse(input);
                Console.Write("Введите Мобильный Номер телефона: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.PhoneNumbers.MobilePhone = input;
                Console.Write("Введите Домашний Номер телефона: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                user.PhoneNumbers.FlatPhone = input;
                noteBook.Notes.Add(user);
            }

        }
        private void SaveNoteBook(ref NoteBook noteBook, string notesWay)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(NoteBook));
            using (var file = new FileStream(notesWay, FileMode.OpenOrCreate))
            {
                mySerializer.Serialize(file, noteBook);
            }
        }
        public void NoteBookWorker()
        {
            string notesWay = "Notes.txt";
            NoteBook noteBook = new NoteBook();
            InitializationNoteBook(ref noteBook,notesWay);
            if (noteBook.Notes != null)
                NoteBookToConsole(noteBook);

            AddUserInNoteBook(ref noteBook);
            SaveNoteBook(ref noteBook, notesWay);
            Waiter();
        }
    }
}
