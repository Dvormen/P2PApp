using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.commands
{
    /// <summary>
    /// An interface for commands
    /// </summary>
    internal interface ICommand
    {
        void Execute();
    }
}
