using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBasics
{
    class BankAccountWithOverdraft : BankAccount
    {

        public BankAccountWithOverdraft()
        {
            _OverdraftLimit = 20;
        }

        //  Increase Overdraft
        public override bool IncreaseOverdraft()
        {
            _OverdraftLimit += 100;
            return true;
        }
        
    }
}
