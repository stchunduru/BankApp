using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp;

namespace BankAppTests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void TestDeposit()
        {
            Bank testBank = new Bank("WestEastern");
            Account testAccount = new Corporate("8919", "Charles");
            testBank.addAccount(testAccount);

            var initialBalance = testBank.getOneAccount("8919").getBalance();

            testBank.addMoneyToAccount(testAccount, 500);

            var newBalance = testBank.getOneAccount("8919").getBalance();

            Assert.AreEqual(initialBalance, 0);
            Assert.AreEqual(newBalance, 500);

        }

        [TestMethod]
        public void TestWithdrawal()
        {
            Bank testBank = new Bank("EastWestern");
            Account testAccount = new Checking("8919", "Charles");
            testBank.addAccount(testAccount);

            testBank.addMoneyToAccount(testAccount, 500);
            var initialBalance = testBank.getOneAccount("8919").getBalance();

            testBank.withdrawMoneyFromAccount(testAccount, 200);
            var newBalance = testBank.getOneAccount("8919").getBalance();

            Assert.AreEqual(initialBalance, 500);
            Assert.AreEqual(newBalance, 300);
        }

        public void TestWithdrawalIndividual()
        {
            Bank testBank = new Bank("EastWestern");
            Account testAccount = new Individual("8919", "Charles");
            testBank.addAccount(testAccount);

            testBank.addMoneyToAccount(testAccount, 1000);
            var initialBalance = testBank.getOneAccount("8919").getBalance();

            testBank.withdrawMoneyFromAccount(testAccount, 600);
            var newBalance = testBank.getOneAccount("8919").getBalance();

            Assert.AreEqual(initialBalance, 1000);
            Assert.AreEqual(newBalance, 1000);
        }



        [TestMethod]
        public void TestTransfer()
        {
            Bank testBank = new Bank("CenterWestern");
            Account testAccountOne = new Checking("8919", "Charles");
            testBank.addAccount(testAccountOne);
            Account testAccountTwo = new Checking("5600", "James");
            testBank.addAccount(testAccountTwo);

            testBank.addMoneyToAccount(testAccountOne, 500);
            testBank.transferMoney(150, testAccountOne, testAccountTwo);

            var accountOneBalance = testBank.getOneAccount("8919").getBalance();
            var accountTwoBalance = testBank.getOneAccount("5600").getBalance();

            Assert.AreEqual(accountOneBalance, 350);
            Assert.AreEqual(accountTwoBalance, 150);
        }

        [TestMethod]
        public void TestDeleteAccount()
        {
            Bank testBank = new Bank("WestEastern");
            Account testAccountOne = new Corporate("8919", "Charles");
            Account testAccountTwo = new Checking("7868", "Bob");
            Account testAccountThree = new Checking("7868", "Mike");

            testBank.addAccount(testAccountOne);
            testBank.addAccount(testAccountTwo);
            testBank.addAccount(testAccountThree);

            var initialSize = testBank.getAccounts().Count;

            testBank.deleteAccount(testAccountTwo);

            var afterSize = testBank.getAccounts().Count;

            Assert.AreEqual(initialSize, 2);
            Assert.AreEqual(afterSize, 1);
        }

    }
}
