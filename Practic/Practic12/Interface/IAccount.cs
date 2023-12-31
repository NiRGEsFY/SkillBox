﻿using Practic12.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practic12
{
    public interface IAccount
    {
        ulong Id { get; }
        double Money {  get; }
        double Service { get; }
        void Add(double money);
        void Transition(double money);
    }
}
