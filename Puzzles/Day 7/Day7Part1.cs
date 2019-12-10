using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day7
{
    public class Day7Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(7, 1);

        public string GetSolution()
        {
            var amp5 = new Amplifier(5, null);
            var amp4 = new Amplifier(4, amp5);
            var amp3 = new Amplifier(3, amp4);
            var amp2 = new Amplifier(2, amp3);
            var amp1 = new Amplifier(1, amp2);
            
            int output = amp1.CalculateOutputSignal(0);

            return output.ToString();
        }
    }
}