using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Rectangle
{
    public interface IRectangleOperation
    {
        Canvas.Canvas DrawRectangle(string[] args, Canvas.Canvas existingCanvas);

        bool ValidateRectangle(Canvas.Canvas existingCanvas, string[] args);
    }
}
