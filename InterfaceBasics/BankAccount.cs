using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBasics
{
    public class BankAccount : IBankAccount
    {
        protected decimal _Balance { get; set; }
        protected decimal _OverdraftLimit { get; set; }

        public BankAccount()
        {
            _Balance = 0;   //  Set initial balance
            _OverdraftLimit = 0;
        }

        //  

        public decimal GetAccountBalance()
        {
            return _Balance;
        }

        public decimal GetOverdraftLimit()
        {
            return _OverdraftLimit;
        }

        public decimal GetAvailableBalance()
        {
            return _Balance + _OverdraftLimit;
        }

        public void PayIntoAccount(decimal Amount)
        {
            if (Amount > 0)
            {
                _Balance += Amount;
            }
        }



        //  Make a withdrawal from our bank
        public virtual bool MakeWithdrawal(decimal Amount)
        {
            if ((_Balance + _OverdraftLimit) >= Amount)
            {
                _Balance -= Amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        //  Increase Overdraft
        public virtual bool IncreaseOverdraft()
        {
            return false;
        }
    }
}
