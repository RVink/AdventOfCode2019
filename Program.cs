using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Puzzles;

namespace AdventOfCode2019
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, IPuzzle> availablePuzzles = GetAvailablePuzzles();

            Console.WriteLine("Welcome to the AdventOfCode puzzle solver!");
            Console.WriteLine("Enter puzzle day:");
            string dayString = Console.ReadLine();
            
            if (int.TryParse(dayString, out int day))
            {
                Console.WriteLine("Enter puzzle day part:");
                string partString = Console.ReadLine();

                if (int.TryParse(partString, out int part))
                {
                    string puzzleIdentifier = PuzzleHelper.GetPuzzleIdentifier(day, part);
                    if (!availablePuzzles.ContainsKey(puzzleIdentifier))
                    {
                        Console.WriteLine("The entered puzzle cannot be found.");
                    }
                    else
                    {
                        IPuzzle puzzle = availablePuzzles[puzzleIdentifier];

                        string solution = puzzle.GetSolution();
                        Console.WriteLine($"Solution: {solution}");
                    }
                }
                else
                {
                    Console.WriteLine("The entered part is invalid!");
                }
            }
            else
            {
                Console.WriteLine("The entered day is invalid!");
            }

            Console.WriteLine("See you soon?");
        }

        private static Dictionary<string, IPuzzle> GetAvailablePuzzles()
        {
            var puzzletypes = from assembly in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
                                from type in assembly.GetTypes()
                                where !type.IsInterface && !type.IsAbstract && typeof(IPuzzle).IsAssignableFrom(type)
                                select type;

            var puzzleInstances = new Dictionary<string, IPuzzle>();
            foreach (var puzzleType in puzzletypes)
            {
                var instance = Activator.CreateInstance(puzzleType) as IPuzzle;
                puzzleInstances.Add(instance.PuzzleIdentifier, instance);
            }

            return puzzleInstances;
        }
    }
}
