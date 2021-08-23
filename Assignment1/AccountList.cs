using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{/// <summary>
 /// The AccountList class represents a list of accounts and handles the operations when dealing with 
   /// multiple accounts.
/// </summary>
    class AccountList
    {
        #region 
        // Initialization and declaration 
        private List<Account> _accountList = new List<Account>();
        #endregion

        #region METHOD
        /// <summary>
        /// To add a new account to the end of the list. This methods accepts the Account to 
        ///be added to the list as a parameter.
        /// </summary>
        /// <param name="initAccount">takes Account and add it to the list</param>
        public  void AddAccount(Account initAccount) 
        {
            _accountList.Add(initAccount);

        }
        /// <summary>
        /// Accepts an account number as a parameter and returns the Account object if it 
       /// exists in the list, returns null otherwise.
        /// </summary>
        /// <param name="initNumber">takes account number and find the account </param>
        /// <returns> account if exist else return null</returns>
        public Account FindAccount(int initNumber)
        {
            foreach (Account item in _accountList)
            {
                if (item.AccountNumber == initNumber)
                    return item;     
            }
            return null;
        }
        #endregion
    }
}
