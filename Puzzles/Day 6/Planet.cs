using System.Collections.Generic;

namespace AdventOfCode2019.Puzzles.Day6
{
    public class Planet
    {
        public string Name { get; private set; }

        public Planet Orbits { get; private set; }

        public List<Planet> PlanetsOrbitting { get; } = new List<Planet>();

        public Planet(string name)
        {
            Name = name;
        }

        public void SetOrbittingPlanet(Planet orbittingPlanet)
        {
            Orbits = orbittingPlanet;
            orbittingPlanet.AddPlanetOrbittingThisPlanet(this);
        }

        public void AddPlanetOrbittingThisPlanet(Planet planetOrbitting)
        {
            this.PlanetsOrbitting.Add(planetOrbitting);
        }
    }
}