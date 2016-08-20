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
            string[] validTestString2 = { "success", "a", "=", "-100" };  // Tries to set "a" to -100

        //act (nothing in this case)

        //asserts
        Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString1).Contains("set to"));
        Assert.IsTrue(newTestEvaluation.CheckAndAssignSentStringArray(validTestString2).Contains("has previously been set"));
        }

        //Add a test that checks firstInteger is valid/a constant/invalid
        //Add a test that checks secondInteger is valid/a constant/invalid
        //Add a test that checks operation is valid/a constant/invalid

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
