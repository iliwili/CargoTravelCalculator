using System.Collections.Generic;

namespace CargoTravelCalculator.Models
{
    public class Facility
    {
        public List<Container> Containers { get; set; }

        public Facility()
        {
            Containers = new List<Container>();
        }
    }
}