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

        public void Execute()
        {
            Console.WriteLine("ACCommand");
        }
    }
}
