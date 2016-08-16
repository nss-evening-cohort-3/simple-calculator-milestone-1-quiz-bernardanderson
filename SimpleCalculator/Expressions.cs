using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Expressions
    {
        public bool CheckUserWantsToExit(string sentUserInputFromCommandPrompt)
        {
            if (sentUserInputFromCommandPrompt.ToLower() == "quit" | sentUserInputFromCommandPrompt.ToLower() == "exit")
            {
                return true;
            } else
            {
                return false;
            }
        }

        public KeyValuePair<string, bool> CheckExpressionType(string sentUserInputFromCommandPrompt)
        {
            if (new Regex(@"^\s*[-|\+]{0,1}\s*\d+\s*[\+\-\/\*%]\s*[-|\+]{0,1}\s*\d+\s*$").IsMatch(sentUserInputFromCommandPrompt)) // Checks for a "number operation number"  
            {
                return new KeyValuePair<string, bool> ("NON", true);
            }
            else if (new Regex(@"^\s*[a-zA-Z]\s*=\s*[-|\+]{0,1}\d+\s*$").IsMatch(sentUserInputFromCommandPrompt)) // Checks for a "const = number"
            {
                return new KeyValuePair<string, bool>("CEN", true);
            }
            else if (new Regex(@"^\s*[a-zA-Z]\s*[\+\-\/\*%]{1}\s*[-|\+]{0,1}\d+\s*$").IsMatch(sentUserInputFromCommandPrompt)) // Check for an "const operation number"
            {
                return new KeyValuePair<string, bool>("CON", true);
            }
            else if (new Regex(@"^\s*[-|\+]{0,1}\d+\s*[\+\-\/\*%]{1}\s*[a-zA-Z]{1}\s*$").IsMatch(sentUserInputFromCommandPrompt)) // Check for an "number operation const" 
            {
                return new KeyValuePair<string, bool>("NOC", true);
            } else if (new Regex(@"^\s*[a-zA-Z]{1}\s*[\+\-\/\*%]{1}\s*[a-zA-Z]{1}\s*$").IsMatch(sentUserInputFromCommandPrompt)) // This is "const operation const" 
            {
                return new KeyValuePair<string, bool>("COC", true);
            }
            return new KeyValuePair<string, bool>("NoMatch", false);
        }

        public int ParseUserInput(string sentUserInputFromCommandPrompt)
        {
            string[] parsedUserInput = new string[3];
            int newValue = 0;

            //bool firstNumber = Int32.TryParse(new Regex(@"[-|\+]*\d+").Match(sentUserInputFromCommandPrompt).ToString(), out newValue);

            //Console.WriteLine(firstNumber);

            return newValue;
        }



    }
}
