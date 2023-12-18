using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class DepositAccount : Account
    {
        public DepositAccount() 
        {
            this.Id = 0;
            this.Money = 0;
            this.Service = 0;
            this.Interest = 0;
        }
        public DepositAccount(ulong Id)
            :this()
        {
            this.Id = Id;
        }
        public DepositAccount(ulong id, double money) 
            : this(id)
        {
            this.Money = money;
        }
        public DepositAccount(ulong id, double money, double service) 
            : this(id, money)
        {
            this.Service = service;
        }
        public DepositAccount(ulong id, double money, double service, double interest) 
            : this(id, money, service) 
        {
            this.Interest = interest;
        }
        public double Interest { get; }
        public override string ToString()
        {
            return $"Id: {Id}, Money: {Money}, Service: {Service}, Interest: {Interest}";
        }
    }
}
