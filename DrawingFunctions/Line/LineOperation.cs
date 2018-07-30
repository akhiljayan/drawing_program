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
        public Canvas.Canvas DrawLine(string[] args, Canvas.Canvas existingCanvas)
        {
            Point point1 = new Point(Convert.ToUInt32(args[0]), Convert.ToUInt32(args[1]));
            Point point2 = new Point(Convert.ToUInt32(args[2]), Convert.ToUInt32(args[3]));
            Line lineToDraw = new Line(point1, point2);
            return DrawLineInCanvas(lineToDraw, existingCanvas);
        }

        private Canvas.Canvas DrawLineInCanvas(Line lineToDraw, Canvas.Canvas existingCanvas)
        {
            List<Point> linePoints = ProcessPoineForLine(lineToDraw);
            foreach (Point pt in linePoints)
            {
                CanvasCell content = new CanvasCell(ContentCharacter.Line, 'x');
                existingCanvas.Cells[pt.X, pt.Y] = content;
            }
            return existingCanvas;
        }


        private List<Point> ProcessPoineForLine(Line line)
        {
            List<Point> linePoints = new List<Point>();
            if (line.StartingPoint == line.EndingPoint)
            {
                linePoints.Add(line.EndingPoint);
                return linePoints;
            }
            else if (line.IsLineHorizontal)
            {
                if (line.EndingPoint.Y > line.StartingPoint.Y)
                {
                    for (var i = line.StartingPoint.Y; i <= line.EndingPoint.Y; i++)
                    {
                        linePoints.Add(new Point(line.StartingPoint.X, i));
                    }
                }
                else
                {
                    for (var i = line.StartingPoint.Y; i >= line.EndingPoint.Y; i--)
                    {
                        linePoints.Add(new Point(line.StartingPoint.X, i));
                    }
                }
            }
            else if (line.IsLineVertical)
            {
                if (line.EndingPoint.X > line.StartingPoint.X)
                {
                    for (var i = line.StartingPoint.X; i <= line.EndingPoint.X; i++)
                    {
                        linePoints.Add(new Point(i, line.StartingPoint.Y));
                    }

                }
                else
                {
                    for (var i = line.StartingPoint.X; i >= line.EndingPoint.X; i--)
                    {
                        linePoints.Add(new Point(i, line.StartingPoint.Y));
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
