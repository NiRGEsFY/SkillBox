using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic11.Classes
{
    public class ConsultantsClient : ManagersClient
    {
        protected string passportNumber;
        protected string passportSerries;
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string SubName { get; private set; }
        public string PassportNumber { 
            get 
            { 
                string output = string.Empty;
                for (int i = 0; i < passportNumber.Length; i++)
                {
                    output += '*';
                }
                return output;
            }
            private set { passportNumber = value; }
        }
        public string PassportSerries {
            get
            {
                string output = string.Empty;
                for (int i = 0; i < passportSerries.Length; i++)
                {
                    output += '*';
                }
                return output;
            }
            private set { passportSerries = value; }
        }

        public void Parse(ManagersClient client)
        {
            this.FirstName = client.FirstName;
            this.SecondName = client.SecondName;
            this.SubName = client.SubName;
            this.PassportNumber = client.PassportNumber;
            this.PassportSerries = client.PassportSerries;
            this.PhoneNumber = client.PhoneNumber;
        }
    }
}
