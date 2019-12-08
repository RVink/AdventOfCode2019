using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day6
{
    public class OrbitalMap
    {
        public List<Planet> Planets { get; } = new List<Planet>();

        public void GenerateMap(string[] orbits)
        {
            foreach (var orbit in orbits)
            {
                var planets = orbit.Split(")");
                
                // Create or get planet 1
                var planet1 = Planets.SingleOrDefault(planet => planet.Name == planets[0]);
                if (planet1 == null)
                {
                    planet1 = new Planet(planets[0]);
                    Planets.Add(planet1);
                }

                // Create or get planet 2
                var planet2 = Planets.SingleOrDefault(planet => planet.Name == planets[1]);
                if (planet2 == null)
                {
                    planet2 = new Planet(planets[1]);
                    Planets.Add(planet2);
                }

                // Set the planet 2 as the orbitting planet of planet 1
                planet2.SetOrbittingPlanet(planet1);
            }
        }

        public int GetTotalOrbits()
        {
            int totalOrbits = 0;
            foreach (var planet in Planets.Where(planet => planet.Orbits != null))
            {
                totalOrbits += CountOrbits(planet);
            }

            return totalOrbits;
        }

        public int GetNumberOfOrbitalTransfersBetween(Planet from, Planet to)
        {
            return FindPathAndCountTranfers(from, from , to);
        }

        private int FindPathAndCountTranfers(Planet comingFrom, Planet from, Planet to)
        {
            int totalTransfers = 0;

            // Check if the current planet orbits the target or has it as an orbitting planet
            if (from.PlanetsOrbitting.Where(planet => planet != comingFrom).Contains(to) || from.Orbits == to)
            {
                return 1;
            }

            // Try every orbitting planet and search for a path
            foreach (var planet in from.PlanetsOrbitting.Where(planet => planet != comingFrom))   
            {
                totalTransfers += FindPathAndCountTranfers(from, planet, to);

                // If a path is found then count it as a hop
                if (totalTransfers > 0)
                {
                    return totalTransfers + 1;
                }
            }

            // If none of the orbitting planets has a connection to the target planet then try the parent
            if (totalTransfers == 0 && from.Orbits != comingFrom)
            {
                totalTransfers += FindPathAndCountTranfers(comingFrom, from.Orbits, to);
                // Count this as a hop
                return totalTransfers + 1;
            }

            return totalTransfers;
        }

        private int CountOrbits(Planet planet)
        {
            if (planet.Orbits == null)
            {
                return 0;
            }

            return CountOrbits(planet.Orbits) + 1;
        }
    }
}