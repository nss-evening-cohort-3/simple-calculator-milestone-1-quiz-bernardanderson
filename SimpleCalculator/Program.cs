using System;
using System.Collections;
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
            string[] userIntegersAndOperation = { "", "", "" }; // returned in the format of First Integer, Operation and Second Integer
            KeyValuePair<int, bool> matchedRegExStringAndValidity; // This holds any matched RegEx array element and if a string was actually matched!

            // Creates a new instance of the Expressions class to give non-static access to the methods
            Expressions newUserExpression = new Expressions();
            Evaluation newUserEvaluation = new Evaluation();

            while (true)
            {
                Console.Write($"[{ currentCommandCount }]> ");
                userInputFromCommandPrompt = Console.ReadLine();

                if (newUserExpression.CheckIfUserWantsToExit(userInputFromCommandPrompt)) // Checks to see if the user typed "exit" or "quit" and, if so, breaks out of the loop
                {
                    Console.WriteLine("Bye!!!");
                    break;
                }

                currentCommandCount++;

                matchedRegExStringAndValidity = newUserExpression.CheckExpressionType(userInputFromCommandPrompt);

                if (matchedRegExStringAndValidity.Value) // Looks to see if a RegEx was matched before parsing.
                {
                    userIntegersAndOperation = newUserExpression.ParseUserInput(userInputFromCommandPrompt, matchedRegExStringAndValidity.Key);
                    Console.WriteLine($"     = {newUserEvaluation.Evaluate(userIntegersAndOperation)}");
                }
                else
                {
                    Console.WriteLine("     Error!!");
                };
            }
        }
    }
}
