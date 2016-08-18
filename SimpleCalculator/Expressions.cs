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
        string[] regularExpressions = new string[] {
            @"^\s*([-|\+]{0,1}\d+)\s*([\+\-\/\*%])\s*([-|\+]{0,1}\d+)\s*$", // Number Operation Number
            @"^\s*([a-zA-Z])\s*(=)\s*([-|\+]{0,1}\d+)\s*$",                 // Constant Equals Number
            @"^\s*([a-zA-Z])\s*([\+\-\/\*%])\s*([-|\+]{0,1}\d+)\s*$",       // Constant Operation Number
            @"^\s*([-|\+]{0,1}\d+)\s*([\+\-\/\*%])\s*([a-zA-Z])\s*$",       // Number Operation Constant
            @"^\s*([a-zA-Z])\s*([\+\-\/\*%])\s*([a-zA-Z])\s*$"              // Constant Operation Constant
        };

        // This simply checks to see if the user typed either of the two termination commands
        public bool CheckIfUserWantsToExit(string sentUserInputFromCommandPrompt)
        {
            if (sentUserInputFromCommandPrompt.ToLower() == "quit" | sentUserInputFromCommandPrompt.ToLower() == "exit")
            {
                return true;
            } 
            return false;
        }

        // This cycles through the RegEx's in the array above to see if a match can be made against the user entered command.
        //  It returns which RegEx array element was matched and "true" meaning success.  If no match is made -1 along with "false" 
        //  is sent.
        public string[] CheckExpressionTypeAndParse(string sentUserInputFromCommandPrompt)
        {
            for (int i = 0; i < regularExpressions.Length; i++)
            {
                if (new Regex(regularExpressions[i]).IsMatch(sentUserInputFromCommandPrompt)) // Cycles through all Regular Expression for a match  
                {
                    Match matchedFields = new Regex(regularExpressions[i]).Match(sentUserInputFromCommandPrompt);
                    return new string[] { "true", matchedFields.Groups[1].ToString(), matchedFields.Groups[2].ToString(), matchedFields.Groups[3].ToString() };
                }
            }
            return new string[] { "false" };
        }
    }
}
