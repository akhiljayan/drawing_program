using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public class Input
    {
        public Input(string command, string[] args)
        {
            Command = command;
            Args = args;
        }

        public string Command { get; private set; }

        public string[] Args { get; private set; }

    }
}
