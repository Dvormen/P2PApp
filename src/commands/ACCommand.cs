using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for creating an account
    /// </summary>
    internal class ACCommand : ICommand
    {
        private readonly string _bankIp;
        private readonly IBankRepository _repository;

        public ACCommand(string bankIp, IBankRepository repository)
        {
            _bankIp = bankIp;
            _repository = repository;
        }
        public string Execute()
        {
            var data = _repository.Load();

            var bank = data.Banks
                .FirstOrDefault(b => b.BankIp == _bankIp);

            if (bank == null)
            {
                bank = new Bank { BankIp = _bankIp };
                data.Banks.Add(bank);
            }

            int accountNumber = AccountNumberGenerator.GetNext(bank);

            bank.Accounts.Add(new Account
            {
                AccountNumber = accountNumber,
                Balance = 0
            });

            _repository.Save(data);

            return $"AC {accountNumber}/{_bankIp}\n";
        }
    }
}
