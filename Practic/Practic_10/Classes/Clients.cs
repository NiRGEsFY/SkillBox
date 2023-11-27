using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practic_10.Classes
{
    public class Clients : IDisposable
    {
        string _way = String.Empty;
        private List<Client> _Clients;
        private bool disposed = false;
        /// <summary>
        /// Инициализация базового класса
        /// </summary>
        public Clients() 
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
            _way = way;
            _Clients = new List<Client>();
            InitializationClients();
        }
        /// <summary>
        /// Сохранение данных
        /// </summary>
        ~Clients()
        {
            Dispose(false);
            Console.WriteLine("Класс удалён");
            SaveClient();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            SaveClient();
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                disposed = true;
            }
        }
        /// <summary>
        /// Метод инициализирущий пользователей из ранее сохраненного файла, 
        /// если таковой был
        /// </summary>
        private void InitializationClients()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Client>));
            try
            {
                using (var file = new FileStream(_way, FileMode.Open))
                {
                    _Clients = mySerializer.Deserialize(file) as List<Client>;
                }
            }
            catch
            {
                using (var file = new FileStream(_way, FileMode.Create))
                {

                }
            }
        }
        /// <summary>
        /// Метод сохраняющий информацию о пользователях
        /// </summary>
        private void SaveClient()
        {
            List<Client> initialClient = _Clients;
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Client>));
            using (var file = new FileStream(_way, FileMode.OpenOrCreate))
            {
                mySerializer.Serialize(file, _Clients);
            }
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="Client"></param>
        public void Add(Client Client)
        {
            _Clients.Add(Client);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="Client"></param>
        public void Remove(Client Client)
        {
            _Clients.Remove(Client);
        }
        /// <summary>
        /// Передача клиентов из класса в виде списка
        /// </summary>
        /// <returns></returns>
        public List<Client> Take()
        {
            return _Clients;
        }
        /// <summary>
        /// Установка/замена списка клиентов
        /// </summary>
        /// <param name="clients"></param>
        public void Set(List<Client> clients)
        {
            _Clients = clients;
        }

    }
}
