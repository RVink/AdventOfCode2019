using System.Linq;

namespace AdventOfCode2019.Puzzles.Day6
{
    public class Day6Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(6, 2);

        public string GetSolution()
        {
            string[] orbits = PuzzleHelper.ReadPuzzleDataFile("Day6Part1.txt");

            var orbitalMap = new OrbitalMap();
            orbitalMap.GenerateMap(orbits);

            var you = orbitalMap.Planets.Single(planet => planet.Name == "YOU");
            var santa = orbitalMap.Planets.Single(planet => planet.Name == "SAN");

            int totalTransfers = orbitalMap.GetNumberOfOrbitalTransfersBetween(you, santa);
            // Don't count the jumps for you and santa
            totalTransfers -= 2;
            return totalTransfers.ToString();
        }
    }
}