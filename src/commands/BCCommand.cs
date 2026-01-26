using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for displaying code of the bank
    /// </summary>
    internal class BCCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("BCCommand");
        }
    }
}
