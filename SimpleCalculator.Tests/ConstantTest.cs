using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ConstantTest
    {
        // Checks to see that the Constant class isn't null
        [TestMethod]
        public void Constant_EnsureICanCreateAnInstance()
        {
            //arrange (nothing in this case)

            //act (nothing in this case)

            //assert
            Assert.IsNotNull(new Expressions());
        }

        // Checks to see that the Constant class can access the library, find an item in the dictionary and returns the correct value
        [TestMethod]
        public void Constant_IsConstantPresentWhenCalledAndReportingCorrectValue()
        {
            //arrange (nothing in this case)
            Constant newTestConstant = new Constant();

            //act (nothing in this case)

            //assert
            Assert.IsTrue(newTestConstant.ReturnConstantValue("spacer").Key);
            Assert.AreEqual(42, newTestConstant.ReturnConstantValue("spacer").Value);
        }

        // Checks to see that the Constant class can access the library, not find an item in the dictionary and return no match was found 
        [TestMethod]
        public void Constant_IsConstantNotPresentWhenCalled()
        {
            //arrange (nothing in this case)
            Constant newTestConstant = new Constant();

            //act (nothing in this case)

            //assert
            Assert.IsFalse(newTestConstant.ReturnConstantValue("notPresent").Key);
            Assert.AreEqual(-1, newTestConstant.ReturnConstantValue("notPresent").Value);
        }

        // Checks to see that the Constant class can access the library.  If the new constant exists it returns "false".
        [TestMethod]
        public void Constant_CanAConstantBeAssignedIfAlreadyInDictionary()
        {
            //arrange (nothing in this case)
            Constant newTestConstant = new Constant();

            //act (nothing in this case)

            //assert
            Assert.IsFalse(newTestConstant.AssignConstantValue("spacer", 41));
        }

        // Checks to see that the Constant class can access the library.  If the constant doesn't exist 
        //  it sets the constant in the dictionary and returns "true".
        [TestMethod]
        public void Constant_CanAConstantBeAssignedIfNotAlreadyInDictionary()
        {
            //arrange (nothing in this case)
            Constant newTestConstant = new Constant();

            //act (nothing in this case)

            //assert
            Assert.IsTrue(newTestConstant.AssignConstantValue("a", -1));
        }
    }
}