using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingFunctions.Canvas;

namespace DrawingFunctions.Line
{
    public interface ILineOperation
    {
        Canvas.Canvas DrawLine(string[] args, Canvas.Canvas existingCanvas);

        Canvas.Canvas DrawLineInCanvas(Line lineToDraw, Canvas.Canvas existingCanvas);
    }
}
