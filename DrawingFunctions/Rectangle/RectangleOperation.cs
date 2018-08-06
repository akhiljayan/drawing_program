using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingFunctions.Canvas;
using DrawingFunctions.Common;
using DrawingFunctions.Line;

namespace DrawingFunctions.Rectangle
{
    public class RectangleOperation : IRectangleOperation
    {
        public static ILineOperation lineOpp;
        public static ICanvasOperation canvasOpp;

        public RectangleOperation(ILineOperation _lineOpp, ICanvasOperation _canvasOpp)
        {
            lineOpp = _lineOpp;
            canvasOpp = _canvasOpp;
        }

        public Canvas.Canvas DrawRectangle(string[] args, Canvas.Canvas existingCanvas)
        {
            Rectangle RectangleToDraw = GetRectangleObjectsFromInput(args);
            return DrawRectangleInCanvas(RectangleToDraw, existingCanvas);
        }

        public bool ValidateRectangle(Canvas.Canvas existingCanvas, string[] args)
        {
            Rectangle rect = GetRectangleObjectsFromInput(args);
            if (canvasOpp.IsPointOutOfBounds(rect.TopLeft, existingCanvas)
                || canvasOpp.IsPointOutOfBounds(rect.TopRight, existingCanvas)
                || canvasOpp.IsPointOutOfBounds(rect.BottomLeft, existingCanvas)
                || canvasOpp.IsPointOutOfBounds(rect.BottomRight, existingCanvas))
            {
                Console.WriteLine("Point(s) for the Rectangle are out of Canvas.");
                return false;
            }
            else
            {
                return true;
            }
        }


        public Rectangle GetRectangleObjectsFromInput(string[] args)
        {
            Point TopLeft = new Point(Convert.ToUInt32(args[0]), Convert.ToUInt32(args[1]));
            Point BottomRight = new Point(Convert.ToUInt32(args[2]), Convert.ToUInt32(args[3]));
            Rectangle RectangleToDraw = new Rectangle(TopLeft, BottomRight);
            return RectangleToDraw;
        }

        private Canvas.Canvas DrawRectangleInCanvas(Rectangle rectangleToDraw, Canvas.Canvas existingCanvas)
        {
            List<Line.Line> rectangleLines = GetAllLinesForRectangle(rectangleToDraw);
            foreach (Line.Line line in rectangleLines)
            {
                lineOpp.DrawLineInCanvas(line, existingCanvas);
            }
            return existingCanvas;
        }

        private List<Line.Line> GetAllLinesForRectangle(Rectangle rect)
        {
            List<Line.Line> rectangleLines = new List<Line.Line>();

            rectangleLines.Add(new Line.Line(rect.TopLeft, rect.TopRight));
            rectangleLines.Add(new Line.Line(rect.TopLeft, rect.BottomLeft));
            rectangleLines.Add(new Line.Line(rect.BottomLeft, rect.BottomRight));
            rectangleLines.Add(new Line.Line(rect.BottomRight, rect.TopRight));
            return rectangleLines;
        }
    }
}
