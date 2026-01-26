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
        public void Execute()
        {
            Console.WriteLine("ARCommand");
        }
    }
}
