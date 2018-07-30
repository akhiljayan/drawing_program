using DrawingFunctions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Line
{
    public class Line
    {
        public Point StartingPoint { get; private set; }
        public Point EndingPoint { get; private set; }

        public Line(Point StartingPoint, Point EndingPoint)
        {
            this.StartingPoint = StartingPoint;
            this.EndingPoint = EndingPoint;
        }

        public bool IsLineHorizontal {
            get {
                return (StartingPoint.Y == EndingPoint.Y);
            }
        }

        public bool IsLineVertical
        {
            get
            {
                return (StartingPoint.X == EndingPoint.X);
            }
        }
    }
}
