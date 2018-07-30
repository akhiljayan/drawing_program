using drawing_program.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawing_program
{  
    class MainProgram
    {
        public static IDrawingService service;
        static void Main(string[] args)
        {
            var DI = new InjectInterfaces();
            service = DI.Start();
            string excecuteComand = "";
            do
            {
                string[] command = Console.ReadLine().Split(' ');
                if (service.ValidateCommand(command))
                {
                    Input input = service.FormatInput(command);
                    excecuteComand = input.Command;
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }

            } while (excecuteComand != Command.Quit);
        }
    }
}
