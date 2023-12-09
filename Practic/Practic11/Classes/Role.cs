using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Practic11.Classes
{
    public class Role
    {
        public Role() { }
        public Role(string value)
        {
            Name = value;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
