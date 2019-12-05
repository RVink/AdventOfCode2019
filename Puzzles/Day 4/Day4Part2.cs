using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2019.Puzzles.Day4
{
    public class Day4Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(4, 2);

        public string GetSolution()
        {
            var validator = new PasswordValidator();
            var passwords = new List<int>();

            foreach (var password in validator.GetValidPasswords(165432, 707912))
            {
                if (password.ToString().ToCharArray().GroupBy(x => x).Any(x => x.Count() == 2))
                {
                    Console.WriteLine($"Valid password: {password}");
                    passwords.Add(password);
                }
            }

            return passwords.Count().ToString();
        }
    }
}