using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2019.Puzzles.Day10
{
    public class AsteroidBelt
    {
        private List<Vector2> _asteroids = new List<Vector2>();

        public void AddAsteroid(Vector2 location)
        {
            _asteroids.Add(location);
        }

        public KeyValuePair<Vector2, int> FindSuitableMonitoringStationLocation()
        {
            Vector2 location = new Vector2(-1, -1);
            int highestObservableAsteroids = 0;

            foreach (var asteroid in _asteroids)
            {
                int observableAsteroids = DetermineObservableAsteroids(asteroid);

                if (highestObservableAsteroids < observableAsteroids)
                {
                    location = asteroid;
                    highestObservableAsteroids = observableAsteroids;
                }
            }

            return new KeyValuePair<Vector2, int>(location, highestObservableAsteroids);
        }

        private int DetermineObservableAsteroids(Vector2 fromAsteroid)
        {
            var observableAsteroids = new Dictionary<double, Vector2>();
            foreach (var asteroid in _asteroids.Where(a => a != fromAsteroid))
            {
                var angle = Math.Atan2(asteroid.Y - fromAsteroid.Y, asteroid.X - fromAsteroid.X) * (180 / Math.PI);

                if (!observableAsteroids.ContainsKey(angle))
                {
                    observableAsteroids.Add(angle, asteroid);
                }
            }
            return observableAsteroids.Count;
        }
    }
}