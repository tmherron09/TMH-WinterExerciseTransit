using AdventOfCode2022.TimsyMagnus.ConsoleApp.UtilityServices;
using AdventOfCode2022.TimsyMagnus.Services.Day01;

namespace AdventOfCode2022.TimsyMagnus.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Timsy Magnus Advent Calendar 2022 Solution Explorer:");
                var choiceIndex = 1;
                foreach (AdventDays day in Enum.GetValues(typeof(AdventDays)))
                {
                    Console.WriteLine($"{choiceIndex}.)   " + AdventDayChallengeName(day));
                }
                var validSelection = false;
                while (!validSelection)
                {
                    Int32.TryParse(Console.ReadLine(), out var selection);
                    var selectedDay = (AdventDays)selection;
                    RunSelectedAdventChallenge(selectedDay);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }


        enum AdventDays
        {
            Day01_1 = 1,
            Day01_2 = 2
        }

        static string AdventDayChallengeName(AdventDays adventDay)
        {
            switch(adventDay)
            {
                case AdventDays.Day01_1:
                    return "Day 1 Challenge 1 - Elf Calorie Counter";
                case AdventDays.Day01_2:
                    return "Day 1 Challenge 2 - Top Three Elves with Most Calories"
                default:
                    throw new Exception("Invalid Adevent Day.");
            }
        }

        static void RunSelectedAdventChallenge(AdventDays adventDay)
        {
            Utility.StartAdventChallengeAnswer(AdventDayChallengeName(adventDay));
            switch (adventDay)
            {
                case AdventDays.Day01_1:
                    var elfCalorieCounter = new ElfCalorieCounter();
                    Console.WriteLine($"The Elf with the Most Calories is ELf #{elfCalorieCounter.ElfWithMostCalories} with a total of {elfCalorieCounter.ElfWithMostCaloriesTotalCalories} Calories held.");
                    break;
                default:
                    throw new Exception("Invalid Adevent Day.");
            }
            Utility.EndAdventChallengeAnswer();
        }

        static void UtilityTestForLineInserts()
        {
            Console.WriteLine("Line One");
            Utility.InsertMultipleLines(5);
            Console.WriteLine("Line Six");
            Utility.InsertMultipleLines(1);
            Console.WriteLine("Line Eight");
        }
    }
}