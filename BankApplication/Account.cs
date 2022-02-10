using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Base account class. Initializes account balance, implements credit and debit functions.
    /// </summary>
    class Account
    {
        private decimal balance;
        /// <summary>
        /// Property for balance
        /// Throws exception for negative balance
        /// </summary>
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if(Decimal.Compare(value, 0) < 0)
                {
                    throw new ArithmeticException();
                }
                balance = value;
            }
        }
        /// <summary>
        /// Deposit an amount of money to the account
        /// </summary>
        /// <param name="amount">The <see cref="decimal"/> to add to the account balance</param>
        public virtual void Credit(decimal amount)
        {
            Balance += amount;
        }
        /// <summary>
        /// Withdraw an amount of money from the account
        /// </summary>
        /// <param name="amount">The <see cref="decimal"/> to withdraw from the account balance</param>
        public virtual void Debit(decimal amount)
        {
            if(Decimal.Compare(Balance - amount, 0) < 0)
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
            else
            {
                Balance -= amount;
            }
        }
        /// <summary>
        /// Constructor for Account
        /// </summary>
        /// <param name="balance">The <see cref="decimal"/> to intialize the account with</param>
        public Account(decimal balance)
        {
            try
            {
                this.Balance = balance;
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Account cannot contain negative balance.");
            }
        }
    }
}
