using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Pixel
    {
        public Vector2 Location { get; private set; }

        public int Value { get; private set; }

        public Pixel(Vector2 location, int value)
        {
            Location = location;
            Value = value;
        }
    }
}