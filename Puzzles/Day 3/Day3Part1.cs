using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Day3Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(3, 1);

        public string GetSolution()
        {
            int result = int.MaxValue;
            string[] datalines = PuzzleHelper.ReadPuzzleDataFile("Day3Part1.txt");

            var wire1 = new Wire();
            wire1.GeneratePath(datalines[0]);

            var wire2 = new Wire();
            wire2.GeneratePath(datalines[1]);

            var intersections = wire1.Path.Intersect(wire2.Path);
            foreach (var intersection in intersections)
            {
                if (intersection.X == 0 && intersection.Y == 0)
                {
                    continue;
                }

                int length = Convert.ToInt32(Math.Abs(intersection.X) + Math.Abs(intersection.Y));
                if (result >= length)
                {
                    result = length;
                }
            }

            return result.ToString();
        }
    }
}