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

        //Checks the string[] to assign the correct values to the variables
        public string CheckAndAssignSentStringArray(string[] sentIntegerAndOperationInfo)
        {
            int resultingParsedValue;

            //Checks for a constant being assigned based on the parsed characters
            if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[0]) &&
                new Regex(@"=").IsMatch(sentIntegerAndOperationInfo[1]) &&
                Int32.TryParse(sentIntegerAndOperationInfo[2], out resultingParsedValue)
                )
            {
                return "ConstantAssignment";
            }

            //Looks at the first variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[0], out resultingParsedValue)) 
            {
                firstInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[0]))
            {
                // firstInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return "Error";
            }

            //Looks at the second variable and assigns it appropriately
            if (Int32.TryParse(sentIntegerAndOperationInfo[2], out resultingParsedValue))
            {
                secondInteger = resultingParsedValue;
            }
            else if (new Regex(@"[A-Za-z]").IsMatch(sentIntegerAndOperationInfo[2]))
            {
                // secondInteger = Constants.ConstantLibrary(sentIntegerAndOperationInfo[0]);
            }
            else
            {
                return "Error";
            }

            if (new Regex(@"[\+\-\/\*%]").IsMatch(sentIntegerAndOperationInfo[1]))
            {
                operationSymbol = sentIntegerAndOperationInfo[1][0];
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
