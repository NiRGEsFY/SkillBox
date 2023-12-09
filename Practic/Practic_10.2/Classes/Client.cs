using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Practic_10._2.Classes
{
    public class Client
    {
        public Client() 
        { 
        }
        public Client(string firstName, 
                      string secondName, 
                      string subName, 
                      string phoneNumber,
                      string passportNumber,
                      string passportSerries)
        { 
            FirstName = firstName;
            SecondName = secondName;
            SubName = subName;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
            PassportSerries = passportSerries;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string SubName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportSerries { get; set; }
        public string PassportNumber { get; set; }

        public DateTime LastChange { get; set; }
        public string NameChanger { get; set; }
        public List<string> ChangedDate { get; set; }
        public string[] ChangedProperties { get; set; }

        public override string ToString()
        {
            return String.Join(" ", FirstName,SecondName,PhoneNumber);
        }
    }
}
