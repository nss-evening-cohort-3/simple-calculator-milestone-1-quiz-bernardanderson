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
