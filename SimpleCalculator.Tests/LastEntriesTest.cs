using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class LastEntriesTest
    {
        // Checks to see that the LastEntries class isn't null
        [TestMethod]
        public void LastEntries_EnsureICanCreateAnInstance()
        {
            //arrange (nothing in this case)

            //act (nothing in this case)

            //assert
            Assert.IsNotNull(new LastEntries());
        }

        // Checks to see if the user types last (any case w/ w/o spaces)
        [TestMethod]
        public void LastEntries_CanLastBeMatched()
        {
            //arrange (nothing in this case)
            LastEntries newTestLastEntries = new LastEntries();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "last",
                "  last",
                "last   ",
                "LasT",
                "  LaSt   "
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsTrue(newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Key);
                Assert.AreEqual("     Nothing Yet!!", newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Value);
            }
        }

        // Checks to see if the user types lastq (any case w/ w/o spaces)
        [TestMethod]
        public void LastEntries_CanLastqBeMatched()
        {
            //arrange (nothing in this case)
            LastEntries newTestLastEntries = new LastEntries();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "lastq",
                "  lastq",
                "lastq     ",
                "   LastQ     ",
                "LastQ",
                "LaSTQ       "
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsTrue(newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Key);
                Assert.AreEqual("Nothing Yet!!", newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Value);
            }
        }

        // Checks to see if the user doesn't type last or lastq (any case w/ w/o spaces)
        [TestMethod]
        public void LastEntries_CanLastOrLastqFail()
        {
            //arrange (nothing in this case)
            LastEntries newTestLastEntries = new LastEntries();

            // These should be all valid ways of entering commands
            string[] validTestStrings = {
                "fro",
                "  Freep",
                "Swash     ",
                "   4JumPP     ",
                "aasdDAS",
                "Sumo       ",
                ""
            };

            //act (nothing in this case)

            //asserts
            for (int i = 0; i < validTestStrings.Length; i++)
            {
                Assert.IsFalse(newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Key);
                Assert.AreEqual("shouldNeverBeSeen", newTestLastEntries.CheckForLastCommands(validTestStrings[i]).Value);
            }
        }

        // Checks to see if last and lastq can be set
        [TestMethod]
        public void LastEntries_CanLastOrLastqBeSet()
        {
            //arrange (nothing in this case)
            LastEntries newTestLastEntries = new LastEntries();

            // These should be all valid ways of entering commands

            //act (nothing in this case)

            //asserts
                Assert.AreEqual("This is Last", newTestLastEntries.SetLastCommandValues("This is Last", "This is Lastq")[0]);
                Assert.AreEqual("This is Lastq", newTestLastEntries.SetLastCommandValues("This is Last", "This is Lastq")[1]);
        }


    }
}
