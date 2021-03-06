﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Expressions
    {
        // These are the lists of Regular Expressions for the different types of operation formats the user can enter
        string[] regularExpressions = new string[] {
            @"^\s*([-|\+]{0,1}\d+)\s*([\+\-\/\*%])\s*([-|\+]{0,1}\d+)\s*$", // Number Operation Number
            @"^\s*([a-zA-Z])\s*(=)\s*([-|\+]{0,1}\d+)\s*$",                 // Constant Equals Number
            @"^\s*([a-zA-Z])\s*([\+\-\/\*%])\s*([-|\+]{0,1}\d+)\s*$",       // Constant Operation Number
            @"^\s*([-|\+]{0,1}\d+)\s*([\+\-\/\*%])\s*([a-zA-Z])\s*$",       // Number Operation Constant
            @"^\s*([a-zA-Z])\s*([\+\-\/\*%])\s*([a-zA-Z])\s*$",             // Constant Operation Constant
        };

        // This simply checks to see if the user typed either of the two termination commands
        public bool CheckIfUserWantsToExit(string sentUserInputFromCommandPrompt)
        {
            return new Regex(@"^\s*quit\s*$|^\s*exit\s*$").Match(sentUserInputFromCommandPrompt.ToLower()).Success;
        }

        // This simply checks to see if the user wants help
        public bool CheckIfUserWantsHelp(string sentUserInputFromCommandPrompt)
        {
            return new Regex(@"^\s*help\s*$").Match(sentUserInputFromCommandPrompt.ToLower()).Success;
        }

        // This cycles through the RegEx's in the array above to see if a match can be made against the user entered command.
        //  If the match is made, the userInput is parsed and returned with a "success" or "failure" within a string array.
        public string[] CheckExpressionTypeAndParse(string sentUserInputFromCommandPrompt)
        {
            for (int i = 0; i < regularExpressions.Length; i++)
            {
                if (new Regex(regularExpressions[i]).IsMatch(sentUserInputFromCommandPrompt)) // Cycles through all Regular Expression for a match  
                {
                    Match matchedFields = new Regex(regularExpressions[i]).Match(sentUserInputFromCommandPrompt);
                    return new string[] { "success", matchedFields.Groups[1].ToString(), matchedFields.Groups[2].ToString(), matchedFields.Groups[3].ToString() };
                }
            }
            return new string[] { "failure" };
        }
    }
}
