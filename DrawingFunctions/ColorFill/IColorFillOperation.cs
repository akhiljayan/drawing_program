using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.ColorFill
{
    public interface IColorFillOperation
    {

        Canvas.Canvas FillColor(string[] args, Canvas.Canvas existingCanvas);

        bool ValidateFillColor(Canvas.Canvas existingCanvas, string[] args);

    }
}
