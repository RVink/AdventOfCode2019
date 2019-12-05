using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(4, 1);

        public string GetSolution()
        {
            var validator = new PasswordValidator();
            IEnumerable<int> passwords = validator.GetValidPasswords(165432, 707912);

            foreach (var password in passwords)
            {
                Console.WriteLine($"Valid password: {password}");
            }

            return passwords.Count().ToString();
        }
    }
}