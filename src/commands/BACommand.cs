using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for displaying total money in the bank
    /// </summary>
    internal class BACommand : ICommand
    {
        private readonly string _bankIp;
        private readonly IBankRepository _repository;

        public BACommand(string bankIp, IBankRepository repository)
        {
            _bankIp = bankIp;
            _repository = repository;
        }
        public string Execute()
        {
            var data = _repository.Load();

            var bank = data.Banks.FirstOrDefault(b => b.BankIp == _bankIp);
            if (bank == null)
            {
                return "ER Invalid command\n";
            }

            decimal totalBalance = bank.Accounts.Sum(a => a.Balance);

            return $"BA {totalBalance}\n";
        }
    }
}
