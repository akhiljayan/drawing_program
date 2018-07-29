using drawing_program.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program
{
    class Program
    {
        public static ILogic logic;
        static void Main(string[] args)
        {
            var DI = new InjectInterfaces();
            logic = DI.Start();
            string excecuteComand = "";
            do
            {
                string[] command = Console.ReadLine().Split(' ');
                if (logic.ValidateCommand(command))
                {
                    excecuteComand = logic.GetExcecutedCommand(command);
                    DoOperation(excecuteComand, command);
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }

            } while (excecuteComand != Command.Quit);
        }

        private static void DoOperation(string excecuteComand, string[] command) {
            switch (excecuteComand) {
                case Command.CreateCanvas:
                    logic.CreateNewCanvas(command);
                    break;
            }
        }



    }
}
