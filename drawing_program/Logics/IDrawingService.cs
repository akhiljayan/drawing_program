using DrawingFunctions.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public interface IDrawingService
    {
        bool ValidateCommand(string[] command);

        Input FormatInput(string[] command);

        bool ExcecuteCommand(Input input);

        string GetExcecutedCommand(string[] command);

        string GetFinalCanvasAsString();

    }
}
