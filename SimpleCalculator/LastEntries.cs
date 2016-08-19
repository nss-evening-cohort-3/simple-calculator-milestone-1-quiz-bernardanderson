using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class LastEntries
    {
        string last { get; set; } = "Nothing Yet!!";
        string lastq { get; set; } = "Nothing Yet!!";

        // Looks to see if "last" or "lastq" were matched in the user string based on the RegEx below
        public KeyValuePair<bool, string> CheckForLastCommands(string sentUserInputFromCommandPrompt)
        {
            // Match is like an array where .Group element 0 is the original user string. Any capture () are listed in the following elements
            //  even if there is no match [this one should have three matches, one for the user input, one for "last" and one for "lastq" 
            Match tempLastMatch = new Regex(@"^\s*(last)\s*$|^\s*(lastq)\s*$").Match(sentUserInputFromCommandPrompt.ToLower());

            if (tempLastMatch.Success)
            {
                if (tempLastMatch.Groups[1].ToString().Length == 4) // This means "last" was matched
                {
                    return new KeyValuePair<bool, string>(true, $"     {last}");
                }
                else // Only true if "lastq" is matched
                {
                    return new KeyValuePair<bool, string>(true, lastq);
                }
            }
            else
            {
                return new KeyValuePair<bool, string>(false, "shouldNeverBeSeen");
            }
        }

        // Sets the "last" and "lastq" variables to the sent strings
        public string[] SetLastCommandValues (string sentLastCommand, string sentLastqCommand )
        {
            last = sentLastCommand;
            lastq = sentLastqCommand;
            return new string[] { last, lastq };
        }

    }
}