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
        public static ICommand Create(string input)
        {
            return input.ToUpper() switch
            {
                "AB" => new ABCommand(),
                "AC" => new ACCommand(),
                "AD" => new ADCommand(),
                "AR" => new ARCommand(),
                "AW" => new AWCommand(),
                "BA" => new BACommand(),
                "BC" => new BCCommand(),
                "BN" => new BNCommand(),
                _ => new UnknownCommand(input)
            };
        }
    }
}
