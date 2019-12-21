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

        public Dictionary<int, Vector2> StartVaporization(Vector2 fromAsteroid)
        {
            var vaporizationOrder = new Dictionary<int, Vector2>();

            // Determine angles of asteroids and group them together 
            var asteroidsPerAngle = new Dictionary<double, List<Vector2>>();
            foreach (var asteroid in _asteroids.Where(a => a != fromAsteroid))
            {
                var angle = Math.Atan2(asteroid.Y - fromAsteroid.Y, asteroid.X - fromAsteroid.X) * (180 / Math.PI);
                // Add 360 as long if the angle is negative to make it a positive value
                while(angle < 0) {
                    angle += 360.0;
                }

                if (asteroidsPerAngle.ContainsKey(angle))
                {
                    // If angle already exists then add the asteroid
                    List<Vector2> asteroids = asteroidsPerAngle.Single(x => x.Key == angle).Value;
                    asteroids.Add(asteroid);
                }
                else
                {
                    // Add a new angle an the asteroid
                    asteroidsPerAngle.Add(angle, new List<Vector2> { asteroid });
                }
            }

            // Order the asteroid angles from 0 to 360 degrees
            var asteroidsPerAngleOrdered = asteroidsPerAngle.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            // Up is rotated 90 degrees to the right. Make sure the turrent is pointing up
            double turrentAngle = 270.0;
            int varporizedIndex = 1;

            // Determine the starting point
            KeyValuePair<double, List<Vector2>> turrentPointingAt = asteroidsPerAngleOrdered.Where(x => x.Key >= turrentAngle).OrderBy(x => x.Key).First();

            // Stop vaporizing if no asteroids are left
            while (asteroidsPerAngleOrdered.SelectMany(x => x.Value).Any())
            {
                // Update the turrent angle
                turrentAngle = turrentPointingAt.Key;

                // Determine which asteroid to vaporize
                int mostNearbyAsteroidDistance = 0;
                Vector2? mostNearbyAsteroid = null;
                foreach (var asteroid in turrentPointingAt.Value)
                {
                    int distance = Convert.ToInt32(Math.Abs(fromAsteroid.X - asteroid.X) + Math.Abs(fromAsteroid.Y - asteroid.Y));
                    if (mostNearbyAsteroidDistance == 0 || ((distance > 0 && mostNearbyAsteroidDistance > distance) || (distance < 0 && mostNearbyAsteroidDistance < distance)))
                    {
                        mostNearbyAsteroidDistance = distance;
                        mostNearbyAsteroid = asteroid;
                    }
                }

                // Vaporize the asteroid if found
                if (mostNearbyAsteroid.HasValue)
                {
                    turrentPointingAt.Value.Remove(mostNearbyAsteroid.Value);
                    vaporizationOrder.Add(varporizedIndex, mostNearbyAsteroid.Value);
                    varporizedIndex++;
                }

                // Determine next angle to look at
                if (asteroidsPerAngleOrdered.Any(x => x.Key > turrentAngle))
                {
                    turrentPointingAt = asteroidsPerAngleOrdered.Where(x => x.Key > turrentAngle).OrderBy(x => x.Key).First();
                }
                else
                {
                    // Check at degree 0 if nothing else is found
                    turrentPointingAt = asteroidsPerAngleOrdered.Where(x => x.Key >= 0).OrderBy(x => x.Key).First();
                }
            }

            return vaporizationOrder;
        }
    }
}