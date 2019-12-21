using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class Day10Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(10, 2);

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

            KeyValuePair<Vector2, int> bestLocation = asteroidBelt.FindSuitableMonitoringStationLocation();
            Dictionary<int, Vector2> vaporationOrder = asteroidBelt.StartVaporization(bestLocation.Key);

            Vector2 puzzleOucome = vaporationOrder[200];

            return ((puzzleOucome.X * 100) + puzzleOucome.Y).ToString();
        }
    }
}