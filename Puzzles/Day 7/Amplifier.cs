using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Amplifier
    {
        private Amplifier _nextAmplifier = null;

        public int Id { get; private set; }

        public Amplifier(int id, Amplifier nextAmplifier)
        {
            Id = id;
            _nextAmplifier = nextAmplifier;
        }

        public int CalculateOutputSignal(int inputSignal, IEnumerable<int> usedPhaseSettings = null)
        {
            string[] filelines = PuzzleHelper.ReadPuzzleDataFile("Day7Part1.txt");
            var opcodes = new List<int>();
            int totalOutput = 0;

            // Make sure the usedPhaseSettings array exists
            if (usedPhaseSettings == null)
            {
                usedPhaseSettings = new int[] {};
            }

            foreach (string line in filelines)
            {
                opcodes.AddRange(line.Split(",").Select(opcode => Convert.ToInt32(opcode)));
            }

            for (int phaseSetting = 0; phaseSetting <= 4; phaseSetting++)
            {
                if (usedPhaseSettings.Contains(phaseSetting))
                {
                    // Phase setting already used. Skip...
                    continue;
                }

                var computer = new IntcodeComputer.IntcodeComputer();
                int output = computer.RunProgram(opcodes.ToList().ToArray(), new int[] {phaseSetting, inputSignal});

                if (_nextAmplifier != null)
                {
                    output = _nextAmplifier.CalculateOutputSignal(output, usedPhaseSettings.Concat(new int[] {phaseSetting}));
                }

                if (output > totalOutput)
                {
                    totalOutput = output;
                }
            }

            return totalOutput;
        }
    }
}