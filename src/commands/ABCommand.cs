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
        public void Execute()
        {
            Console.WriteLine("ABCommand");
        }
    }
}
