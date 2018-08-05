using DrawingFunctions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Canvas
{
    public interface ICanvasOperation
    {
        bool ClearCurrentCanvas();

        Canvas DrawCanvas(string[] args);

        bool IsPointOutOfBounds(Point point, Canvas existingCanvas);

        bool ValidateCanvas(Canvas currentCanvas,string[] args);
    }
}
