using Practic12.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Interface
{
    public interface ITransition<in T>
        where T : Account
    {
        void Transition(T account, double money);
    }
}
