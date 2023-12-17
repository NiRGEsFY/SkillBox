using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class Account : IAccount, ITranslation<Account>
    {
        public ulong Id {  get; } 
        public double Money { get; private set; }
        public double Service { get; }
        public DepositAccount Transition(Account t2)
        {
            return new DepositAccount();
        }
        public void Translation(double money, IAccount account)
        {
            if ((this.Money - money) < 0)
                return;
            if (account == null)
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
