using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day2
{
    public class Day2Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(2, 1);

        public string GetSolution()
        {
            string[] filelines = PuzzleHelper.ReadPuzzleDataFile("Day2Part1.txt");
            var opcodes = new List<int>();

            foreach (string line in filelines)
            {
                opcodes.AddRange(line.Split(",").Select(opcode => Convert.ToInt32(opcode)));
            }

            // Alter some values
            opcodes[1] = 12;
            opcodes[2] = 2;

            for (int position = 0; position < opcodes.Count; position += 4)
            {
                int command = opcodes[position];
                int firstValuePosition = opcodes[position + 1];
                int secondValuePosition = opcodes[position + 2];
                int resultValuePosition = opcodes[position + 3];

                // Stop the program and return the value on position 0
                if (command == 99)
                {
                    return opcodes[0].ToString();
                }

                // Add the first and second value and store the result in the correct location
                if (command == 1)
                {
                    opcodes[resultValuePosition] = opcodes[firstValuePosition] + opcodes[secondValuePosition];
                }

                if (command == 2)
                {
                    opcodes[resultValuePosition] = opcodes[firstValuePosition] * opcodes[secondValuePosition];
                }
            }

            throw new InvalidOperationException("No result found while running the Intcode program");
        }
    }
}