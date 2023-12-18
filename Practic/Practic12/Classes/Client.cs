using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class Client : IClient, IAddTransition<DepositAccount>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
        public DepositAccount DepositAccount { get; set; }

        public DepositAccount AddTransition(double money)
        {
            if (money < 0)
                return this.DepositAccount;
            if (DepositAccount == null)
                return null;
            return new DepositAccount(this.DepositAccount.Id,this.DepositAccount.Money + money,this.DepositAccount.Service,this.DepositAccount.Interest);
        }
    }
}
