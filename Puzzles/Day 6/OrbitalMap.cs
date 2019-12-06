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