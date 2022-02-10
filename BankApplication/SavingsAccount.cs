using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// The savings account class
    /// Inherits from account class
    /// Implements interest rate
    /// </summary>
    class SavingsAccount : Account
    {
        private decimal interestRate;
        /// <summary>
        /// Property for interest rate
        /// Throws an exception for a negative rate
        /// </summary>
        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (Decimal.Compare(value, 0) < 0)
                {
                    throw new ArithmeticException();
                }
                interestRate = value;
            }
        }
        /// <summary>
        /// Calculates the interest rate to add to the account balance
        /// </summary>
        /// <returns>The amount to add to the account balance</returns>
        public decimal CalculateInterest()
        {
            return InterestRate * Balance;
        }
        /// <summary>
        /// Constructor for savings account
        /// </summary>
        /// <param name="balance">The <see cref="decimal"/> to initialize the account with</param>
        /// <param name="interestRate">The <see cref="decimal"/> rate to credit to the account</param>
        public SavingsAccount(decimal balance, decimal interestRate) : base(balance){
            try
            {
                this.Balance = balance;
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Account cannot contain negative balance.");
            }
            try
            {
                this.InterestRate = interestRate;
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Account cannot have negative interest rate.");
            }
        }
    }
}
