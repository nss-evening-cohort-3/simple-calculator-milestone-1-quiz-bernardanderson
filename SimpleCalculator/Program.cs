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
            string[] userIntegersAndOperation = { "", "", "", "" }; // returned in the format of First Integer, Operation and Second Integer
            string resultOfOperation = "     Nothing Yet!";

            // Creates a new instance of the used classes to give non-static access to their methods
            Expressions newUserExpression = new Expressions();
            Evaluation newUserEvaluation = new Evaluation();
            LastEntries newUserLastEntry = new LastEntries();

            while (true)
            {
                Console.Write($"[{ currentCommandCount }]> ");
                userInputFromCommandPrompt = Console.ReadLine();

                // Checks to see if the user typed "exit" or "quit" and, if so, breaks out of the loop
                if (newUserExpression.CheckIfUserWantsToExit(userInputFromCommandPrompt)) 
                {
                    Console.WriteLine("     Bye!!!\n     (Press Return to Exit)");
                    Console.ReadLine();
                    break;
                }

                currentCommandCount++;

                //Checks and Parses the User String
                userIntegersAndOperation = newUserExpression.CheckExpressionTypeAndParse(userInputFromCommandPrompt);

                // Looks to see if a RegEx was matched and parsed.
                if (userIntegersAndOperation[0] == "success") 
                {
                    resultOfOperation = newUserEvaluation.CheckAndAssignSentStringArray(userIntegersAndOperation);
                }
                else
                {
                    resultOfOperation = "     Error!! Invalid command format!!";
                }

                // Looks to see if either of the last/lastq commands was issued
                if (newUserLastEntry.CheckForLastCommands(userInputFromCommandPrompt).Key)
                {
                    resultOfOperation = newUserLastEntry.CheckForLastCommands(userInputFromCommandPrompt).Value;
                }
                else
                {
                    // Assigns the submitted user operation, and reported commands to the "stack"
                    //  This is an "else" so any "last" or "lastq" commands don't get pushed into the last "stack" 
                    newUserLastEntry.SetLastCommandValues(userInputFromCommandPrompt, resultOfOperation);
                }

                Console.WriteLine(resultOfOperation);
            }
        }
    }
}
