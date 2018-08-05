using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingFunctions.Canvas;
using DrawingFunctions.Common;

namespace DrawingFunctions.Line
{
    public class LineOperation : ILineOperation
    {
        public static ICanvasOperation canvasOpp;

        public LineOperation(ICanvasOperation _canvasOpp)
        {
            canvasOpp = _canvasOpp;
        }

        public Canvas.Canvas DrawLine(string[] args, Canvas.Canvas existingCanvas)
        {
            List<Point> points = LinePoints(args);
            Point point1 = points[0];
            Point point2 = points[1];
            Line lineToDraw = new Line(point1, point2);
            return DrawLineInCanvas(lineToDraw, existingCanvas);
        }

        public Canvas.Canvas DrawLineInCanvas(Line lineToDraw, Canvas.Canvas existingCanvas)
        {
            List<Point> linePoints = ProcessPoineForLine(lineToDraw, existingCanvas.Height);
            foreach (Point pt in linePoints)
            {
                CanvasCell content = new CanvasCell(ContentCharacter.Line, 'x');
                existingCanvas.Cells[pt.X, pt.Y] = content;
            }
            return existingCanvas;
        }

        public bool ValidateLine(Canvas.Canvas existingCanvas, string[] args)
        {
            List<Point> points = LinePoints(args);
            Point point1 = points[0];
            Point point2 = points[1];
            if (canvasOpp.IsPointOutOfBounds(point1, existingCanvas) || canvasOpp.IsPointOutOfBounds(point2, existingCanvas))
            {
                Console.WriteLine("Point(s) for the line are out of Canvas.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private List<Point> LinePoints(string[] args)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(Convert.ToUInt32(args[0]), Convert.ToUInt32(args[1])));
            points.Add(new Point(Convert.ToUInt32(args[2]), Convert.ToUInt32(args[3])));
            return points;
        }

        private List<Point> ProcessPoineForLine(Line line, uint canvasHeight)
        {
            List<Point> linePoints = new List<Point>();
            uint startX = line.StartingPoint.X - 1;
            uint startY = canvasHeight - (line.StartingPoint.Y);

            uint endX = line.EndingPoint.X - 1;
            uint endY = canvasHeight - (line.EndingPoint.Y);

            if (line.StartingPoint == line.EndingPoint)
            {
                linePoints.Add(line.EndingPoint);
                return linePoints;
            }
            else if (line.IsLineVertical)
            {
                if (endY > startY)
                {
                    for (var i = startY; i <= endY; i++)
                    {
                        linePoints.Add(new Point(startX, i));
                    }
                }
                else
                {
                    for (var i = startY; i >= endY; i--)
                    {
                        linePoints.Add(new Point(startX, i));
                    }
                }
            }
            else if (line.IsLineHorizontal)
            {
                if (endX > startX)
                {
                    for (var i = startX; i <= endX; i++)
                    {
                        linePoints.Add(new Point(i, startY));
                    }

                }
                else
                {
                    for (var i = startX; i >= endX; i--)
                    {
                        linePoints.Add(new Point(i, startY));
                    }
                }
            }
            else
            {
                throw new NotImplementedException("Only horizontal and vertical lines Allowed");
            }
            return linePoints;
        }

    }
}
