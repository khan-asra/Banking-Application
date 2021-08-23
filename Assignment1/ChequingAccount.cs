using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// This class extend the Account class and has an overdraft limit of $1000: A customer can withdraw 
    ///an amount of money from the account, but only if their account total after the withdrawal won't exceed 
    ///the overdraft amount.
    /// </summary>
    class ChequingAccount : Account
    {
/// <summary>
/// Constant fields used in this class
/// </summary>
        #region FIELDS

        public const double OVERDRAFT=1000;
        public const double  INTERESTRATE = 0.01;

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Interest rate for this class
        /// </summary>
        public double InterestRate{ get; set; }

        #endregion

        /// <summary>
        ///Constructor for creating class 
        /// </summary>
        /// <param name="initAccountHolderName"> Name of the account holder as string</param>
        /// <param name="initInterestRate">takes double value </param>
        /// <param name="initbalance">takes double value and deposit it in the account </param>

        #region CONSTRUCTOR

        public ChequingAccount(string initAccountHolderName, double initInterestRate, double initbalance) : base(initAccountHolderName) {
            {

                if (initInterestRate > 0 && initInterestRate <= INTERESTRATE)
                {
                    this.AnnualIntrestRate = initInterestRate;
                }
                else
                {
                    throw (new ArgumentOutOfRangeException());
                };
               
                Deposit(initbalance);
            }
        }
        
 
        #endregion
        /// <summary>
        /// withdraw the amount from the account and if the limits exceed display a massage 
        /// </summary>
        /// <param name="initWithdraw"></param>
        /// <returns> double value </returns>
        #region OTHER METHODS
        public override double WithDraw(double initWithdraw)
        {
            if (OVERDRAFT+Balance>initWithdraw)
            {
                base.WithDraw(initWithdraw);
                return initWithdraw;
            }
            else
            {
                throw (new ArgumentOutOfRangeException("\tWithdraw amount cannot be more than balance"));
            }
  
        }
        #endregion
    }
}
