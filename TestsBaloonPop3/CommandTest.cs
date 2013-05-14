using System;
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
            //Assert.AreEqual(input,command.Value); - otdelen test
        }
    }
}
