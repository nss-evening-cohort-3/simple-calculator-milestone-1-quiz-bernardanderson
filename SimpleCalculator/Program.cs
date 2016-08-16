using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentCommandCount = 0, firstInteger, secondInteger;
            char userOperation;
            string userInputFromCommandPrompt;

            // Creates a new instance of the Expressions class to give non-static access to the methods
            Expressions newUserCalcInstance = new Expressions();

            while (true)
            {
                Console.Write($"[{ currentCommandCount }]> ");
                userInputFromCommandPrompt = Console.ReadLine();

                if (newUserCalcInstance.CheckUserWantsToExit(userInputFromCommandPrompt)) // Checks to see if the user typed "exit" or "quit" and, if so, breaks out of the loop
                {
                    Console.WriteLine("Bye!!!");
                    break;
                }

                currentCommandCount++;

                if (newUserCalcInstance.CheckExpressionType(userInputFromCommandPrompt).Value)
                {
                }
                else
                {
                    Console.WriteLine("     Error!!");
                };
            }
        }
    }
}
