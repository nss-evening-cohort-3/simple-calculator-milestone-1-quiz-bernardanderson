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
            int currentCommandCount = 0;
            string userInputFromCommandPrompt;
            int firstNumericTerm;
            int secondNumericTerm;
            char operatorFromUserInput;

        // Creates a new instance of the Expressions class to give non-static access to the methods
           Expressions newUserCalcInstance = new Expressions();

            while (true)
            {
                Console.Write($"[{ currentCommandCount }] > ");
                userInputFromCommandPrompt = Console.ReadLine();

                if (newUserCalcInstance.CheckUserWantsToExit(userInputFromCommandPrompt))
                {
                    break;
                }

                currentCommandCount++;
                newUserCalcInstance.ParseUserInput();
            }
        }
    }
}
