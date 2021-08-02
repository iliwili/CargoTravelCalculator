using System.Collections.Generic;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services.Interfaces
{
    /// <summary>
    /// The truck service handles the un/loading and arrival of trucks.
    /// </summary>
    public interface ITruckService
    {
        /// <summary>
        /// Loads up the container on the truck and sends the truck to the warehouse.
        /// </summary>
        /// <param name="truck">
        /// The truck that gets loaded up with a container.
        /// </param>
        /// <param name="container">
        /// The container that gets in the truck.
        /// </param>
        public void LoadTruck(Truck truck, Container container);

        /// <summary>
        /// Unloads the container from the truck and sends the truck back to the factory.
        /// </summary>
        /// <param name="truck">
        /// The truck that gets unloaded.
        /// </param>
        public void UnloadTruck(Truck truck);

        /// <summary>
        /// Handles the arrival of the truck at the factory, port or warehouse.
        /// </summary>
        /// <remarks>
        /// This method checks if the truck arrived at the destination.
        /// If the truck arrives at the warehouse, the ship gets unloaded and sent back to the port.
        /// If the truck arrives at the port, the ship gets unloaded and sent back to the port.
        /// If the ship arrives at the factory, the ship gets loaded up if there are containers left.
        /// </remarks>
        /// <param name="truck">
        /// The truck that arrives at the factory, port or warehouse.
        /// </param>
        /// <param name="containers">
        /// The list of containers that are moved between facilities.
        /// </param>
        /// <param name="port">
        /// The port where the truck delivers the container.
        /// </param>
        /// <param name="warehouse">
        /// The warehouse where the ship delivers the container.
        /// </param>
        public void HandleTruckArrival(Truck truck, List<Container> containers, Port port, Warehouse warehouse);
    }
}
