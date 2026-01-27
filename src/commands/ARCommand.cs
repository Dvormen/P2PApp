using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for removing account
    /// </summary>
    internal class ARCommand : ICommand
    {
        private readonly int _accountNumber;
        private readonly string _bankIp;
        private readonly IBankRepository _repository;

        public ARCommand(int accountNumber, string bankIp, IBankRepository repository)
        {
            _accountNumber = accountNumber;
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

            var account = bank.Accounts
                .FirstOrDefault(a => a.AccountNumber == _accountNumber);

            if (account == null)
            {
                return "ER Invalid command\n";
            }

            bank.Accounts.Remove(account);
            _repository.Save(data);
            return "AR\n";
        }
    }
}
