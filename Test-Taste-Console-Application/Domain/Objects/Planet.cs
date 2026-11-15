using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get => 0.0f;
        }

        public double? AverageMoonTemperatureKelvin
        {
            get
            {
                // Select only moons with available temperature data.
                var temperatures = Moons
                    .Where(m => m.AverageTemperatureKelvin.HasValue)
                    .Select(m => (double)m.AverageTemperatureKelvin.Value)
                    .ToList();

                // Return null if no moon has temperature data.
                if (!temperatures.Any())
                {
                    return null;
                }

                // Calculate the average temperature.
                return temperatures.Average();
            }
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
