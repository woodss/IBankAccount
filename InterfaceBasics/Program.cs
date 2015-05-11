using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBasics
{
    class Program
    {
        public static IBankAccount _myAccount;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a command (NORMAL, GOOD CREDIT, or VIP)");
            ProcessCommands(Console.ReadLine());
        }

        /// <summary>
        /// Parses commands entered into the console
        /// </summary>
        /// <param name="Command"></param>
        static void ProcessCommands(string Command)
        {
            switch (Command)
            {
                case "normal":
                    //  Start a new bank account without an overdraft
                    _myAccount = new BankAccount();
                    Console.WriteLine("Welcome Mr No Credit");
                    Console.WriteLine("Your current balance is " + _myAccount.GetAccountBalance() + " and your overdraft limit is " + _myAccount.GetOverdraftLimit());
                    break;
                case "good credit":
                    //  Start a new bank account with an overdraft
                    _myAccount = new BankAccountWithOverdraft();
                    Console.WriteLine("Welcome Mr Good Credit");
                    Console.WriteLine("Your current balance is " + _myAccount.GetAccountBalance() + " and your overdraft limit is " + _myAccount.GetOverdraftLimit());
                    break;
                case "vip":
                    //  Start a new bank account with a special surprise
                    _myAccount = new BankAccountForVIP();
                    Console.WriteLine("Welcome Mr Good Credit");
                    Console.WriteLine("Your current balance is " + _myAccount.GetAccountBalance() + " and your overdraft limit is " + _myAccount.GetOverdraftLimit());
                    break;



                //  WORKING METHODS....

                case "increase":
                    //  Upgrades an account to a new overdraft enabled account
                    var result = _myAccount.IncreaseOverdraft();
                    if (result)
                    {
                        Console.WriteLine("Congratulations!");
                        Console.WriteLine("Your new overdraft limit is " + _myAccount.GetOverdraftLimit());
                        Console.WriteLine("Your available balance is now " + _myAccount.GetAvailableBalance());
                    }
                    else
                    {
                        Console.WriteLine("Credit check failed");
                        Console.WriteLine("We could not increase your overdraft at this time");
                    }
                    break;
                case "pay in":
                    //  There should really be a check to see if we're logged in!
                    //  TODO: Check to see if we're logged in!
                    Console.WriteLine("How much do you want to pay into your account?");
                    //  TODO: Check for numeric value
                    decimal amountToPayIn = decimal.Parse(Console.ReadLine());
                    if (amountToPayIn > 0)
                    {
                        _myAccount.PayIntoAccount(amountToPayIn);
                        Console.WriteLine("Thank you - your new account balance is " + _myAccount.GetAccountBalance());
                    }
                    else
                    {
                        Console.WriteLine("You can't give me a negative amount - nice try though.");
                    }
                    break;
                case "available":
                    Console.WriteLine("Your current available balance is " + _myAccount.GetAvailableBalance());
                    break;
                case "withdraw":
                    Console.WriteLine("How much do you want to take out of your account?");
                    //  TODO: Check for numeric value
                    decimal amountToTakeOut = decimal.Parse(Console.ReadLine());
                    if (amountToTakeOut >= 0)
                    {
                        bool overdraftResult = _myAccount.MakeWithdrawal(amountToTakeOut);
                        if (overdraftResult)
                        {
                            Console.WriteLine("Thank you - your new account balance is " + _myAccount.GetAccountBalance());
                        }
                        else
                        {
                            Console.WriteLine("Sorry - the maximum amount you can withdraw is " + _myAccount.GetAvailableBalance());
                            Console.WriteLine("To apply for an overdraft, please type INCREASE");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't give me a negative amount - nice try though.");
                    }
                    break;
                default:
                    Console.WriteLine("Command not understood");
                    break;
            }
            Console.WriteLine("-----------------------");
            ProcessCommands(Console.ReadLine());
        }
    }
}
