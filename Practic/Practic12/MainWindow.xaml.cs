using System;
using System.Collections.Generic;
using System.Linq;
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
using Practic12.Classes;
using Practic12.Interface;

namespace Practic12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Client client = new Client();
            client.DepositAccount = new DepositAccount(2,9.9,9.9,9.9);
            client.Account = new Account(1,5.5,4.1);
            client.Account = (Account)client.AddTransition(2.5);
            client.Transition(client.DepositAccount, 3.5);
            Console.WriteLine(client.Account.ToString());

            InitializeComponent();
            TextBox1.Text = client.Account.ToString();
            TextBox2.Text = client.DepositAccount.ToString();
        }
    }
}
