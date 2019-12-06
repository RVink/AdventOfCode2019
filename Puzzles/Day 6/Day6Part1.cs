namespace AdventOfCode2019.Puzzles.Day6
{
    public class Day6Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(6, 1);

        public string GetSolution()
        {
            string[] orbits = PuzzleHelper.ReadPuzzleDataFile("Day6Part1.txt");

            var orbitalMap = new OrbitalMap();
            orbitalMap.GenerateMap(orbits);

            return orbitalMap.GetTotalOrbits().ToString();
        }
    }
}