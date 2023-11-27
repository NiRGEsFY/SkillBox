using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_10.Classes
{
    public class ClientToConsultant : IClient
    {
        public string passportSerries;
        public string passportNumber;
        public string phoneNumber;
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string SubName { get; private set; }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (value != null && value != String.Empty)
                    phoneNumber = value;
            }
        }
        public string PassportSerries
        {
            get
            {
                string output = String.Empty;
                for (int i = 0; i < passportSerries.Length;i++)
                {
                    output += '*';
                }
                return output;
            }
        }
        public string PassportNumber
        {
            get
            {
                string output = String.Empty;
                for (int i = 0; i < passportNumber.Length; i++)
                {
                    output += '*';
                }
                return output;
            }
        }
        public void Parse(Client user)
        {
            passportSerries = user.PassportSerries;
            passportNumber = user.PassportNumber;
            phoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            SubName = user.SubName;
        }
        public DateTime LastChange { get; }
        public string NameChanger { get; }
        public List<string> ChangedDate { get; }
        public string[] ChangedProperties { get; }
    }
}
