using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practic11.Classes
{
    public class ClientController
    {
        public List<ManagersClient> clients { get; set; }
        string _fileWay = string.Empty;
        public ClientController(string fileWay)
        {
            _fileWay = fileWay;
            clients = new List<ManagersClient>();
            LoadFile();
        }
        public ClientController() 
        {
            _fileWay = "Clients";
            clients = new List<ManagersClient>();
            LoadFile();
        }
        ~ClientController()
        {
            SaveFile();
        }
        private void LoadFile()
        {
            var formatter = new XmlSerializer(typeof(List<ManagersClient>));
            using (var stream = new FileStream(_fileWay, FileMode.OpenOrCreate))
            {
                clients = formatter.Deserialize(stream) as List<ManagersClient>;
            }
        }
        public void SaveFile()
        {
            var formatter = new XmlSerializer(typeof(List<ManagersClient>));
            using (var stream = new FileStream(_fileWay, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, clients);
            }
        }
        public void AddClient(ManagersClient client)
        {
            clients.Add(client);
        }
    }
}
