using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for unknown Commands
    /// </summary>
    internal class UnknownCommand : ICommand
    {
        private readonly string _input;

        public UnknownCommand(string input)
        {
            _input = input;
        }
        public void Execute()
        {
            Console.WriteLine("ER Invalid command");
        }
    }
}
