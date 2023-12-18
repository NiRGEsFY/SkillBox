using Practic12.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Interface
{
    public interface IAddTransition<out T>
        where T : DepositAccount
    {
        T AddTransition(double money);
    }
}
