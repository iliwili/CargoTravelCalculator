using System.Collections.Generic;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services.Interfaces
{
    /// <summary>
    /// The facility service calculates the cargo travel time.
    /// </summary>
    public interface IFacilityService
    {
        /// <summary>
        /// Calculates the travel time of the incoming cargo.
        /// </summary>
        /// <param name="cargo">
        /// A sequence of A and B's that represent the cargo.
        /// </param>
        /// <param name="containers">
        /// The different containers that the cargo holds.
        /// </param>
        /// <param name="factory">
        /// The factory where the containers begin their journey.
        /// </param>
        /// <param name="port">
        /// The port where the containers get loaded in and loaded out the the right warehouse.
        /// </param>
        /// <param name="warehouseA">
        /// WarehouseA is a facility that receives containers.
        /// </param>
        /// <param name="warehouseB">
        /// WarehouseB is a facility that receives containers.
        /// </param>
        /// <returns>
        /// The total time it took to get the containers distributed to the right warehouses.
        /// </returns>
        public int CalculateCargoTravelTime(char[] cargo, List<Container> containers, Factory factory, Port port,
            Warehouse warehouseA, Warehouse warehouseB);

        /// <summary>
        /// It writes the state of the trucks and ships to the console.
        /// </summary>
        /// <param name="factory">
        /// The factory that has a list of trucks.
        /// </param>
        /// <param name="port">
        /// The port that has a list of ships.
        /// </param>
        public void LogFacilityTransportStates(Factory factory, Port port);
    }
}
