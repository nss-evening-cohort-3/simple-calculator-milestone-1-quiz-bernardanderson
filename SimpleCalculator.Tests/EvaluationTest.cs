using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class EvaluationTest
    {
        // Checks to see that the Evaluation class isn't null
        [TestMethod]
        public void Evaluation_EnsureICanCreateAnInstance()
        {
            //arrange (nothing in this case)

            //act (nothing in this case)

            //assert
            Assert.IsNotNull(new Evaluation());
        }

        // Add a test that checks to see if valid constant assignments actually trigger the assignment.
        //  (For a constant that doesn't exist yet)
        [TestMethod]
        public void Evaluation_CanDifferentWaysOfConstantSettingBeDetected_NewConstant()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();
            string[][] validTestStrings = {
                new string[] { "success", "a", "=", "2" },
                new string[] { "success", "b", "=", "32" },
                new string[] { "success", "C", "=", "-32" },
                new string[] { "success", "X", "=", "+32" },
                new string[] { "success", "Z", "=", "1132" }
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestStrings[i]).Contains("set to"));
            }
        }

        // Add a test that checks to see if valid constant assignments actually trigger the assignment.
        //  (For a constant that doesn't exist yet)
        [TestMethod]
        public void Evaluation_CanDifferentWaysOfConstantSettingBeDetected_AlreadySetConstant()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();

            string[] validTestString1 = { "success", "a", "=", "1" }; // Sets "a" to 1
            string[] validTestString2 = { "success", "a", "=", "-100" };  // Tries to reset "a" to -100

        //act (nothing in this case)

        //asserts
        Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString1).Contains("set to"));
        Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString2).Contains("has previously been set"));
        }

        // Check to see if the first integer is accessable and correctly handled
        [TestMethod]
        public void Evaluation_IsTheFirstIntegerParsableBothIntegerAndConstant()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();

            string[] forSettingAConstant = { "success", "a", "=", "2" }; // Sets "a" to 1
            string[] validTestString1 = { "success", "2", "+", "1" }; // Standard numerical equation
            string[] validTestString2 = { "success", "a", "+", "1" }; // Constant used as FirstInt in numerical equation
            string[] validTestString3 = { "success", "b", "+", "1" }; // This should return the error message since "b" doesn't exist

            newTestEvaluation.CheckAndAssignSentStringArray(forSettingAConstant);

            //act (nothing in this case)

            //asserts
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString1).Contains("     = 3"));
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString2).Contains("     = 3"));
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString3).Contains("Error!! The constant"));
        }

        // Check to see if the second integer is accessable and correctly handled
        [TestMethod]
        public void Evaluation_IsTheSecondIntegerParsableBothIntegerAndConstant()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();

            string[] forSettingAConstant = { "success", "a", "=", "2" }; // Sets "a" to 1
            string[] validTestString1 = { "success", "1", "+", "2" }; // Standard numerical equation
            string[] validTestString2 = { "success", "1", "+", "a" }; // Constant used as SecondInt in numerical equation
            string[] validTestString3 = { "success", "1", "+", "b" }; // This should return the error message since "b" doesn't exist

            newTestEvaluation.CheckAndAssignSentStringArray(forSettingAConstant);

            //act (nothing in this case)

            //asserts
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString1).Contains("     = 3"));
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString2).Contains("     = 3"));
            Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString3).Contains("Error!! The constant"));
        }

        // Check to see if the operator accessable and correctly handled (in this case successful operators
        [TestMethod]
        public void Evaluation_AreTheOperatorsUsedCorrectly()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();

            string[] plusOperator = { "success", "10", "+", "2" };
            string[] minusOperator = { "success", "10", "-", "2" };
            string[] multiplyOperator = { "success", "10", "*", "2" };
            string[] divideOperator = { "success", "10", "/", "2" };
            string[] modulusOperator = { "success", "10", "%", "2" };

            //act (nothing in this case)

            //asserts
            Assert.AreEqual("     = 12", newTestEvaluation.CheckAndAssignSentStringArray(plusOperator));
            Assert.AreEqual("     = 8", newTestEvaluation.CheckAndAssignSentStringArray(minusOperator));
            Assert.AreEqual("     = 20", newTestEvaluation.CheckAndAssignSentStringArray(multiplyOperator));
            Assert.AreEqual("     = 5", newTestEvaluation.CheckAndAssignSentStringArray(divideOperator));
            Assert.AreEqual("     = 0", newTestEvaluation.CheckAndAssignSentStringArray(modulusOperator));
        }

        // Check to see if the operator accessable and correctly handled (in this case "wrong" operators
        [TestMethod]
        public void Evaluation_AreIncorrectOperatorsCaught()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();

            string[][] incorrectOperators = {
                new string[] { "success", "10", "*+", "2" },
                new string[] { "success", "10", "$", "2" },
                new string[] { "success", "10", "^%", "2" },
                new string[] { "success", "10", "*+", "2" },
                new string[] { "success", "10", "a", "2" },
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < incorrectOperators.Length; i++)
            {
                Assert.AreEqual("     Error!! Invalid command format!!", newTestEvaluation.CheckAndAssignSentStringArray(incorrectOperators[i]));
            }
        }
        // Checks to see that if the evaluation method returns the correct result
        [TestMethod]
        public void Evaluation_DoTheOperationsReturnCorrectMathResult()
        {
            //arrange (nothing in this case)
            Evaluation newTestEvaluation = new Evaluation();
            int firstInteger = 100;
            int secondInteger = 50;
             
            //act (nothing in this case)

            //assert
            Assert.AreEqual("150" , newTestEvaluation.Evaluate('+', firstInteger, secondInteger));
            Assert.AreEqual("50" , newTestEvaluation.Evaluate('-', firstInteger, secondInteger));
            Assert.AreEqual("5000" , newTestEvaluation.Evaluate('*', firstInteger, secondInteger));
            Assert.AreEqual("2" , newTestEvaluation.Evaluate('/', firstInteger, secondInteger));
            Assert.AreEqual("0", newTestEvaluation.Evaluate('%', firstInteger, secondInteger));
            Assert.AreEqual("shouldNeverBeSeen", newTestEvaluation.Evaluate('a', firstInteger, secondInteger));
        }


    }
}
