using DrawingFunctions.Canvas;
using DrawingFunctions.ColorFill;
using DrawingFunctions.Line;
using DrawingFunctions.Rectangle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public class DrawingService : IDrawingService
    {

        private List<string> commands = new List<string>() {
            Command.CreateCanvas, Command.Line, Command.Rectangle, Command.FillColor, Command.Quit
        };
        public Canvas currentCanvas;
        public static ICanvasOperation canvasOpp;
        public static ILineOperation lineOpp;
        public static IRectangleOperation rectOpp;
        public static IColorFillOperation fillOpp;


        public DrawingService(ICanvasOperation _canvasOpp, ILineOperation _lineOpp, IRectangleOperation _rectOpp, IColorFillOperation _fillOpp)
        {
            canvasOpp = _canvasOpp;
            lineOpp = _lineOpp;
            rectOpp = _rectOpp;
            fillOpp = _fillOpp;
            currentCanvas = new Canvas();
        }

        public bool ValidateCommand(string[] command)
        {
            string inputCommand = GetExcecutedCommand(command);
            if (commands.Contains(inputCommand))
            {
                switch (inputCommand)
                {
                    case Command.CreateCanvas:
                        return (command.Length == CommandParams.CreateCanvas);
                    case Command.Line:
                        return (command.Length == CommandParams.Line);
                    case Command.Rectangle:
                        return (command.Length == CommandParams.Rectangle);
                    case Command.FillColor:
                        return (command.Length == CommandParams.FillColor);
                    case Command.Quit:
                        return (command.Length == CommandParams.Quit);
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }


        public Input FormatInput(string[] command)
        {
            var cmd = command[0];
            var args = command.Skip(1).ToArray();
            return new Input(cmd, args);
        }


        public void ExcecuteCommand(Input input)
        {
            switch (input.Command.ToUpper())
            {
                case (Command.CreateCanvas):
                    currentCanvas = canvasOpp.DrawCanvas(input.Args);
                    ProcessCanvas(currentCanvas);
                    break;
                case (Command.Line):
                    currentCanvas = lineOpp.DrawLine(input.Args, currentCanvas);
                    ProcessCanvas(currentCanvas);
                    break;
                case (Command.Rectangle):
                    currentCanvas = rectOpp.DrawRectangle(input.Args, currentCanvas);
                    ProcessCanvas(currentCanvas);
                    break;
                case (Command.FillColor):
                    currentCanvas = fillOpp.FillColor(input.Args, currentCanvas);
                    ProcessCanvas(currentCanvas);
                    break;
            }
        }

        private void ProcessCanvas(Canvas canvas)
        {
            currentCanvas = canvas;
        }


        public string GetExcecutedCommand(string[] command)
        {
            return command[0].ToUpper();
        }

        public string GetFinalCanvasAsString()
        {
            uint borderWidth = currentCanvas.Width;
            uint borderheight = currentCanvas.Height;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < borderWidth+2; i++)
            {
                if (i == 0)
                {
                    stringBuilder.Append('╔');
                }
                else if (i == (borderWidth+2)-1)
                {
                    stringBuilder.Append('╗');
                }
                else
                {
                    stringBuilder.Append('═');
                }
            }
            stringBuilder.Append(Environment.NewLine);
            for (var j = 0; j < borderheight; j++)
            {
                stringBuilder.Append('║');
                for (var i = 0; i < currentCanvas.Width; i++)
                {
                    stringBuilder.Append(currentCanvas.Cells[i, j].content);
                }
                stringBuilder.Append('║');
                stringBuilder.Append(Environment.NewLine);
            }
            for (var i = 0; i < borderWidth + 2; i++)
            {
                if (i == 0)
                {
                    stringBuilder.Append('╚');
                }
                else if (i == (borderWidth+2) - 1)
                {
                    stringBuilder.Append('╝');
                }
                else
                {
                    stringBuilder.Append('═');
                }
            }

            return stringBuilder.ToString();
        }
    }
}
