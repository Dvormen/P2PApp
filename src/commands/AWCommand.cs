using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for withdrawing from an account
    /// </summary>
    internal class AWCommand : ICommand
    {
        private readonly int _accountNumber;
        private readonly string _bankIp;
        private readonly decimal _amount;
        private readonly IBankRepository _repository;

        public AWCommand(int accountNumber, string bankIp, decimal amount, IBankRepository repository)
        {
            _accountNumber = accountNumber;
            _bankIp = bankIp;
            _amount = amount;
            _repository = repository;
        }
        public void Execute()
        {
            if (_amount <= 0)
            {
                Console.WriteLine("ER Invalid command");
                return;
            }

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

            if (account.Balance < _amount)
            {
                Console.WriteLine("ER Invalid command");
                return;
            }

            account.Balance -= _amount;

            _repository.Save(data);

            Console.WriteLine("AW");
        }
    }
}
