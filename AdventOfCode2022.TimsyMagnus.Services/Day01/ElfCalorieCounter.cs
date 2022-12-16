using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.TimsyMagnus.Services.Day01
{
    public class ElfCalorieCounter
    {
        public string[] InputArray { get; set; }
        public List<ElfCaloriePack> Elves { get; set; }
        public int ElfCount { get { return Elves.Count; } }
        public int ElfWithMostCalories { get { return GetElfWithMostCalories(); } }
        public int ElfWithMostCaloriesTotalCalories { get { return GetCalorieCountOfElfById(GetElfWithMostCalories()); } }
        private string InputFolderName { get; } = "\\InputText";

        private string InputFileLocation { get { return Directory.GetCurrentDirectory() + InputFolderName; } }
        private string InputFileName { get; } = "Day01_1.txt";

        public ElfCalorieCounter()
        {
            try
            {
                Elves = new List<ElfCaloriePack>();
                InputArray = ReadInputFileToArray();
                DistributeCaloriePacks();
            }
            catch
            {
                throw;
            }
        }

        public string[] ReadInputFileToArray()
        {
            try
            {
                return File.ReadAllLines(InputFileLocation + "\\" + InputFileName);
            }
            catch
            {
                throw;
            }
        }

        public void DistributeCaloriePacks()
        {
            try
            {
                var startingIndex = GetFirstNonBlankLine();
                var elfCount = 0;
                var firstElf = new ElfCaloriePack(elfCount++);
                var currentElf = firstElf;
                for (int i = startingIndex; i < InputArray.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(InputArray[i]))
                    {
                        currentElf.AddSnack(InputArray[i]);
                        if (i == InputArray.Length - 1)
                        {
                            Elves.Add(currentElf);
                        }
                    }
                    else
                    {
                        Elves.Add(currentElf);
                        currentElf = new ElfCaloriePack(elfCount++);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public int GetFirstNonBlankLine()
        {
            for (int i = 0; i < InputArray.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(InputArray[i]))
                {
                    return i;
                }
            }
            throw new Exception("No Elves Found.");
        }

        public int GetElfWithMostCalories()
        {
            if (Elves.Count == 0) throw new Exception("Cannot Get ElfId if there are no Elves.");

            var orderElves = Elves.OrderByDescending(x => x.TotalCaloriesHeld);

            return orderElves.First().ElfId;
        }

        public int GetCalorieCountOfElfById(int elfId) => Elves[elfId].TotalCaloriesHeld;

    }

    public class ElfCaloriePack
    {
        public int ElfId { get; set; }
        public List<int> CalorioSnacks { get; set; }
        public int TotalCaloriesHeld { get { return GetTotalCalories(); } }

        public ElfCaloriePack(int elfId)
        {
            ElfId = elfId;
            CalorioSnacks = new List<int>();
        }

        private int GetTotalCalories()
        {
            return CalorioSnacks.Sum();
        }

        public void AddSnack(int calorieSnack)
        {
            CalorioSnacks.Add(calorieSnack);
        }

        public void AddSnack(string calorieSnack)
        {
            if (Int32.TryParse(calorieSnack, out var snack))
            {
                CalorioSnacks.Add(snack);
            }
            else
            {
                throw new Exception("Invalid Snack. Elf is carrying Contraband. Notfiy appropriate Elf leaders.");
            }
        }
    }
}
