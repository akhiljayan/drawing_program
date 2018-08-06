using DrawingFunctions.Canvas;
using DrawingFunctions.Common;
using DrawingFunctions.Line;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class Line_Test
    {

        private readonly ICanvasOperation _canvasOpp;
        private readonly ILineOperation _lineOpp;
        public Line_Test(ICanvasOperation canvasOpp, ILineOperation lineOpp)
        {
            _canvasOpp = canvasOpp;
            _lineOpp = lineOpp;
        }

        [Fact]
        public void Should_Create_Canavs_WithLine()
        {
            Random rnd = new Random();
            int width = rnd.Next(10, 100);
            int height = rnd.Next(10, 100);
            string[] args = new string[2] { width.ToString(), height.ToString() };
            var canvas = _canvasOpp.DrawCanvas(args);

            string[] lineArgs = new string[4] { "5", "4", "10", "4" };
            int lineLength = 6;
            var newcanvas = _lineOpp.DrawLine(lineArgs, canvas);
            CanvasCell content = new CanvasCell(ContentCharacter.Line, 'x');
            int count = 0;
            for (int i = 0; i <= newcanvas.Cells.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= newcanvas.Cells.GetUpperBound(1); j++)
                {
                    if (newcanvas.Cells[i, j].Equals(content))
                    {
                        count += 1;
                    }
                }
            }
            count.ShouldBeSameAs(lineLength);
        }
    }
}
