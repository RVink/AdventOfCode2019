using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Layer
    {
        public List<Pixel> Pixels { get; } = new List<Pixel>();

        public void AddPixel(Vector2 location, int pixelValue)
        {
            if (Pixels.Any(pixel => pixel.Location == location))
            {
                throw new InvalidOperationException("The pixel already exists");
            }

            Pixels.Add(new Pixel(location, pixelValue));
        }

        public int GetNumberOfPixels(int pixelValue)
        {
            return Pixels.Count(pixel => pixel.Value == pixelValue);
        }

        public int GetPixelValueAt(Vector2 location)
        {
            return Pixels.Single(pixel => pixel.Location == location).Value;
        }
    }
}