using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    abstract public class Account
    {
        public string accountId;
        public string accountName;
        public double accountBalance;

        public Account(string Id, string name)
        {
            accountId = Id;
            accountName = name;
            accountBalance = 0;
        }

        public void addMoney(double money)
        {
            accountBalance += money;
        }

        virtual public bool withdrawMoney(double money)
        {
            if (accountBalance - money >= 0)
            {
                accountBalance -= money;
                return true;
            }
            return false;
        }

        public string getId()
        {
            return accountId;
        }

        public string getName()
        {
            return accountName;
        }

        public double getBalance()
        {
            return accountBalance;
        }


        //Testing
        public void getAccountDetails()
        {
            Console.WriteLine(getId());
            Console.WriteLine(getName());
            Console.WriteLine(getBalance());
            Console.WriteLine();
        }

    }
}
