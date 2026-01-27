using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class designed with factory pattern
    /// </summary>
    internal class CommandFactory
    {
        private static readonly IBankRepository repository = new JsonBankRepo();
        /// <summary>
        /// Method for command recognition
        /// </summary>
        /// <param name="input">user input</param>
        /// <returns></returns>
        public static ICommand Create(string input)
        {

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandCode = parts[0].ToUpper();

            return commandCode switch
            {
                "AB" => CreateAB(parts,repository),
                "AC" => new ACCommand(BankCode.GetIp(),repository),
                "AD" => CreateAD(parts),
                "AR" => CreateAR(parts,repository),
                "AW" => CreateAW(parts, repository),
                "BA" => CreateBA(parts,repository),
                "BC" => new BCCommand(),
                "BN" => CreateBN(parts,repository),
                _ => new UnknownCommand(input)
            };
        }
        /// <summary>
        /// Method for createing AD command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <returns>new AC command</returns>
        private static ICommand CreateAD(string[] parts)
        {
            if (parts.Length != 3)
                return new UnknownCommand("ER Invalid command");

            var accountIp = parts[1].Split('/');
            if (accountIp.Length != 2)
                return new UnknownCommand("ER Invalid command");

            if (!int.TryParse(accountIp[0], out int accountNumber))
                return new UnknownCommand("ER Invalid command");

            string bankIp = accountIp[1];

            if (!decimal.TryParse(parts[2], out decimal amount))
                return new UnknownCommand("ER Invalid command");

            return new ADCommand(accountNumber, bankIp, amount, repository);
        }
        /// <summary>
        /// Method for creating AW command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <param name="repository">repository for storing data</param>
        /// <returns>new AW command</returns>
        private static ICommand CreateAW(string[] parts, IBankRepository repository)
        {
            if (parts.Length != 3)
                return new UnknownCommand("ER Invalid command");

            var accountIp = parts[1].Split('/');
            if (accountIp.Length != 2)
                return new UnknownCommand("ER Invalid command");

            if (!int.TryParse(accountIp[0], out int accountNumber))
                return new UnknownCommand("ER Invalid command");

            string bankIp = accountIp[1];

            if (!decimal.TryParse(parts[2], out decimal amount))
                return new UnknownCommand("ER Invalid command");

            return new AWCommand(accountNumber, bankIp, amount, repository);
        }
        /// <summary>
        /// Method for creating AB command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <param name="repository">repository for storing data</param>
        /// <returns>new AB command</returns>
        private static ICommand CreateAB(string[] parts, IBankRepository repository)
        {
            if (parts.Length != 2)
                return new UnknownCommand("ER Invalid command");

            var accountIp = parts[1].Split('/');
            if (accountIp.Length != 2)
                return new UnknownCommand("ER Invalid command");

            if (!int.TryParse(accountIp[0], out int accountNumber))
                return new UnknownCommand("ER Invalid command");

            string bankIp = accountIp[1];

            return new ABCommand(accountNumber, bankIp, repository);
        }
        /// <summary>
        /// Method for creating AR command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <param name="repository">repository for storing data</param>
        /// <returns>new AR command</returns>
        private static ICommand CreateAR(string[] parts, IBankRepository repository)
        {
            if (parts.Length != 2)
                return new UnknownCommand("ER Invalid command");

            var accountIp = parts[1].Split('/');
            if (accountIp.Length != 2)
                return new UnknownCommand("ER Invalid command");

            if (!int.TryParse(accountIp[0], out int accountNumber))
                return new UnknownCommand("ER Invalid command");

            string bankIp = accountIp[1];

            return new ARCommand(accountNumber, bankIp, repository);
        }
        /// <summary>
        /// Method for creating BA command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <param name="repository">repository for storing data</param>
        /// <returns>new BA command</returns>
        private static ICommand CreateBA(string[] parts, IBankRepository repository)
        {
            if (parts.Length != 1)
                return new UnknownCommand("ER Invalid command");

            string bankIp = BankCode.GetIp();

            return new BACommand(bankIp, repository);
        }
        /// <summary>
        /// Method for creating BN command correctly
        /// </summary>
        /// <param name="parts">parsed user input</param>
        /// <param name="repository">repository for storing data</param>
        /// <returns>new BN command</returns>
        private static ICommand CreateBN(string[] parts, IBankRepository repository)
        {
            if (parts.Length != 1)
                return new UnknownCommand("ER Invalid command");

            string bankIp = BankCode.GetIp();

            return new BNCommand(bankIp, repository);
        }
    }
}
