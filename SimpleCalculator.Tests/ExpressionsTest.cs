using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionsTest
    {
        // Checks to see that the Expressions class isn't null
        [TestMethod]
        public void Expressions_EnsureICanCreateAnInstance()
        {
            //arrange (nothing in this case)

            //act (nothing in this case)

            //assert
            Assert.IsNotNull(new Expressions());
        }

        // Checks to see if the user types exit or quit (any case w/ w/o spaces)
        [TestMethod]
        public void Expressions_CanExitOrQuitBeMatched()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "quit",
                "  quit",
                "quit   ",
                "QuiT",
                "  QuiT   ",
                "exit",
                "  exit",
                "exit     ",
                "   ExiT     ",
                "ExiT",
                "ExIt"
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsTrue(newTestExpressions.CheckIfUserWantsToExit(validTestStrings[i]));
            }
        }

        // Checks to see if the user types something other than exit or quit (any case w/ w/o spaces)
        [TestMethod]
        public void Expressions_CanExitOrQuitMethodFail()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all invalid ways of entering commands
            string[] validTestStrings = {
                "tuiq",
                "  xeit",
                "blah   ",
                "runnY",
                "  weird   ",
                "FacE",
                "  JumO",
                "dsds     ",
                "  ZaZ     ",
                "FruMpy",
                "3552"
            };

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsFalse(newTestExpressions.CheckIfUserWantsToExit(validTestStrings[i]));
            }
        }

        // Check to see is "help" can be matched (case insensitive w/ or w/o spaces)
        [TestMethod]
        public void Expressions_CanHelpBeDetected()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "help",
                "  help",
                "help   ",
                "Help",
                "  help   ",
                "HelP",
                "  hELp ",
            };

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsTrue(newTestExpressions.CheckIfUserWantsHelp(validTestStrings[i]));
            }
        }

        // Check to see is "help" can not be matched (case insensitive w/ or w/o spaces)
        [TestMethod]
        public void Expressions_CanHelpDetectionFail()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "hel",
                "helpo",
                "  hel   p",
                "pleh   ",
                "H  elp",
                "  hel  p   ",
                " elP",
                "  whELp ",
            };

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsFalse(newTestExpressions.CheckIfUserWantsHelp(validTestStrings[i]));
            }
        }

        // Checks to see if valid operation commands are reported as such
        [TestMethod]
        public void Expressions_CanARegExBeMatchedAsValid()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "a=3",
                "1+1",
                "-1+1",
                "a+4",
                "Z+-52",
                "-43+T",
                "     f+   56",
                "-4  +    -45"
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.AreEqual(newTestExpressions.CheckExpressionTypeAndParse(validTestStrings[i])[0], "success");
            }
        }

        // Checks to see that the Expressions class isn't null
        [TestMethod]
        public void Expressions_CanARegExBeMatchedAsInvalid()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string[] invalidTestStrings = {
               "a=a",
               "1   + -   1",
               "--1+1",
               "4=a",
               "-52-",
               "+T",
                "f",
                "-4"
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < invalidTestStrings.Length; i++)
            {
                Assert.AreEqual(newTestExpressions.CheckExpressionTypeAndParse(invalidTestStrings[i])[0], "failure");
            }
        }

        // Checks to see if valid operation commands are returned with the correct order and value
        [TestMethod]
        public void Expressions_CanARegExBeMatchedAndReturnCorrectMatches()
        {
            //arrange (nothing in this case)
            Expressions newTestExpressions = new Expressions();

            // These should be all valid ways of entering commands
            string validTestString = "     45 +-23";

            //act (nothing in this case)

            //asserts
            Assert.AreEqual("success", newTestExpressions.CheckExpressionTypeAndParse(validTestString)[0]);
            Assert.AreEqual("45", newTestExpressions.CheckExpressionTypeAndParse(validTestString)[1]);
            Assert.AreEqual("+", newTestExpressions.CheckExpressionTypeAndParse(validTestString)[2]);
            Assert.AreEqual("-23", newTestExpressions.CheckExpressionTypeAndParse(validTestString)[3]);
        }
    }
}
