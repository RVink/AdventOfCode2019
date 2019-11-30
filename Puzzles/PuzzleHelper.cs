using System.IO;

namespace AdventOfCode2019.Puzzles
{
    public static class PuzzleHelper
    {
        public static string GetPuzzleIdentifier(int day, int part)
        {
            return $"Day{day}Part{part}";
        }

        public static string[] ReadPuzzleDataFile(string fileName)
        {
            return File.ReadAllLines(Path.Join(Directory.GetCurrentDirectory(), "PuzzleData", fileName));
        }
    }
}