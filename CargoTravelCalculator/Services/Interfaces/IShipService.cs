using System.Collections.Generic;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services.Interfaces
{
    /// <summary>
    /// The ship service handles the un/loading and arrival of ships.
    /// </summary>
    public interface IShipService
    {
        /// <summary>
        /// Loads up the container on the ship and sends the ship to the warehouse.
        /// </summary>
        /// <param name="ship">
        /// The ship that gets loaded up with a container.
        /// </param>
        /// <param name="container">
        /// The container that gets in the ship.
        /// </param>
        public void LoadShip(Ship ship, Container container);

        /// <summary>
        /// Unloads the container from the ship and sends the ship back to the port.
        /// </summary>
        /// <param name="ship">
        /// The ship that gets unloaded.
        /// </param>
        public void UnloadShip(Ship ship);

        /// <summary>
        /// Handles the arrival of the ship at the port or the warehouse.
        /// </summary>
        /// <remarks>
        /// This method checks if the ship arrived at the destination.
        /// If the ship arrives at the warehouse, the ship gets unloaded and sent back to the port.
        /// If the ship arrives at the port, the ship gets loaded up if there are containers left.
        /// </remarks>
        /// <param name="ship">
        /// The ship that arrives at the port or the warehouse.
        /// </param>
        /// <param name="containers">
        /// The list of containers that are moved between facilities.
        /// </param>
        /// <param name="port">
        /// The port where the ship arrives after transporting a container.
        /// </param>
        /// <param name="warehouse">
        /// The warehouse where the ship delivers the container.
        /// </param>
        public void HandleShipArrival(Ship ship, List<Container> containers, Port port, Warehouse warehouse);
    }
}
