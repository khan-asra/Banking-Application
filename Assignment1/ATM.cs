using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// This class implements a console user interface for the ATM. In the Main method of this class display the
    /// main menu of the application
    /// </summary>
    class ATM
    {


        //initialization and declaration  
        private static AccountList accList = new AccountList();
        static void Main(string[] args)
        {
            // will ask the user for creating a account or managing account 
            while (true)
            {
                Console.WriteLine("\n\t-----------------------MY BANK----------------------");
                Console.WriteLine("\tPlease select the from the following options.\n \tFor creating account press a \n" +
                "\tFor managing account press b \n");
                Console.Write("\t");
                string accountSwitch = Console.ReadLine().ToLower();
                accountSwitch.ToLower();
                switch (accountSwitch)
                {
                    case "a":
                        CreateAccount();
                        break;
                    case "b":

                        ManageAccount();
                        break;
                    default:
                        Console.WriteLine("\tPlease select a valid option.\n ");
                        break;
                }
            }
        }
        /// <summary>
        /// void method that create accounts
        /// ask user information and creates an  saving account or chequeing account 
        /// </summary>
        static void CreateAccount()
        {
            try
            {
                Console.WriteLine("\t------------------CREATE YOUR ACCOUNT------------------");
                Console.Write("\tEnter your name            :");
                string name = Console.ReadLine();
                Console.Write("\tEnter initial balance      :");
                double initialBalance = double.Parse(Console.ReadLine());
                if (initialBalance <= 0)
                {
                    throw new ArgumentException();
                }
                Console.WriteLine("\n\tSelect the Type of account you wish to open today.");
                Console.WriteLine("\tFor Chequing account     press a");
                Console.WriteLine("\tFor Saving account       press b ");

                Console.Write("\t");
                string userAccountChoice = Console.ReadLine().ToLower();

                Account userAccount;
                if (userAccountChoice == "a")
                {
                    Console.WriteLine("\tThe maximum annual interest rate allowed for the Chequing account is 1%");

                    try
                    {
                        Console.Write("\tEnter Annual Interest Rate (0-0.01):");

                        double annualInterestRate = double.Parse(Console.ReadLine());
                        userAccount = new ChequingAccount(name, annualInterestRate, initialBalance);
                        
                        Console.WriteLine("\n\t------------YOUR ACCOUNT HAS BEEN CREATED----------------");
                        accList.AddAccount(userAccount);
                        DisplayInfo(userAccount);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ErrorMessage();
                    }
                }
                if (userAccountChoice == "b")
                {
                    Console.WriteLine("\tThe minimum annual interest rate allowed for the Saving account is 3%.");
                    try
                    {
                        Console.Write("\tEnter Annual Interest Rate :");
                        double annualInterestRate = double.Parse(Console.ReadLine());
                        userAccount = new SavingAccount(name, annualInterestRate, initialBalance);
                        accList.AddAccount(userAccount);
                        DisplayInfo(userAccount);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ErrorMessage();
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\tPlease enter the numeric values for balance and Interest rate");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\t Not a  valid Number");
            }


        }



        /// <summary>
        /// Manage Account option when selected, the user will be prompted to enter their account number.
        ///  If the Account number is entered incorrectly then print an error message and ask for the number again.
        /// </summary>
        static void ManageAccount()
        {
            Console.WriteLine("\t------------------MANAGE ACCOUNT------------------");

            Account accountFind;
            try
            {
                Console.Write("\tPlease enter the account number : ");
                int accountNumber = int.Parse(Console.ReadLine());

                accountFind = accList.FindAccount(accountNumber);
                if (accountFind is null)
                {
                    throw (new FormatException());
                }
                Menu(accountFind);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\tNo such account found! ");

            }
        }

        /// <summary>
        /// This method is used to display menu optins to the users
        /// view account information, make a deposit , withdraw money and view the transaction made 
        /// </summary>
        /// <param name="acct">takes account pbject as a parament</param>
        static void Menu(Account acct)
        {
            bool flag = true;
            while (flag)
                try
                {
                    Console.WriteLine("\n\t------------------YOUR ACCOUNT------------------");
                    Console.WriteLine($"\tHello, {acct.AccountHolderName} Good day !");
                    Console.WriteLine("\t What would you like to do today ");
                    Console.WriteLine("\t To view your Account information      Press 1");
                    Console.WriteLine("\t To make a Deposit                     Press 2");
                    Console.WriteLine("\t To WithDraw                           Press 3");
                    Console.WriteLine("\t To Transaction press                  Press 4");
                    Console.WriteLine("\t To go back to the Main menu press     Press 5 \n\t");
                    Console.Write("\n\t");
                    int userChoice = int.Parse(Console.ReadLine());

                    if (userChoice == 1)
                    {
                        DisplayInfo(acct);
                    }
                    else if (userChoice == 2)
                    {
                        Console.WriteLine("\tPlease enter the amount you wish to deposit today");

                        Console.Write("\n\t");
                        double deposit = double.Parse(Console.ReadLine());
                        acct.Deposit(deposit);
                        Console.WriteLine("\tAmount has been deposited successfully ");
                    }
                    else if (userChoice == 3)
                    {
                        Console.WriteLine("\tPlease enter the amount you wish to WithDraw today");
                        Console.Write("\n\t");
                        double withdraw = double.Parse(Console.ReadLine());
                        acct.WithDraw(withdraw);
                        Console.WriteLine("\tAmount has been withdrawn successfully ");
                    }
                    else if (userChoice == 4)
                    {
                        foreach (Transaction item in acct.TransactionList)
                        {
                            Console.WriteLine("\t------------------CURRENT TRANSACTION ------------------");

                            Console.WriteLine("\tType  : " + item.Type);
                            Console.WriteLine("\tDate  : " + item.Date);
                            Console.WriteLine("\tAmount: " + item.Amount);
                            Console.WriteLine("\t--------------------------------------------------------\n");

                        }
                    }
                    else if (userChoice == 5)
                    {
                        flag = false;
                    }
                    else
                    {
                        throw (new FormatException());
                    }

                }

                catch (FormatException)
                {
                    Console.WriteLine("\tPlease select the correct option. Use numeric key ");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\tOverDraft limit exceed. ");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\tYou can not withdraw from a Saving account");
                }
        }


        /// <summary>
        /// this method is used to display the user details when it is needed.
        /// I created this method to avoid code repetation.
        /// </summary>
        /// <param name="userAccount"></param>
        static void DisplayInfo(Account userAccount)
        {
            Console.WriteLine("\t---------------------YOUR ACCOUNT-----------------------");
            Console.WriteLine("\tName                 : " + userAccount.AccountHolderName);
            Console.WriteLine("\tID                   : " + userAccount.AccountNumber);
            Console.WriteLine("\tBalance              : " + userAccount.Balance);
            Console.WriteLine("\tAnnual Interest Rate : " + userAccount.AnnualIntrestRate *100);
        }

        /// <summary>
        /// this method will be called when user input is not 
        /// in the range of interest rate.
        /// 
        /// </summary>

        static void ErrorMessage()
        {
            Console.WriteLine("\t------------------------ATTENTION-------------------------------");
            Console.WriteLine("\n\tNOTE :Your account has not been created. Please try again\n");
            Console.WriteLine("\n\tInterest rate is not in the given range ");
            Console.WriteLine("\t------------------------**********------------------------------\n");
        }



    }
    


}
