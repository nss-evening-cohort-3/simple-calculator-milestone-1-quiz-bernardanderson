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
        Constant newUserConstant = new Constant();

        //Checks the string[] to assign the correct values to the variables
        public string CheckAndAssignSentStringArray(string[] sentIntegerAndOperationInfo)
        {
            int firstInteger = 0, secondInteger = 0, resultingParsedValue = 0;
            char operationSymbol;

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
                    return $"     \"{sentIntegerAndOperationInfo[1]}\" set to {resultingParsedValue}";
                }
                return $"     \"{sentIntegerAndOperationInfo[1]}\" has previously been set. Please choose different variable.";
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

            if (new Regex(@"[\+\-\/\*%]").IsMatch(sentIntegerAndOperationInfo[2]))
            {
                operationSymbol = sentIntegerAndOperationInfo[2][0];
                return $"     = {Evaluate(operationSymbol, firstInteger, secondInteger)}";
            } 
            else
            {
                return "     Error!! Invalid command format!!";
            }
        }

        //This evaluates the expression after all checks complete
        public string Evaluate(char sentOperationSymbol, int sentFirstInteger, int sentSecondInteger)
        {
            int evaluatedOperationValue;

            switch (sentOperationSymbol)
            {
                case '+':
                    evaluatedOperationValue = sentFirstInteger + sentSecondInteger;
                    break;
                case '-':
                    evaluatedOperationValue = sentFirstInteger - sentSecondInteger;
                    break;
                case '*':
                    evaluatedOperationValue = sentFirstInteger * sentSecondInteger;
                    break;
                case '/':
                    evaluatedOperationValue = sentFirstInteger / sentSecondInteger;
                    break;
                case '%':
                    evaluatedOperationValue = sentFirstInteger % sentSecondInteger;
                    break;
                default:
                    return "     Error!! Evaluation Failed!!";
            }
            return evaluatedOperationValue.ToString();
        }

    }
}
