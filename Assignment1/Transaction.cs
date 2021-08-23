using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Transaction
    {/// <summary>
     /// This class should include read-only properties for the following information 
     /// Transaction Type (Widthraw/Deposit) (enum type),Amount(double), Date(DateTime)
     /// </summary>
        #region ENUM
        
        public enum TransactionType 
        { 
            WithDraw,
            Deposit 

        }
        #endregion

        #region PROPERTIES
        public double  Amount { get; }
        public DateTime Date { get;  }
        public TransactionType Type { get;  }
        #endregion
        /// <summary>
        /// constructor fo rthe transaction class 
        /// </summary>
        /// <param name="initType"> enum value withdraw,deposit</param> 
        /// <param name="initAmount">the value in double </param>
        /// <param name="initDate">date the transaction happened</param>
        #region CONSTRUCTOR 
        public Transaction(TransactionType initType, double initAmount, DateTime initDate) => 
            (Type, Amount, Date) = (initType,initAmount,initDate);

        #endregion

       

    }

}
