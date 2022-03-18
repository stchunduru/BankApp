using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    abstract public class Investment : Account
    {
        public Investment(string Id, string name) : base(Id, name) { }

    }
}
