using DrawingFunctions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Rectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; private set; }
        public Point TopRight { get; private set; }
        public Point BottomRight { get; private set; }
        public Point BottomLeft { get; private set; }

        public Rectangle(Point TopLeft, Point BottomRight)
        {
            this.TopLeft = TopLeft;
            TopRight = new Point(BottomRight.X, TopLeft.Y);
            this.BottomRight = BottomRight;
            BottomLeft = new Point(TopLeft.X, BottomRight.Y);
        }
    }
}
