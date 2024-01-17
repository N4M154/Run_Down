using Microsoft.VisualStudio.TestTools.UnitTesting;
using scoreboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Run_Down_Testing
{
    [TestClass]
    public class TossGenerateTests
    {
        [TestMethod]
        public void Toss_WinHeadsForTeam1_BatTeam1()
        {
            // Arrange
            string team1 = "TeamA";
            string team2 = "TeamB";
            string input = "bat\nbowl\nheads\n";  // Simulating user input

            using (StringReader stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);

                TossGenerate tossGenerate = new TossGenerate(team1, team2);

                // Act
                string result = tossGenerate.Toss();

                // Assert
                Assert.AreEqual(team1, result);
            }
        }
    }
}
