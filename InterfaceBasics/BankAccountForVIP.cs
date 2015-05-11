using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBasics
{
    class BankAccountForVIP : BankAccount
    {

        public BankAccountForVIP()
        {
            _Balance = 1000;
            _OverdraftLimit = 500;
        }

        public override bool MakeWithdrawal(decimal Amount)
        {
            if ((_Balance + _OverdraftLimit) >= Amount)
            {
                _Balance -= Amount /2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
