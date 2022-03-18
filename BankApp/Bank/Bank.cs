using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Bank
    {
        private string bankName;
        private List<Account> accountList;

        public Bank(string name)
        {
            bankName = name;
            accountList = new List<Account>();
        }

        public void addAccount(Account one)
        {
            if(!accountList.Any(a => a.getId() == one.getId()))
            {
                accountList.Add(one);
            }
        }

        public void deleteAccount(Account one)
        {
            var accountA = getOneAccount(one.getId());
            if (accountA != null)
            {
                accountList.Remove(accountA);
            }
            // or accountList.RemoveAll(a => a.getId() == deleteAccount.getId());
        }

        public void transferMoney(double money, Account one, Account two)
        {
            var accountA = getOneAccount(one.getId());
            var accountB = getOneAccount(two.getId());

            if (accountA != null && accountB != null)
            {
                if(accountA.withdrawMoney(money))
                {
                    accountB.addMoney(money);
                }
            }
        }

        public void addMoneyToAccount(Account one, double money)
        {
            var accountA = getOneAccount(one.getId());
            if (accountA != null)
            {
                accountA.addMoney(money);
            }
        }

        public void withdrawMoneyFromAccount(Account one, double money)
        {
            var accountA = getOneAccount(one.getId());
            if (accountA != null)
            {
                accountA.withdrawMoney(money);
            }
        }

        public Account getOneAccount(string id)
        {
            var accountA = accountList.SingleOrDefault(a => a.getId() == id);
            if (accountA != null)
            {
                return accountA;
            }
            return null;
        }

        public string getBankName()
        {
            return bankName;
        }

        public List<Account> getAccounts()
        {
            return accountList;
        }





        //Testing
        public void listOneAccount(Account one)
        {
            var accountA = accountList.SingleOrDefault(a => a.getId() == one.getId());
            if(accountA != null)
            {
                accountA.getAccountDetails();
            }
        }

        public void listAllAccounts()
        {
            foreach(Account acc in accountList)
            {
                acc.getAccountDetails();
            }
        }

    }
}
