using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void ParseUserInput()
        {

        }



    }
}
