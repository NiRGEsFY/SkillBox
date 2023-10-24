using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Practic_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Initialization();
            app.Start();
        }
    }
}
