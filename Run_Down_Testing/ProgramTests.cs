using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using scoreboard;
using System.Linq;
using System.Collections.Generic;

namespace Run_Down_Testing
{
    
        [TestClass]
        public class ProgramTests
        {
            [TestMethod]
            public void TestLoadTeamNamesFromFile()
            {
                // Arrange
                string filePath = "teamnames_test.txt";
                string[] teamNamesArray = { "Team1", "Team2", "Team3" };
                File.WriteAllLines(filePath, teamNamesArray);

                // Act
                List<string> loadedTeamNames = Program.LoadTeamNamesFromFile(filePath);

                // Assert
                CollectionAssert.AreEqual(teamNamesArray, loadedTeamNames.ToArray());

                // Clean up
                File.Delete(filePath);
            }

            [TestMethod]
            public void GetSelectedTeamIndex_ValidInput_ReturnsCorrectIndex()
            {
                // Arrange
                int maxIndex = 3;
                string input = "2\n";  // Simulating user input

                using (StringReader stringReader = new StringReader(input))
                {
                    Console.SetIn(stringReader);

                    // Act
                    int result = Program.GetSelectedTeamIndex(maxIndex);

                    // Assert
                    Assert.AreEqual(1, result); // Since the input is 2, the method should return 2 - 1 = 1
                }
            }
        }

        
    
}