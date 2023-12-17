using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class BankA :ITranslation<Account>, ITranslation<DepositAccount>
    {
        List<IAccount> accounts;
        public BankA()
        {
            accounts = new List<IAccount>();
            DepositAccount account = new DepositAccount();
            Account deposit = account;
        }
        public Account Transition()
        {
            return new Account();
        }
        public DepositAccount Transition()
        {
            return new DepositAccount();
        }

    }
}
