using Practic_10._2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic_10._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Client> _clients = new List<Client>();
        public MainWindow()
        {
            InitializeComponent();
            var emploees = new Emploee[]
            {
                new Emploee {Post = "Consultant"},
                new Emploee {Post = "Manager"},
                new Emploee {Post = "Admin"}
            };
            EmploeePost.ItemsSource = emploees;
            EmploeePost.SelectedItem = emploees.First();
        }

        private void clientOut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RefreshContext(object sender, RoutedEventArgs e)
        {
            if (_clients == null)
            {
                clientOut.ItemsSource = null;
                return;
            }
            if (EmploeePost.Text == "Consultant")
            {
                var halfClosedClients = new List<HalfClosedClient>();
                foreach (var item in _clients)
                {
                    var halfClosedClient = new HalfClosedClient();
                    halfClosedClient.Parse(item);
                    halfClosedClients.Add(halfClosedClient);
                }
                clientOut.ItemsSource = halfClosedClients;
            }
            else
            {
                clientOut.ItemsSource = _clients;
            }
        }
        private void LoadContext(object sender, RoutedEventArgs e)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Client>));
            try
            {
                using (var file = new FileStream(FileWay.Text, FileMode.Open))
                {
                    _clients = mySerializer.Deserialize(file) as List<Client>;
                }
            }
            catch
            {
                using (var file = new FileStream(FileWay.Text, FileMode.Create))
                {

                }
            }
        }
        private void SaveContext(object sender, RoutedEventArgs e)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Client>));
            using (var file = new FileStream(FileWay.Text, FileMode.OpenOrCreate))
            {
                mySerializer.Serialize(file, _clients);
            }
        }
        private void ClearContext(object sender, RoutedEventArgs e)
        {
            clientOut.ItemsSource = null;
            _clients = null;
        }
    }
}
