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
            string userOperation;
            string userInputFromCommandPrompt;
            KeyValuePair<string, bool> matchedRegExStringAndValidity; // This holds the matched RegExString from the user input and if a string was actually matched!

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

                matchedRegExStringAndValidity = newUserCalcInstance.CheckExpressionType(userInputFromCommandPrompt);

                if (matchedRegExStringAndValidity.Value) // Looks to see if a RegEx was matched before parsing.
                {
                    newUserCalcInstance.ParseUserInput(userInputFromCommandPrompt, matchedRegExStringAndValidity.Key);
                }
                else
                {
                    Console.WriteLine("     Error!!");
                };
            }
        }
    }
}
