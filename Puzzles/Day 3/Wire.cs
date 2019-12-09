using System;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day3
{
    public class Wire
    {
        public List<Vector2> Path { get; } = new List<Vector2>();

        public void GeneratePath(string path)
        {
            int currentX = 0;
            int currentY = 0;

            // Add the starting point
            Path.Add(new Vector2(currentX, currentY));

            foreach (string pathDirection in path.Split(","))
            {
                // Get the first char
                string direction = pathDirection.Substring(0, 1);
                int length = Convert.ToInt32(pathDirection.Substring(1));

                for (int i = 0; i < length; i++)
                {
                    switch (direction)
                    {
                        // Go up
                        case "U":
                            currentY++;
                            break;
                        case "D":
                            currentY--;
                            break;
                        case "L":
                            currentX--;
                            break;
                        case "R":
                            currentX++;
                            break;
                    }

                    Path.Add(new Vector2(currentX, currentY));
                }
            }
        }
    }
}