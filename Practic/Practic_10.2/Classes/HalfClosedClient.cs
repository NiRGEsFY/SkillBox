using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_10._2.Classes
{
    public class HalfClosedClient : Client
    {
        public HalfClosedClient() 
        { 
        }
        public HalfClosedClient(string firstName, string secondName, string subName, string phoneNumber, string passportNumber, string passportSerries) 
            : base(firstName, secondName, subName, phoneNumber, passportNumber, passportSerries)
        {
            FirstName = firstName;
            SecondName = secondName;
            SubName = subName;
            _phoneNumber = phoneNumber;
            _passportNumber = passportNumber;
            _passportSerries = passportSerries;
        }

        private string _phoneNumber;
        public string _passportSerries;
        public string _passportNumber;

        public new string FirstName { get; private set; }
        public new string SecondName { get; private set; }
        public new string SubName { get; private set; }
        public new string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != null && value != String.Empty)
                    _phoneNumber = value;
            }
        }
        public new string PassportSerries
        {
            get
            {
                string output = String.Empty;
                for (int i = 0; i < _passportSerries.Length; i++)
                {
                    output += '*';
                }
                return output;
            }
            private set { _passportSerries = value; }
        }
        public new string PassportNumber
        {
            get
            {
                string output = String.Empty;
                for (int i = 0; i < _passportNumber.Length; i++)
                {
                    output += '*';
                }
                return output;
            }
            private set { _passportNumber = value; }
        }
        public void Parse(Client user)
        {
            _passportSerries = user.PassportSerries;
            _passportNumber = user.PassportNumber;
            _phoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            SubName = user.SubName;
        }

        public override string ToString()
        {
            return String.Join(" ", FirstName, SecondName, PhoneNumber);
        }
    }
}
