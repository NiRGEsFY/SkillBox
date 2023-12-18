using Practic12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic12.Classes
{
    public class Account : IAccount
    {
        public Account() 
        {
            this.Id = 0;
            this.Money = 0;
            this.Service = 0;
        }
        public Account(ulong Id) 
            : this()
        {
            this.Id = Id;
        }
        public Account(ulong id, double money) : this(id)
        {
            this.Money = money;
        }
        public Account(ulong id, double money, double service) : this(id, money)
        {
            this.Service = service;
        }

        public ulong Id { get; protected set; } 
        public double Money { get; protected set; }
        public static ulong MaxId { get; protected set; }
        public double Service { get; protected set; }
        public void Transition(double money)
        {
            if (money < 0)
                return;
            Money -= money;
        }
        public void Add(double money)
        {
            if (money < 0)
                return;
            Money += money;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Money: {Money}, Service: {Service}";
        }

    }
}
