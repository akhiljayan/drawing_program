using DrawingFunctions.Canvas;
using DrawingFunctions.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Canvas
{
    public class Canvas_Test
    {
        private readonly ICanvasOperation _canvasOpp;
        public Canvas_Test(ICanvasOperation canvasOpp)
        {
            _canvasOpp = canvasOpp;
        }

        [Fact]
        public void Should_Create_Canavs()
        {
            Random rnd = new Random();
            int width =rnd.Next(1, 160);
            int height = rnd.Next(1, 160);
            string[] args = new string[2] { width.ToString(), height.ToString() };
            var canvas = _canvasOpp.DrawCanvas(args);
            canvas.Height.ShouldBeSameAs(height);
            canvas.Width.ShouldBeSameAs(width);
        }

        [Fact]
        public void Should_CheckPoint_OutOfBound()
        {
            Random rnd = new Random();
            int width = rnd.Next(1, 25);
            int height = rnd.Next(1, 25);
            string[] args = new string[2] { width.ToString(), height.ToString() };
            var canvas = _canvasOpp.DrawCanvas(args);
            Point p = new Point(Convert.ToUInt32(rnd.Next(26, 100)), Convert.ToUInt32(rnd.Next(26, 100)));
            bool result = _canvasOpp.IsPointOutOfBounds(p,canvas);
            result.ShouldBeSameAs(true);
        }
    }
}
