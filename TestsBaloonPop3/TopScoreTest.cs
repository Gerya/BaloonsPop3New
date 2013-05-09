using System;
using Zirconium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsBaloonPop3
{
    [TestClass]
    public class TopScoreTest
    {
        [TestMethod]
        public void MaxTopScoreCount()
        {
            Player testPlayer = new Player();

            for (int i = 0; i < 7; i++)
            {
                testPlayer.Name = "Name " + i;
                testPlayer.Score = i;
                TopScore.IsTopScore(testPlayer);
            }
        }
    }
}
