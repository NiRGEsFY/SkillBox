using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class Client : IClient
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<IAccount> Accounts { get; set; }
    }
}
