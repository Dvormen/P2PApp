using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.accounts
{
    internal class AccountNumberGenerator
    {
        public static int GetNext(Bank bank)
        {
            if (!bank.Accounts.Any())
                return 10001;

            return bank.Accounts.Max(a => a.AccountNumber) + 1;
        }
    }
}
