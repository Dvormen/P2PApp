using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for adding bank
    /// </summary>
    internal class ABCommand : ICommand
    {
        private readonly int _accountNumber;
        private readonly string _bankIp;
        private readonly IBankRepository _repository;

        public ABCommand(int accountNumber, string bankIp, IBankRepository repository)
        {
            _accountNumber = accountNumber;
            _bankIp = bankIp;
            _repository = repository;
        }

        public void Execute()
        {
            var data = _repository.Load();

            var bank = data.Banks.FirstOrDefault(b => b.BankIp == _bankIp);
            if (bank == null)
            {
                Console.WriteLine("ER Invalid command");
                return;
            }

            var account = bank.Accounts
                .FirstOrDefault(a => a.AccountNumber == _accountNumber);

            if (account == null)
            {
                Console.WriteLine("ER Invalid command");
                return;
            }

            Console.WriteLine($"AB {account.Balance}");
        }
    }
}
