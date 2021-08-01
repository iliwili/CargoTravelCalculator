using System.Collections.Generic;
using System.Linq;

namespace CargoTravelCalculator.Models
{
    public class Port : Facility
    {
        public List<Ship> Ships { get; set; }

        public Port() : base()
        {
            Ships = new List<Ship>();
        }
    }
}