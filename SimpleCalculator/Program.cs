﻿using System;
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
            string typeOfOperation;
            string[] userIntegersAndOperation = { "", "", "", "" }; // returned in the format of First Integer, Operation and Second Integer

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

                //Checks and Parses the User String
                userIntegersAndOperation = newUserExpression.CheckExpressionTypeAndParse(userInputFromCommandPrompt);

                if (userIntegersAndOperation[0] == "true") // Looks to see if a RegEx was matched before parsing.
                {
                    //Determines the type of operation
                    typeOfOperation = newUserEvaluation.CheckAndAssignSentStringArray(userIntegersAndOperation);

                    if (typeOfOperation == "ConstantAssignment")
                    {

                    }
                    else
                    {
                        //Evaluates the operation
                        Console.WriteLine($"     = {newUserEvaluation.Evaluate()}");
                    }
                }
                else
                {
                    typeOfOperation = "Error";
                }

                if (typeOfOperation == "Error")
                {
                    Console.WriteLine("     Error!!");
                }
            }
        }
    }
}
