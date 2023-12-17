using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Interface
{
    public interface IClient
    {
        string Name {  get; }
        string Password {  get; }
        List<IAccount> Accounts { get; }
    }
}
