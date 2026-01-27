using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.accounts
{
    internal class Bank
    {
        public string BankIp { get; set; }
        public List<Account> Accounts { get; set; } = new();
    }
}
