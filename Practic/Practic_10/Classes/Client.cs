using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_10.Classes
{
    public class Client : IClient
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string SubName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSerries{ get; set; }

        public DateTime LastChange {  get; set; }
        public string NameChanger { get; set; }
        public List<string> ChangedDate { get; set; }
        public string[] ChangedProperties { get; set; }
    }
}
