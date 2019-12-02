using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(2, 2);
        private const int EXPECTED_OUTPUT = 19690720;

        public string GetSolution()
        {
            string[] filelines = PuzzleHelper.ReadPuzzleDataFile("Day2Part1.txt");
            var opcodes = new List<int>();

            foreach (string line in filelines)
            {
                opcodes.AddRange(line.Split(",").Select(opcode => Convert.ToInt32(opcode)));
            }

            // Brute force the value
            var program = new IntcodeProgram(opcodes.ToArray());
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0 ; verb <= 99; verb++)
                {
                    int result = program.RunProgram(noun, verb);

                    if (result == EXPECTED_OUTPUT)
                    {
                        return (100 * noun + verb).ToString();
                    }
                    else
                    {
                        program.ResetProgramMemory();
                    }
                }
            }

            throw new InvalidOperationException("Result not found!");

        }
    }
}