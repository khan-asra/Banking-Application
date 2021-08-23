using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// The Account class keeps track of customer information like their name and bank balance, and can 
    /// perform transactions like depositing or withdrawing money from the account.
    /// </summary>
    class Account
    {
        /// <summary>
        /// private fields for s_nextAccountNumber and _balance
        /// </summary>
        #region FIELD
        private static int s_nextAccountNumber;
        private double _balance;
      

       
        #endregion
      
        /// <summary>
        /// properties for the Account class
        /// </summary>

        #region PROPERTIES
        public List<Transaction> TransactionList { get; set; }
        public int AccountNumber { get; }
        public string AccountHolderName { get; set; }
        public double Balance { get { return _balance; } }
        public double AnnualIntrestRate { get; set; }
        
        #endregion


        #region CONSTRUCTORS
        /// <summary>
        /// One argument constructor that creates an account using account holder name
        /// increment the ID 
        /// </summary>
        /// <param name="initAccountHolderName">takes string value for account holder name</param>
        public Account(string initAccountHolderName)
        {
            TransactionList = new List<Transaction>();
            this.AccountNumber = s_nextAccountNumber;
            this.AccountHolderName = initAccountHolderName;
            s_nextAccountNumber++;
        }
        /// <summary>
        /// Every account will have an individual Account number
        /// 
        /// </summary>
        static Account()
        {
            s_nextAccountNumber = 100;
        }
        #endregion

        /// <summary>
        /// This method will deposit the amount of money in the account. 
        /// </summary>
        /// <param name="initDeposit"> takes double value for deposit.Deposit the value in the account </param>
        #region OTHER METHODS

        public void Deposit(double initDeposit) 
        {
            
            TransactionList.Add(new Transaction(Transaction.TransactionType.Deposit, initDeposit, DateTime.Now));
            _balance += initDeposit; 
        }
        /// <summary>
        /// This method will withdraw the money from the account
        /// </summary>
        /// <param name="initWithdraws">take double value for withdraw </param>
        /// <returns> a double value and a new balance</returns>
        public virtual double WithDraw(double initWithdraws) {
            TransactionList.Add(new Transaction ( Transaction.TransactionType.WithDraw,initWithdraws, DateTime.Now ));
             _balance -= initWithdraws;
            return _balance;

        }
        #endregion


    }
}

