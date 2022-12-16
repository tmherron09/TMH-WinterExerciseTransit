using AdventOfCode2022.TimsyMagnus.Services.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.TimsyMagnus.Services.Tests.Day01_1
{
    [TestClass]
    public class Day01_1_Tests
    {

        [TestMethod]
        public void PopulatTextInput_ArrayIsPopulated()
        {
            var expectedLineCount = 2254;
            var elfCalorieCounter = new ElfCalorieCounter();

            var actualLineCount = elfCalorieCounter.InputArray.Length;

            Assert.AreEqual(expectedLineCount, actualLineCount);
        }

        [TestMethod]
        public void InitializeNewElfCaloieCounter_ThrowsNoExceptions()
        {
            try
            {
                var testElfCalorieCounter = new ElfCalorieCounter();
                Assert.IsInstanceOfType(testElfCalorieCounter, typeof(ElfCalorieCounter));
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
