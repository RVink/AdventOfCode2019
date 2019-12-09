using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Day8Part1 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(8, 1);

        public string GetSolution()
        {
            string[] lines = PuzzleHelper.ReadPuzzleDataFile("Day8Part1.txt");
         
            List<Layer> layers = ParseStringToLayers(lines);
            var layerWithLowestNumber = layers.OrderBy(layer => layer.GetNumberOfPixels(0)).First();
            return (layerWithLowestNumber.GetNumberOfPixels(1) * layerWithLowestNumber.GetNumberOfPixels(2)).ToString();
        }

        private List<Layer> ParseStringToLayers(string[] dataLines)
        {
            var layers = new List<Layer>();
            int layerWidth = 25;
            int layerHeight = 6;
            int digitsPerLayer = layerHeight * layerWidth;

            foreach (var line in dataLines)
            {
                for (int layerNumber = 0; layerNumber < (line.Length / digitsPerLayer); layerNumber++)
                {
                    var layer = new Layer();

                    for (int index = 0; index < digitsPerLayer; index++)
                    {
                        int currentRow = index / layerWidth;
                        Vector2 location = new Vector2(currentRow, index - (currentRow * layerWidth));
                        int value = Convert.ToInt32(line[(layerNumber * digitsPerLayer) + index].ToString());

                        layer.AddPixel(location, value);
                    }

                    layers.Add(layer);
                }
            }

            return layers;
        }
    }
}