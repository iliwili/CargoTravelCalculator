using System.Collections.Generic;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services.Interfaces
{
    /// <summary>
    /// The factory service handles factory events.
    /// </summary>
    public interface IFactoryService
    {
        /// <summary>
        /// Initializes a factory.
        /// </summary>
        /// <remarks>
        /// It initializes the trucks and containers that the factory holds.
        /// </remarks>
        /// <param name="factory">
        /// The factory that should be initialized.
        /// </param>
        /// <param name="containers">
        /// The containers that the factory should receive and eventually distribute.
        /// </param>
        public void InitializeFactory(Factory factory, List<Container> containers);

        /// <summary>
        /// Get a list of trucks with the specified transport states.
        /// </summary>
        /// <param name="factory">
        /// The factory of the trucks.
        /// </param>
        /// <param name="states">
        /// The specified states where the trucks will be filtered on.
        /// </param>
        /// <returns>
        /// A list of trucks.
        /// </returns>
        public List<Truck> GetTrucksByState(Factory factory, TransportState[] states);

        /// <summary>
        /// Load the available trucks with the first available container.
        /// </summary>
        /// <param name="factory">
        /// The factory of the trucks that should be loaded.
        /// </param>
        public void LoadTrucks(Factory factory);

        /// <summary>
        /// Reset the factory to an empty state.
        /// </summary>
        /// <remarks>
        /// It clears the port and container list.
        /// </remarks>
        /// <param name="factory">
        /// The factory that should be reset.
        /// </param>
        public void ResetFactory(Factory factory);
    }
}
