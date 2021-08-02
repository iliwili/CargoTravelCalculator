using System.Collections.Generic;

namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// A place provided for a particular purpose.
    /// </summary>
    /// <remarks>
    /// All the facilites in this project have a list of containers.
    /// </remarks>
    public class Facility
    {
        public List<Container> Containers { get; set; }

        public Facility()
        {
            Containers = new List<Container>();
        }
    }
}