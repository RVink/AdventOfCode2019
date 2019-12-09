using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2019.Puzzles.Day8
{
    public class Day8Part2 : IPuzzle
    {
        public string PuzzleIdentifier => PuzzleHelper.GetPuzzleIdentifier(8, 2);

        public string GetSolution()
        {
            string[] lines = PuzzleHelper.ReadPuzzleDataFile("Day8Part1.txt");
         
            List<Layer> layers = ParseStringToLayers(lines);
            StringBuilder sb = new StringBuilder();

            int layerWidth = 25;
            int layerHeight = 6;

            for (var layerRowIndex = 0; layerRowIndex < layerHeight; layerRowIndex++)
            {
                sb.AppendLine();
                for (var layerColumnIndex = 0; layerColumnIndex < layerWidth; layerColumnIndex++)
                {
                    var colorFound = false;
                    foreach (var layer in layers)
                    {
                        var location = new Vector2(layerRowIndex, layerColumnIndex);
                        if (layer.GetPixelValueAt(location) == 0)
                        {
                            sb.Append("-");
                            colorFound = true;
                            break;
                        }

                        if (layer.GetPixelValueAt(location) == 1)
                        {
                            sb.Append("#");
                            colorFound = true;
                            break;
                        }
                    }

                    if (!colorFound)
                    {
                        sb.Append(" ");
                    }
                }
            }

            return sb.ToString();
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