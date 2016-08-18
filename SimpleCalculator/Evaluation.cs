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
        Constant newUserConstant = new Constant();

        //Checks the string[] to assign the correct values to the variables
        public string CheckAndAssignSentStringArray(string[] sentIntegerAndOperationInfo)
        {
            int resultingParsedValue;

            //Checks for a constant being assigned based on the parsed characters (in the format of letter = number)
            if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[1]) &&
                new Regex(@"=").IsMatch(sentIntegerAndOperationInfo[2]) &&
                Int32.TryParse(sentIntegerAndOperationInfo[3], out resultingParsedValue)
                )
            {
                // Calls the Constant setting method
                bool returnedResult = newUserConstant.AssignConstantValue(sentIntegerAndOperationInfo[1], resultingParsedValue);

                if (returnedResult)
                {
                    return $"     {sentIntegerAndOperationInfo[1]} set to {resultingParsedValue}";
                }
                return $"     \"{sentIntegerAndOperationInfo[1]}\" has previously been set. Please choose another variable.";
            }

            //Looks at the first variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[1], out resultingParsedValue))
            {
                firstInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[1]))
            {
                KeyValuePair<bool, int> firstIntegerReturnedResult = newUserConstant.ReturnConstantValue(sentIntegerAndOperationInfo[1]);

                if (firstIntegerReturnedResult.Key)
                {
                    firstInteger = firstIntegerReturnedResult.Value;
                }
                else
                {
                    return $"     Error!! The constant \"{sentIntegerAndOperationInfo[1]}\" does not exist!";
                }
            }

            //Looks at the second variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[3], out resultingParsedValue))
            {
                secondInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[3]))
                {
                KeyValuePair<bool, int> secondIntegerReturnedResult = newUserConstant.ReturnConstantValue(sentIntegerAndOperationInfo[3]);

                if (secondIntegerReturnedResult.Key)
                {
                    secondInteger = secondIntegerReturnedResult.Value;
                }
                else
                {
                    return $"     Error!! The constant \"{sentIntegerAndOperationInfo[3]}\" does not exist!";
                }
            }
            ///////////
            if (new Regex(@"[\+\-\/\*%]").IsMatch(sentIntegerAndOperationInfo[2]))
            {
                operationSymbol = sentIntegerAndOperationInfo[2][0];
                Evaluate();

                return $"    = {Evaluate()}";
            } 
            else
            {
                return "     Error!! There is something wrong with your equation!";
            }
        }

        //This evaluates the expression after the check completes
        public int Evaluate()
        {
            int evaluatedOperationValue;

            switch (operationSymbol)
            {
                case '+':
                    evaluatedOperationValue = firstInteger + secondInteger;
                    break;
                case '-':
                    evaluatedOperationValue = firstInteger - secondInteger;
                    break;
                case '*':
                    evaluatedOperationValue = firstInteger * secondInteger;
                    break;
                case '/':
                    evaluatedOperationValue = firstInteger / secondInteger;
                    break;
                case '%':
                    evaluatedOperationValue = firstInteger % secondInteger;
                    break;
                default:
                    evaluatedOperationValue = 0;
                    break;
            }

            return evaluatedOperationValue;
        }

    }
}
