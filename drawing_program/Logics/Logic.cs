using Canvas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public class Logic : ILogic
    {
        private List<string> commands = new List<string>() {
            Command.CreateCanvas, Command.Line, Command.Rectangle, Command.FillColor, Command.Quit
        };

        public List<string[]> commandHistory { get; set; }

        public static ICanvasOperation canvasOpp;
        public Logic(ICanvasOperation _canvasOpp)
        {
            canvasOpp = _canvasOpp;
            commandHistory = new List<string[]>();
        }

        public bool ValidateCommand(string[] command) {
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
            else {
                return false;
            }
        }

        public string GetExcecutedCommand(string[] command) {
            return command[0].ToUpper();
        }

        public bool CreateNewCanvas(string[] command)
        {
            commandHistory.Clear();
            Canvas.Canvas canvas = new Canvas.Canvas();
            canvas.Width = Convert.ToInt32(command[1]);
            canvas.Height = Convert.ToInt32(command[2]);
            commandHistory.Add(command);
            return canvasOpp.DrawCanvas(canvas);
        }
    }
}
