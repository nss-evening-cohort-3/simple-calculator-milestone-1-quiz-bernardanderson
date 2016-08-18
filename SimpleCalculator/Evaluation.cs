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
                bool returnedResult = newUserConstant.assignConstantValue(sentIntegerAndOperationInfo[1], resultingParsedValue);

                if (returnedResult)
                {
                    return $"     {sentIntegerAndOperationInfo[1]} set to {resultingParsedValue}";
                }
                return $"     \"{sentIntegerAndOperationInfo[1]}\" has previously been used. Please choose another variable.";
            }

            //Looks at the first variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[1], out resultingParsedValue)) 
            {
                firstInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[1]))
            {
                // firstInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return "Error";
            }

            //Looks at the second variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[3], out resultingParsedValue))
            {
                secondInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[3]))
            {
                // secondInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return "Error";
            }

            if (new Regex(@"[\+\-\/\*%]").IsMatch(sentIntegerAndOperationInfo[2]))
            {
                operationSymbol = sentIntegerAndOperationInfo[2][0];
                return "AllGood";
            } 
            else
            {
                return "Error";
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
