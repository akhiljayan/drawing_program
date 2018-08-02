using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingFunctions.Canvas;
using DrawingFunctions.Common;

namespace DrawingFunctions.ColorFill
{
    public class ColorFillOperation : IColorFillOperation
    {
        public static ICanvasOperation canvasOpp;

        public ColorFillOperation(ICanvasOperation _canvasOpp)
        {
            canvasOpp = _canvasOpp;
        }

        public Canvas.Canvas FillColor(string[] args, Canvas.Canvas existingCanvas)
        {
            uint ptx = Convert.ToUInt32(args[0]) - 1;
            uint pty = existingCanvas.Height - (Convert.ToUInt32(args[1]));
            char colorChar = Convert.ToChar(args[2]);
            Point fillStartPoint = new Point(ptx, pty);
            return this.Fill(fillStartPoint, colorChar, existingCanvas);
        }

        private Canvas.Canvas Fill(Point fillStartPoint, char colorChar, Canvas.Canvas existingCanvas)
        {
            char contentToFill = existingCanvas.Cells[fillStartPoint.X, fillStartPoint.Y].content;

            List<Point> pointsFilled = new List<Point>();
            Queue<Point> pointsToFill = new Queue<Point>();
            pointsToFill.Enqueue(fillStartPoint);

            while(pointsToFill.Count > 0)
            {
                Point currentPoint = pointsToFill.Dequeue();
                pointsFilled.Add(currentPoint);
                if (existingCanvas.Cells[currentPoint.X, currentPoint.Y].content == contentToFill)
                {
                    existingCanvas.Cells[currentPoint.X, currentPoint.Y] = new CanvasCell( ContentCharacter.Line, colorChar);

                    Point leftPoint = new Point(currentPoint.X - 1, currentPoint.Y);
                    if (ChechIfToBeFilled(leftPoint, pointsFilled, pointsToFill, existingCanvas))
                    {
                        pointsToFill.Enqueue(leftPoint);
                    }

                    Point rightPoint = new Point(currentPoint.X + 1, currentPoint.Y);
                    if (ChechIfToBeFilled(rightPoint, pointsFilled, pointsToFill, existingCanvas))
                    {
                        pointsToFill.Enqueue(rightPoint);
                    }

                    Point topPoint = new Point(currentPoint.X, currentPoint.Y - 1);
                    if (ChechIfToBeFilled(topPoint, pointsFilled, pointsToFill, existingCanvas))
                    {
                        pointsToFill.Enqueue(topPoint);
                    }

                    Point bottomPoint = new Point(currentPoint.X, currentPoint.Y + 1);
                    if (ChechIfToBeFilled(bottomPoint, pointsFilled, pointsToFill, existingCanvas))
                    {
                        pointsToFill.Enqueue(bottomPoint);
                    }
                }
            }
            return existingCanvas;
        }

        private bool ChechIfToBeFilled(Point point, List<Point> pointsFilled, Queue<Point> pointsToFill, Canvas.Canvas existingCanvas)
        {
            return !pointsFilled.Contains(point) && !pointsToFill.Contains(point) && !canvasOpp.IsPointOutOfBounds(point, existingCanvas);
        }
    }
}
