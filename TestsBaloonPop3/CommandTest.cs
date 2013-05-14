using Zirconium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsBaloonPop3
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void TryParse_CommandTop_Parsed()
        {
            string input = "top";
            Command command=new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_CommandTop_SetValue()
        {
            string input = "top";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.AreEqual(input,command.Value);
        }

        [TestMethod]
        public void TryParse_CommandRestart_Parsed()
        {
            string input = "restart";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_CommandRestart_SetValue()
        {
            string input = "restart";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.AreEqual(input, command.Value);
        }

        [TestMethod]
        public void TryParse_CommandExit_Parsed()
        {
            string input = "exit";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_CommandExit_SetValue()
        {
            string input = "exit";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.AreEqual(input, command.Value);
        }

        [TestMethod]
        public void TryParse_InvalidCommand_ParseFailed()
        {
            string input = "alabala";
            Command command = new Command();
            bool result = Command.TryParse(input, ref command);
            Assert.IsFalse(result);
        }
    }
}
