using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// Class for displaying total money in the bank
    /// </summary>
    internal class BACommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("BACommand");
        }
    }
}
