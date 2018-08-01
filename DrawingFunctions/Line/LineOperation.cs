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
