using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// This class extend the Account class but cannot be overdrawn. Any amount of money can be 
    //deposited.Override the Withdraw method to implement this limitation.
    /// </summary>
    class SavingAccount : Account
    {
        // Constant interest rate for saving 
        #region FIELDS
        public const double INTERESTRATE = 0.03;

       
        public double InterestRate { get; set; }
        #endregion
        /// <summary>
        /// Constructor that takes 
        /// </summary>
        /// <param name="initAccountHolderName"> Name of the account holder as string</param>
        /// <param name="initInterestRate">takes double value </param>
        /// <param name="initbalance">takes double value and deposit it in the account </param
        #region CONSTRUCTOR 
        public SavingAccount(string initAccountHolderName, double initInterestRate, double initbalance) : base(initAccountHolderName)
        {

            if ( initInterestRate >= INTERESTRATE)
            {
                this.AnnualIntrestRate = initInterestRate;
            }
            else
            {
                throw (new ArgumentOutOfRangeException());
            };
        
            Deposit(initbalance);
        }
       
        #endregion
        /// <summary>
        /// override the method and return a message that 
        /// </summary>saving account can not have overdraft option 
        /// <param name="initWithdraw"></param>
        /// <returns> </returns>
        #region OTHER METHOD
        public override double WithDraw(double initWithdraw)
        {
                throw (new ArgumentException("You can not WithDraw from the saving account"));
            
        }

        #endregion

    }
}
