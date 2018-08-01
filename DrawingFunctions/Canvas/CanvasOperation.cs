using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Canvas
{
    public class CanvasOperation : ICanvasOperation
    {
        public bool ClearCurrentCanvas()
        {
            try
            {
                Console.Clear();
                return true;
            }
            catch (Exception e)
            {
                Console.Clear();
                return false;
            }

        }

        public Canvas DrawCanvas(string[] args)
        {
            try
            {
                ClearCurrentCanvas();
                uint width = Convert.ToUInt32(args[0]);
                uint height = Convert.ToUInt32(args[1]);
                Canvas canvas = new Canvas(width, height);
                return canvas;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        private void DrawCanvasBorder(int width, char startChar, char middleChar, char endChar)
        {
            Console.Write(startChar);
            for (int i = 0; i < width; ++i)
            {
                Console.Write(middleChar);
            }
            Console.WriteLine(endChar);
        }
    }
}
