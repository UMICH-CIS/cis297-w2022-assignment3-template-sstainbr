using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// The checking account class
    /// Inherits from account class
    /// Implemets transaction fees
    /// </summary>
    class CheckingAccount : Account
    {
        private decimal fee;
        /// <summary>
        /// Property for transaction fee
        /// Throws exception if the fee is negative
        /// </summary>
        public decimal Fee
        {
            get { return fee; }
            set
            {
                if (Decimal.Compare(value, 0) < 0)
                {
                    throw new ArithmeticException();
                }
                fee = value;
            }
        }
        /// <summary>
        /// Redefintes the credit function to charge the transaction fee
        /// </summary>
        /// <param name="amount">The <see cref="decimal"/> to add to the account balance</param>
        public override void Credit(decimal amount)
        {
            //Subtracts the fee from the amount to deposit before passing to the original function
            base.Credit(amount - Fee);
        }
        /// <summary>
        /// Redefines the debit function to charge the transaction fee
        /// </summary>
        /// <param name="amount">The <see cref="decimal"/> to withdraw from the account balance</param>
        public override void Debit(decimal amount)
        {
            //Adds the fee to the amount to withdraw before passing to the original function
            //This way, there's no need to return and check a bool before applying the fee
            //Just in case the fee would be the thing that would make the account balance negative
            base.Debit(amount + Fee);
        }
        /// <summary>
        /// Constructor for checking account
        /// </summary>
        /// <param name="balance">The <see cref="decimal"/> to initialize the account with</param>
        /// <param name="fee">The <see cref="decimal"/> to charge for every transaction on this account</param>
        public CheckingAccount(decimal balance, decimal fee) : base(balance)
        {
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
                this.Fee = fee;
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Account cannot have negative transaction fee.");
            }
        }
    }
}
