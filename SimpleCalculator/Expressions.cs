using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Expressions
    {
        public int currentCommandCount { get; set; } = 0;
        public bool userHasNotExited { get; set; } = true;
        public string userInputFromCommandPrompt { get; set; }
        public int firstNumericTerm { get; set; }
        public int secondNumericTerm { get; set; }
        public char operatorFromUserInput { get; set; }

        public void ParseUserInput()
        {
            if (userInputFromCommandPrompt.ToLower() == "quit" | userInputFromCommandPrompt.ToLower() == "exit")
            {
                userHasNotExited = false;
            }
        }



    }
}
