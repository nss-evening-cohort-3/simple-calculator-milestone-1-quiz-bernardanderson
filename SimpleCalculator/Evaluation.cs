using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Evaluation
    {
        public int Evaluate(string[] sentIntegerAndOperationInfo)
        {
            int firstInteger = Convert.ToInt32(sentIntegerAndOperationInfo[0]);
            char operation = sentIntegerAndOperationInfo[1][0];
            int secondInteger = Convert.ToInt32(sentIntegerAndOperationInfo[2]);
            int evaluatedOperation;

            switch (operation)
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
                default:
                    evaluatedOperation = 0;
                    break;
            }

            return evaluatedOperation;
        }

    }
}
