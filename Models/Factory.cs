using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CargoTravelCalculator.Models
{
    public class Factory : Facility
    {
        public List<Truck> Trucks { get; set; }

        public Factory() : base()
        {
            Trucks = new List<Truck>();
        }
    }
}