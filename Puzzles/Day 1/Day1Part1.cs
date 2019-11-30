using System.Text;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day1
{
    public class Day1Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(1, 1);

        public string GetSolution()
        {
            StringBuilder sb = new StringBuilder();

            PuzzleHelper.ReadPuzzleDataFile("Day1Part1.txt").ToList().ForEach(x => sb.AppendLine(x));

            return sb.ToString();
        }
    }
}