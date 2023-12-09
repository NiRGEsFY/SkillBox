using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic11.Classes
{
    public class ManagersClient : IClient, IComparable
    {
        public ManagersClient() 
        {
            FirstName = "None";
            SecondName = "None";
            SubName = "None";
            _phoneNumber = "None";
            PassportNumber = "None";
            PassportSerries = "None";
        }
        public ManagersClient(string firstName, string secondName, string subName, 
                              string phoneNumber, string passportNumber,string passportSerries) 
        {
            FirstName = firstName;
            SecondName = secondName;
            SubName = subName;
            _phoneNumber = phoneNumber;
            PassportNumber = passportNumber;
            PassportSerries = passportSerries;
        }
        
        protected string _phoneNumber;
        public string PassportNumber { get; set; }
        public string PassportSerries { get; set; }
        public string SubName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != null || value != String.Empty)
                {
                    _phoneNumber = value;
                }
            }
        }
        public override string ToString()
        {
            return $"Имя: {FirstName}, Фамилия: {SecondName}, Телефон: {PhoneNumber}";
        }

        public int CompareTo(object o)
        {
            if (o is ManagersClient client)
                return FirstName.CompareTo(client.FirstName);
            else throw new ArgumentException("Некорректные данные");
        }
    }
}
