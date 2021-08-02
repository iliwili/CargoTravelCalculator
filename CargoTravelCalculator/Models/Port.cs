using System.Collections.Generic;

namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// A port is a facility with the purpose of distributing the cargo that is coming in via ships.
    /// </summary>
    /// /// <remarks>
    /// This facility has a list of <see cref="Ships"/> that distribute the cargo.
    /// </remarks>
    public class Port : Facility
    {
        public List<Ship> Ships { get; set; }

        public Port()
        {
            Ships = new List<Ship>();
        }
    }
}