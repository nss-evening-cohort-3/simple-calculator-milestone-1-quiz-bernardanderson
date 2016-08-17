using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Expressions
    {
        // These are the lists of Regular Expressions for the different types of operation formats the user can enter
        string[] regularExpressions = new[] {
            @"^\s*([-|\+]{0,1}\d+)\s*([\+\-\/\*%])\s*([-|\+]{0,1}\d+)\s*$", // Number Operation Number ***
            @"^\s*[a-zA-Z]\s*=\s*[-|\+]{0,1}\d+\s*$",                       // Constant Equals Number
            @"^\s*[a-zA-Z]\s*[\+\-\/\*%]{1}\s*[-|\+]{0,1}\d+\s*$",          // Constant Operation Number
            @"^\s*[-|\+]{0,1}\d+\s*[\+\-\/\*%]{1}\s*[a-zA-Z]{1}\s*$",       // Number Operation Constant
            @"^\s*[a-zA-Z]{1}\s*[\+\-\/\*%]{1}\s*[a-zA-Z]{1}\s*$"           // Constant Operation Constant
        };

        public bool CheckUserWantsToExit(string sentUserInputFromCommandPrompt)
        {
            if (sentUserInputFromCommandPrompt.ToLower() == "quit" | sentUserInputFromCommandPrompt.ToLower() == "exit")
            {
                return true;
            } 
            return false;
        }

        public KeyValuePair<int, bool> CheckExpressionType(string sentUserInputFromCommandPrompt)
        {
            for (int i = 0; i < regularExpressions.Length; i++)
            {
                if (new Regex(regularExpressions[i]).IsMatch(sentUserInputFromCommandPrompt)) // Cycles through all Regular Expression for a match  
                {
                    return new KeyValuePair<int, bool> (i, true);
                }
            }
            return new KeyValuePair<int, bool>(-1, false);
        }

        public string[] ParseUserInput(string sentUserInputFromCommandPrompt, int sentMatchedRegExElementNumber)
        {
            Match matchedFields = new Regex(regularExpressions[sentMatchedRegExElementNumber]).Match(sentUserInputFromCommandPrompt);

            return new string[] { matchedFields.Groups[1].ToString(), matchedFields.Groups[2].ToString(), matchedFields.Groups[3].ToString() } ;
        }



    }
}
