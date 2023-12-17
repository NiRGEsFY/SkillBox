using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class DepositAccount : IAccount
    {
        public double Interest {  get; }
        public ulong Id { get; }
        public double Money { get; private set; }
        public double Service { get; }
        public void Translation(double money, IAccount account)
        {
            if ((this.Money - money) < 0)
                return;
            if (account == null)
                return;
            if (account.Id != this.Id)
                return;
            this.Money -= money;
            account.Add(money);
        }
        public void Add(double money)
        {
            this.Money += money;
        }
    }
}
