using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Day3Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(3, 2);

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

                int wire1IntersectionIndex = wire1.Path.FindIndex(x => x.X == intersection.X && x.Y == intersection.Y);
                int wire2IntersectionIndex = wire2.Path.FindIndex(x => x.X == intersection.X && x.Y == intersection.Y);
                int totalSteps = wire1IntersectionIndex + wire2IntersectionIndex;

                if (totalSteps < result)
                {
                    result = totalSteps;
                }
            }

            return result.ToString();
        }
    }
}