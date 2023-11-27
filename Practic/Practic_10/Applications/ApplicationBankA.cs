using Practic_10.Classes;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Practic_10.Applications
{
    public class ApplicationBankA : IDisposable
    {
        Clients _Clients = new Clients();
        string _ClientPost = String.Empty;
        private bool disposed = false;
        /// <summary>
        /// Инициализация базового класса с ролью пользователя
        /// </summary>
        /// <param name="role"></param>
        public ApplicationBankA(Role role)
        {
            _ClientPost = role.RoleName;
        }
        ~ApplicationBankA()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _Clients.Dispose();
                disposed = true;
            }
        }
        /// <summary>
        /// Создание случайного слова
        /// </summary>
        private string CreateRandomWord()
        {
            Thread.Sleep(1);
            string output = String.Empty;
            Random random = new Random();
            int lenght = random.Next(0, 15);
            for (int i = 0; i < lenght; i++)
            {
                output += (char)random.Next(97, 122);
            }
            return output;
        }
        /// <summary>
        /// Создание случайного номера телефона
        /// </summary>
        private string CreateRandomPhoneNumber()
        {
            string output = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                output += (char)random.Next(96, 122);
            }
            return output;
        }
        /// <summary>
        /// Добавление в список случайного пользователя
        /// </summary>
        public void InitialRandomClient()
        {
            var newClient = new Client();
            newClient.FirstName = CreateRandomWord();
            newClient.SecondName = CreateRandomWord();
            newClient.SubName = CreateRandomWord();
            newClient.PassportSerries = CreateRandomWord();
            newClient.PassportNumber = CreateRandomWord();
            newClient.PhoneNumber = CreateRandomPhoneNumber();
            _Clients.Add(newClient);
        }
        /// <summary>
        /// Добавление в список случайных пользователей
        /// </summary>
        /// <param name="number"></param>
        public void InitialRandomClient(int number)
        {

            for (int i = 0; i < number; i++)
            {
                var newClient = new Client();
                newClient.FirstName = CreateRandomWord();
                newClient.SecondName = CreateRandomWord();
                newClient.SubName = CreateRandomWord();
                newClient.PassportSerries = CreateRandomWord();
                newClient.PassportNumber = CreateRandomWord();
                newClient.PhoneNumber = CreateRandomPhoneNumber();
                _Clients.Add(newClient);
            }
        }
        /// <summary>
        /// Инициализация клиента через консольы
        /// </summary>
        public void InitialClientForConsole()
        {
            if (!(_ClientPost == "Manager" || _ClientPost == "Admin"))
                return;
            var newClient = new Client();
            Console.Write("Введите Имя: ");
            newClient.FirstName = Console.ReadLine();
            Console.Write("Введите Фамилию: ");
            newClient.SecondName = Console.ReadLine();
            Console.Write("Введите Отчество: ");
            newClient.SubName = Console.ReadLine();
            Console.Write("Введите Серию Паспорта: ");
            newClient.PassportSerries = Console.ReadLine();
            Console.Write("Введите Номер Паспорта: ");
            newClient.PassportNumber = Console.ReadLine();
            Console.Write("Введите Номер Телефона: ");
            newClient.PhoneNumber = Console.ReadLine();
            _Clients.Add(newClient);
        }
        public void ClientsToConsole()
        {
            if (_ClientPost == "Admin" || _ClientPost == "Manager")
            {
                foreach (var Client in _Clients.Take())
                {
                    Console.WriteLine(String.Join("\t",Client.FirstName,Client.SecondName
                                                      ,Client.SubName,Client.PhoneNumber,
                                                      Client.PassportNumber,Client.PassportSerries));
                }
                return;
            }
            if (_ClientPost == "Consultant")
            {
                foreach (var Client in _Clients.Take())
                {
                    ClientToConsultant ClientSecond = new ClientToConsultant();
                    ClientSecond.Parse(Client);
                    Console.WriteLine(String.Join("\t", ClientSecond.FirstName, ClientSecond.SecondName
                                                          , ClientSecond.SubName, ClientSecond.PhoneNumber,
                                                          ClientSecond.PassportNumber, ClientSecond.PassportSerries));
                }
            }
        }
        /// <summary>
        /// Метод для остановки выполнения программы 
        /// Пока пользователь не нажмет на любую кнопку
        /// </summary>
        private void Waiter()
        {
            Console.Write("Нажмина на любую клавишу чтобы выйти: ");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Измение информации о клиенте
        /// Через консоль
        /// </summary>
        public void ChangeInfoClientForConsole()
        {
            var clientArray = _Clients.Take().ToArray();
            if (_ClientPost == "Admin")
            {
                for (int i = 0; i < clientArray.Length; i++)
                {
                    Console.WriteLine($"[{i}]" + String.Join("\t", clientArray[i].FirstName, clientArray[i].SecondName
                                                                 , clientArray[i].SubName, clientArray[i].PhoneNumber
                                                                 , clientArray[i].PassportNumber, clientArray[i].PassportSerries));
                }
            }
            else
            {
                for (int i = 0; i < clientArray.Length; i++)
                {
                    ClientToConsultant ClientSecond = new ClientToConsultant();
                    ClientSecond.Parse(clientArray[i]);
                    Console.WriteLine($"[{i}]" + String.Join("\t", ClientSecond.FirstName, ClientSecond.SecondName
                                                                 , ClientSecond.SubName, ClientSecond.PhoneNumber
                                                                 , ClientSecond.PassportNumber, ClientSecond.PassportSerries));
                }
            }
            Console.Write("Введите номер клиента которого хотите изменить: ");
            int inputNumberClient = 0;
            if (!int.TryParse(Console.ReadLine(), out inputNumberClient))
                return;

            if (_ClientPost == "Admin")
            {
                Console.WriteLine("Чтобы пропустить полле нажмите 'Enter'");
                string input;
                Console.Write("Введите Имя: ");
                input = Console.ReadLine();
                clientArray[inputNumberClient].ChangedDate = new List<string>();
                clientArray[inputNumberClient].ChangedProperties = new string[6];
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Имя");
                    clientArray[inputNumberClient].ChangedProperties[0] = clientArray[inputNumberClient].FirstName;
                    clientArray[inputNumberClient].FirstName = input;
                }
                Console.Write("Введите Фамилию: ");
                input = Console.ReadLine();
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Фамилия");
                    clientArray[inputNumberClient].ChangedProperties[1] = clientArray[inputNumberClient].SecondName;
                    clientArray[inputNumberClient].SecondName = input;
                }
                Console.Write("Введите Отчество: ");
                input = Console.ReadLine();
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Отчество");
                    clientArray[inputNumberClient].ChangedProperties[2] = clientArray[inputNumberClient].SubName;
                    clientArray[inputNumberClient].SubName = input;
                }
                Console.Write("Введите Телефон: ");
                input = Console.ReadLine();
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Телефон");
                    clientArray[inputNumberClient].ChangedProperties[3] = clientArray[inputNumberClient].PhoneNumber;
                    clientArray[inputNumberClient].PhoneNumber = input;
                }
                Console.Write("Введите Номер Паспорта: ");
                input = Console.ReadLine();
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Номер Паспорта");
                    clientArray[inputNumberClient].ChangedProperties[4] = clientArray[inputNumberClient].PassportNumber;
                    clientArray[inputNumberClient].PassportNumber = input;
                }
                Console.Write("Введите Серия Паспорта: ");
                input = Console.ReadLine();
                if (!(input == String.Empty || input == null))
                {
                    clientArray[inputNumberClient].NameChanger = _ClientPost;
                    clientArray[inputNumberClient].LastChange = DateTime.Now;
                    clientArray[inputNumberClient].ChangedDate.Add("Номер Паспорта");
                    clientArray[inputNumberClient].ChangedProperties[5] = clientArray[inputNumberClient].PassportSerries;
                    clientArray[inputNumberClient].PassportSerries = input;
                }
            }
            else
            {
                Console.Write("Введите Номер Телефона: ");
                clientArray[inputNumberClient].PhoneNumber = Console.ReadLine();
            }
            _Clients.Set(clientArray.ToList());
        }
        /// <summary>
        /// Метод для удобного использования программы
        /// Пользователем через консоль
        /// </summary>
        public void MenuForConsole()
        {
            while (true)
            {
                Console.WriteLine("Меню: \n" +
                                  "1 - Добавить рандомного клинета\n" +
                                  "2 - Добавить рандомных клиентов\n" +
                                  "3 - Добавить клиента\n" +
                                  "4 - Вывести клиентов\n" +
                                  "5 - Изменить клиента\n" +
                                  "0 - Выйти и сохранить\n" +
                                  "Ввод: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        InitialRandomClient();
                        Waiter();
                        break;
                    case 2:
                        Console.Write("Введите количестов клиентов: ");
                        int CountAdd = 0;
                        if (!int.TryParse(Console.ReadLine(), out CountAdd))
                            break;
                        InitialRandomClient(CountAdd);
                        Waiter();
                        break;
                    case 3:
                        InitialClientForConsole();
                        Waiter();
                        break;
                    case 4:
                        ClientsToConsole();
                        Waiter();
                        break;
                    case 5:
                        ChangeInfoClientForConsole();
                        break;
                }
            }
        }
    }
}
