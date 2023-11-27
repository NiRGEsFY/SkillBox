using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_10.Classes
{
    public interface IClient
    {
        string FirstName { get; }
        string SecondName { get; }
        string SubName { get; }
        string PhoneNumber { get; }
        string PassportNumber { get; }
        string PassportSerries { get; }

        DateTime LastChange { get; }
        string NameChanger { get; }
        List<string> ChangedDate { get; }
        string[] ChangedProperties { get; }
    }
}
