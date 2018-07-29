using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program.Logics
{
    public class Command
    {
        public const string CreateCanvas = "C";
        public const string Line = "L";
        public const string Rectangle = "R";
        public const string FillColor = "B";
        public const string Quit = "Q";
    }

    public class CommandParams
    {
        public const int CreateCanvas = 3;
        public const int Line = 5;
        public const int Rectangle = 5;
        public const int FillColor = 4;
        public const int Quit = 1;
    }
}
