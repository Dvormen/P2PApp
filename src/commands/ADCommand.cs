using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for depositing into an account
    /// </summary>
    internal class ADCommand : ICommand
    {
        private readonly int _accountNumber;
        private readonly string _bankIp;
        private readonly decimal _amount;
        private readonly IBankRepository _repository;

        public ADCommand(int accountNumber, string bankIp, decimal amount, IBankRepository repository)
        {
            _accountNumber = accountNumber;
            _bankIp = bankIp;
            _amount = amount;
            _repository = repository;
        }

        public string Execute()
        {
            if (_amount <= 0)
            {
                return "ER Deposit must be higher than 0\n";
            }

            var data = _repository.Load();

            var bank = data.Banks.FirstOrDefault(b => b.BankIp == _bankIp);
            if (bank == null)
            {
                return $"ER Bank {_bankIp} not found.\n";
            }

            var account = bank.Accounts
                .FirstOrDefault(a => a.AccountNumber == _accountNumber);

            if (account == null)
            {
                return $"ER Account {_accountNumber} not found.\n";
            }

            account.Balance += _amount;

            _repository.Save(data);
            return $"AD\n";
        }
    }
}
