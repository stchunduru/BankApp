using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Individual : Investment
    {
        public Individual(string Id, string name) : base(Id, name) {
        }

        override public bool withdrawMoney(double money)
        {
            if(money <= 500)
            {
                if(accountBalance - money >= 0)
                {
                    accountBalance -= money;
                    return true;
                }
            }
            return false;
        }

    }
}
