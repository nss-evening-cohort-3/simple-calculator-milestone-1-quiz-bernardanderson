using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Evaluation
    {
        int firstInteger;
        int secondInteger;
        char operationSymbol;

        //Rechecks the string[] and assigns the correct variables
        public bool CheckAndAssignSentStringArray(string[] sentIntegerAndOperationInfo)
        {
            int resultingParsedValue;

            if (Int32.TryParse(sentIntegerAndOperationInfo[0], out resultingParsedValue)) 
            {
                firstInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[0])              )
            {
                // firstInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return false;
            }
            
            if (Int32.TryParse(sentIntegerAndOperationInfo[2], out resultingParsedValue))
            {
                secondInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[0]))
            {
                // secondInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return false;
            }

            if (new Regex(@"[\+\-\/\*%=]").IsMatch(sentIntegerAndOperationInfo[1]) && true ) //'true' The Constant doesn't exist yet
            {
                operationSymbol = sentIntegerAndOperationInfo[1][0];
                return true;
            } 
            else
            {
                return false;
            }
        }

        //This evaluates the expression after the check completes
        public int Evaluate()
        {
            int evaluatedOperation;

            switch (operationSymbol)
            {
                case '+':
                    evaluatedOperation = firstInteger + secondInteger;
                    break;
                case '-':
                    evaluatedOperation = firstInteger - secondInteger;
                    break;
                case '*':
                    evaluatedOperation = firstInteger * secondInteger;
                    break;
                case '/':
                    evaluatedOperation = firstInteger / secondInteger;
                    break;
                case '%':
                    evaluatedOperation = firstInteger % secondInteger;
                    break;
                case '=':
                    evaluatedOperation = 0; //set the dictionary constant
                    break;
                default:
                    evaluatedOperation = 0;
                    break;
            }

            return evaluatedOperation;
        }

    }
}
