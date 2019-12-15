using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class Day10Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(10, 1);

        public string GetSolution()
        {
            var asteroidBelt = new AsteroidBelt();
            string[] map = PuzzleHelper.ReadPuzzleDataFile("Day10Part1.txt");
            for (int lineIndex = 0; lineIndex < map.Length; lineIndex++)
            {
                char[] columns = map[lineIndex].ToCharArray();

                for (int columnIndex = 0; columnIndex < columns.Length; columnIndex++)
                {
                    if (columns[columnIndex] == '#')
                    {
                        asteroidBelt.AddAsteroid(new Vector2(columnIndex, lineIndex));
                    }
                }
            }

            return asteroidBelt.FindSuitableMonitoringStationLocation().Value.ToString();
        }
    }
}