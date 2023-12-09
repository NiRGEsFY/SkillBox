using Practic11.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        History _history;
        Role userRole;
        ClientController _client;
        public MainWindow()
        {
            _client = new ClientController();
            _history = new History();
            userRole = new Role();
            InitializeComponent();
            Login login = new Login();
            login.ShowDialog();
            userRole.Name = login.RoleList.Text;
            while (userRole.Name == string.Empty)
            {
                login = new Login();
                login.ShowDialog();
                userRole.Name = login.RoleList.Text;
            }
            if (userRole.Name == "Консультант")
            {
                HidePartOfInterface();
            }
            RefreshInfo();
        }
        public void HidePartOfInterface()
        {
            AddTabBar.Visibility = Visibility.Collapsed;
            ChangeSecondName.IsEnabled = false;
            ChangeFirstName.IsEnabled = false;
            ChangeSubName.IsEnabled = false;
            ChangePassportNumber.IsEnabled = false;
            ChangePassportSerries.IsEnabled = false;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            _history.SaveHistory();
            _client.SaveFile();
        }

        private void Button_AddNewClient(object sender, RoutedEventArgs e)
        {
            if (AddClientPassportNumber.Text == String.Empty)
            {
                Exception();
                return;
            }
            if (AddClientSerriesPassport.Text == String.Empty)
            {
                Exception();
                return;
            }
            if (AddClientPhoneNumber.Text == String.Empty)
            {
                Exception();
                return;
            }
            if (AddClientSubName.Text == String.Empty)
            {
                Exception();
                return;
            }
            if (AddClientSecondName.Text == String.Empty)
            {
                Exception();
                return;
            }
            if (AddClientFirstName.Text == String.Empty)
            {
                Exception();
                return;
            }
            ManagersClient newClient = new ManagersClient(AddClientFirstName.Text.ToString(), AddClientSecondName.Text.ToString(),
                   AddClientSubName.Text.ToString(), AddClientPhoneNumber.Text.ToString(), AddClientPassportNumber.Text.ToString(),
                   AddClientPassportNumber.Text.ToString());
            _client.AddClient(newClient);
            _history.AddPoint(userRole.Name,newClient.ToString(),"None","Добавление нового клиента");
            RefreshInfo();
        }
        private void RefreshInfo()
        {
            _client.clients.Sort();
            HistoryGrid.ItemsSource = null;
            ChangeList.ItemsSource = null;
            MainList.ItemsSource = null;
            if (userRole.Name == "Менеджер" || userRole.Name == "Администратор")
            {
                ChangeList.ItemsSource = _client.clients;
                MainList.ItemsSource = _client.clients;
            }
            else
            {
                List<ConsultantsClient> clients = new List<ConsultantsClient>();
                foreach (var item in _client.clients)
                {
                    ConsultantsClient consultClient = new ConsultantsClient();
                    consultClient.Parse(item);
                    clients.Add(consultClient);
                }
                ChangeList.ItemsSource = clients;
                MainList.ItemsSource = clients;
            }
            HistoryGrid.ItemsSource = _history.points;
        }
        private void Exception()
        {
            MessageBox.Show("Ошибка ввода данных");
        }

        private void ChangeClient(object sender, RoutedEventArgs e)
        {
            if (userRole.Name == "Менеджер" || userRole.Name == "Администратор")
            {
                ManagersClient client = new ManagersClient();
                client.FirstName = ChangeFirstName.Text;
                client.SecondName = ChangeSecondName.Text;
                client.SubName = ChangeSubName.Text;
                client.PhoneNumber = ChangePhoneNumber.Text;
                client.PassportNumber = ChangePassportNumber.Text;
                client.PassportSerries = ChangePassportSerries.Text;
                _history.AddPoint(userRole.Name, client.ToString(), ChangeList.SelectedItem.ToString(), "Изменение");
                ChangeList.SelectedItem = client;
                _client.clients = ChangeList.ItemsSource as List<ManagersClient>;
            }
            else
            {
                ManagersClient client = new ManagersClient();
                client.PhoneNumber = ChangePhoneNumber.Text;
                _history.AddPoint(userRole.Name, client.ToString(), ChangeList.SelectedItem.ToString(), "Изменение");
                ChangeList.SelectedItem = client;
                _client.clients = ChangeList.ItemsSource as List<ManagersClient>;
            }
            RefreshInfo();
        }
    }
}
