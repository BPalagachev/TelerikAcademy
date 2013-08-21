using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContentCatalog;


namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class CommandTests
    {
        #region Test Create Command (constructor)
        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestCommandCreate_Trivial()
        {
            string testCommandAsString = "Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d";
            ICommand testCommand = new Command(testCommandAsString);

            Assert.AreEqual("Add movie", testCommand.Name);
            Assert.AreEqual(testCommandAsString, testCommand.OriginalForm);

            string[] commandExpecedParams = new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" };

            for (int i = 0; i < testCommand.Parameters.Length; i++)
            {
                Assert.AreEqual(commandExpecedParams[i], testCommand.Parameters[i],
                    string.Format("Command parameter is {0} but should be {1}", commandExpecedParams[i], testCommand.Parameters[i]));
            }

        }
        #endregion

        #region Test ParseCommandType(string commandName)
        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestCommandParseCommandType_ParseAddBook()
        {
            string testCommandAsString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);

            CommandType testCommandType = testCommand.ParseCommandType(testCommand.Name);

            Assert.AreEqual(CommandType.AddBook, testCommandType);

        }

        [TestMethod]
        [TestCategory("CommandTests")]
        [ExpectedException(typeof(FormatException))]
        public void TestCommandParseCommandType_InvalidFormat()
        {
            string testCommandAsString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);
            CommandType testCommandType = testCommand.ParseCommandType("Add book:");
        }

        [TestMethod]
        [TestCategory("CommandTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParseCommandType_IncorrectAddCommand()
        {
            string testCommandAsString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);
            CommandType testCommandType = testCommand.ParseCommandType("Ad book");
        }

        [TestMethod]
        [TestCategory("CommandTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParseCommandType_IncorrectUpdate()
        {
            string testCommandAsString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);
            CommandType testCommandType = testCommand.ParseCommandType("incorect Update ");
        }

        [TestMethod]
        [TestCategory("CommandTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParseCommandType_IncorrectCommandGeneral()
        {
            string testCommandAsString = "Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);
            CommandType testCommandType = testCommand.ParseCommandType("asEdasdf ");
        }
        #endregion

        #region Test ParseName
        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestCommandGetName_AddSong()
        {
            string testCommandAsString = "Add song: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info";
            ICommand testCommand = new Command(testCommandAsString);
            string testCommandName = testCommand.GetName();

            Assert.AreEqual("Add song", testCommandName);
        }
        #endregion

        #region Test ParseParameters
        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestParseParameters_Update()
        {
            string testCommandAsString = "Update: http://www.introprogramming.info; http://introprograming.info/en/";
            ICommand testCommand = new Command(testCommandAsString);

            string[] commandExpecedParams = new string[] { "http://www.introprogramming.info", "http://introprograming.info/en/" };

            for (int i = 0; i < testCommand.Parameters.Length; i++)
            {
                Assert.AreEqual(commandExpecedParams[i], testCommand.Parameters[i],
                    string.Format("Command parameter is {0} but should be {1}", commandExpecedParams[i], testCommand.Parameters[i]));
            }

        }

        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestParseParameters_AddSong()
        {
            string testCommandAsString = "Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs";
            ICommand testCommand = new Command(testCommandAsString);

            string[] commandExpecedParams = new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };

            for (int i = 0; i < testCommand.Parameters.Length; i++)
            {
                Assert.AreEqual(commandExpecedParams[i], testCommand.Parameters[i],
                    string.Format("Command parameter is {0} but should be {1}", commandExpecedParams[i], testCommand.Parameters[i]));
            }

        }
        #endregion

        #region toString
        [TestMethod]
        [TestCategory("CommandTests")]
        public void TestToString_Update()
        {
            string testCommandAsString = "Update: http://www.introprogramming.info; http://introprograming.info/en/";
            ICommand testCommand = new Command(testCommandAsString);

            string actual = testCommand.ToString();
            string expected = "Update http://www.introprogramming.info http://introprograming.info/en/ ";

            Assert.AreEqual(expected, actual);
        }

        

        #endregion
    }
}
