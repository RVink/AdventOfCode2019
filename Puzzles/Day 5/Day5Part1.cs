
using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2019.Puzzles.Day5
{
    public class Day5Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(5, 1);

        public string GetSolution()
        {
            string[] filelines = PuzzleHelper.ReadPuzzleDataFile("Day5Part1.txt");
            var opcodes = new List<int>();

            foreach (string line in filelines)
            {
                opcodes.AddRange(line.Split(",").Select(opcode => Convert.ToInt32(opcode)));
            }

            var instance = new IntcodeComputer.IntcodeComputer();

            return instance.RunProgram(opcodes.ToArray(), 1).ToString();
        }
    }
}