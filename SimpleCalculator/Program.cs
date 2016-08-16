using System;
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
            // Creates a new instance of the Expressions class to give non-static access to the methods
            Expressions newUserCalcInstance = new Expressions();


            while (newUserCalcInstance.userHasNotExited)
            {
                Console.Write($"[{ newUserCalcInstance.currentCommandCount }] >");
                newUserCalcInstance.userInputFromCommandPrompt = Console.ReadLine();

                Console.Write(newUserCalcInstance.userInputFromCommandPrompt);

            }
        }
    }
}
