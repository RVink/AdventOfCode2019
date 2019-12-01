using System.Text;
using System.Linq;
using System;

namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(1, 1);

        public string GetSolution()
        {
            int totalFuelNeeded = 0;

            foreach (var line in PuzzleHelper.ReadPuzzleDataFile("Day1Part1.txt"))
            {
                totalFuelNeeded += Convert.ToInt32(Math.Floor(Convert.ToDecimal(line) / 3)) - 2;
            }
            return totalFuelNeeded.ToString();
        }
    }
}