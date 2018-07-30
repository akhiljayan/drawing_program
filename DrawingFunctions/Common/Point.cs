using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Common
{
    public class Point
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }

    }
}
