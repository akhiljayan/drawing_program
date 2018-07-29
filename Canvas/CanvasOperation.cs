using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas
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

        public bool DrawCanvas(Canvas canvas)
        {
            try
            {
                if (ClearCurrentCanvas())
                {
                    DrawCanvasBorder(canvas.Width, '╔', '═', '╗');
                    for (int i = 0; i < canvas.Height; ++i)
                    {
                        DrawCanvasBorder(canvas.Width, '║', ' ', '║');
                    }
                    DrawCanvasBorder(canvas.Width, '╚', '═', '╝');
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception e) {
                return false;
            }
        }


        private void DrawCanvasBorder(int width, char startChar, char middleChar, char endChar) {
            Console.Write(startChar);
            for (int i = 0; i < width; ++i)
            {
                Console.Write(middleChar);
            }
            Console.WriteLine(endChar);
        }
    }
}
