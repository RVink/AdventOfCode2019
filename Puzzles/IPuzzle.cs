namespace AdventOfCode2019.Puzzles
{
    public interface IPuzzle
    {
        string PuzzleIdentifier { get; }

        string GetSolution();
    }
}