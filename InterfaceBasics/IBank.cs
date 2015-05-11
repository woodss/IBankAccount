using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBasics
{
    public interface IBankAccount
    {

        //  Responses to User
        decimal GetAccountBalance();
        decimal GetOverdraftLimit();
        decimal GetAvailableBalance();

        //  Business Actions
        void PayIntoAccount(decimal amount);
        bool MakeWithdrawal(decimal amount);
        bool IncreaseOverdraft();
    }
}
