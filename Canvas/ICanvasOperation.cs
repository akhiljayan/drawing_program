using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas
{
    public interface ICanvasOperation
    {
        bool ClearCurrentCanvas();

        bool DrawCanvas(Canvas canvas);
    }
}
