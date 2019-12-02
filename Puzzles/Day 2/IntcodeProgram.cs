using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.Day2
{
    public class IntcodeProgram
    {
        private int[] _initialOpCodes;
        private int[] _opcodes;
        private bool _programLoaded = false;

        public IntcodeProgram(int[] opcodes)
        {
            // Make sure to use a clone
            _opcodes = opcodes.ToArray();
            _initialOpCodes = opcodes.ToArray();
            _programLoaded = true;
        }

        public void ResetProgramMemory()
        {
            if (!_programLoaded)
            {
                throw new InvalidOperationException("The program cannot be reset as it has not been loaded");
            }

            // Make sure to use a clone
            _opcodes = _initialOpCodes.ToArray();
        }

        public int RunProgram(int noun, int verb)
        {
            if (!_programLoaded)
            {
                throw new InvalidOperationException("The program cannot be run as it has not been loaded");
            }

            // Alter some values
            _opcodes[1] = noun;
            _opcodes[2] = verb;

            for (int position = 0; position < _opcodes.Count(); position += 4)
            {
                int command = _opcodes[position];
                int firstValuePosition = _opcodes[position + 1];
                int secondValuePosition = _opcodes[position + 2];
                int resultValuePosition = _opcodes[position + 3];

                // Stop the program and return the value on position 0
                if (command == 99)
                {
                    return _opcodes[0];
                }

                // Add the first and second value and store the result in the correct location
                if (command == 1)
                {
                    _opcodes[resultValuePosition] = _opcodes[firstValuePosition] + _opcodes[secondValuePosition];
                }

                if (command == 2)
                {
                    _opcodes[resultValuePosition] = _opcodes[firstValuePosition] * _opcodes[secondValuePosition];
                }
            }

            throw new InvalidOperationException("No result found while running the Intcode program");
        }
    }
}