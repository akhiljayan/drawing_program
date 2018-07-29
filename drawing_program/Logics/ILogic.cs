using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public interface ILogic
    {
        bool ValidateCommand(string[] command);

        string GetExcecutedCommand(string[] command);

        bool CreateNewCanvas(string[] command);

    }
}
