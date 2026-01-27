using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.accounts
{
    internal interface IBankRepository
    {
        BankStorage Load();
        void Save(BankStorage data);
    }
}
