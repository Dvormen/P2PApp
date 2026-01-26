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
        public void Execute()
        {
            Console.WriteLine("ADCommand");
        }
    }
}
