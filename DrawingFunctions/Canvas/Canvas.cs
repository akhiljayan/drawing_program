using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFunctions.Canvas
{
    public class Canvas
    {
        public CanvasCell[,] Cells { get; private set; }

        public uint Width { get; private set; }

        public uint Height { get; private set; }

        public Canvas() {
        }

        public Canvas(uint width, uint height)
        {
            this.Height = height;
            this.Width = width;
            Initialize(width, height);
        }

        private void Initialize(uint width, uint height)
        {
            Cells = new CanvasCell[width, height];
            for (var i = 0; i < width; i++) {
                for (var j = 0; j < height; j++) {
                    Cells[i, j] = new CanvasCell(ContentCharacter.Empty, ' ');
                }
            }
                
        }

    }

    public struct CanvasCell
    {
        public ContentCharacter type { get; private set; }
        public char content { get; private set; }

        public CanvasCell(ContentCharacter type, char content)
        {
            this.type = type;
            this.content = content;
        }
    }

    public enum ContentCharacter
    {
        Empty,
        Line
    }

}
