using System.Text;
using System.Linq;
using System;

namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(1, 2);

        public string GetSolution()
        {
            int totalFuelNeeded = 0;

            foreach (var line in PuzzleHelper.ReadPuzzleDataFile("Day1Part1.txt"))
            {
                int fuelNeededForModule = CalculateFuel(Convert.ToInt32(line));

                bool fuelNeededForFuelMass = true;
                int additionalFuel = fuelNeededForModule;
                while (fuelNeededForFuelMass)
                {
                    additionalFuel = CalculateFuel(additionalFuel);

                    if (additionalFuel <= 0)
                    {
                        fuelNeededForFuelMass = false;
                    }
                    else
                    {
                        fuelNeededForModule += additionalFuel;
                    }
                }

                totalFuelNeeded += fuelNeededForModule;
            }

            return totalFuelNeeded.ToString();
        }

        private int CalculateFuel(int mass)
        {
            return  Convert.ToInt32(Math.Floor(Convert.ToDecimal(mass) / 3)) - 2;
        }
    }
}