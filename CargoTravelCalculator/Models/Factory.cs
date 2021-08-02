using System.Collections.Generic;

namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// A factory is a facility with the purpose of distributing the cargo that is coming in via trucks.
    /// </summary>
    /// <remarks>
    /// This facility has a list of <see cref="Trucks"/> that distribute the cargo.
    /// </remarks>
    public class Factory : Facility
    {
        public List<Truck> Trucks { get; set; }

        public Factory()
        {
            Trucks = new List<Truck>();
        }
    }
}