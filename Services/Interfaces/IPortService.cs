using System.Collections.Generic;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services.Interfaces
{
    /// <summary>
    /// The port service handles port events.
    /// </summary>
    public interface IPortService
    {
        /// <summary>
        /// Initializes a port.
        /// </summary>
        /// <remarks>
        /// It initializes the ships that the port holds.
        /// </remarks>
        /// <param name="port">
        /// The port that should be initialized.
        /// </param>
        public void InitializePort(Port port);

        /// <summary>
        /// Get a list of shi[s with the specified transport states.
        /// </summary>
        /// <param name="port">
        /// The port of the ships.
        /// </param>
        /// <param name="states">
        /// The specified states where the ships will be filtered on.
        /// </param>
        /// <returns>
        /// A list of ships.
        /// </returns>
        public List<Ship> GetShipsByState(Port port, TransportState[] states);

        /// <summary>
        /// Load the available ships with the first available container.
        /// </summary>
        /// <param name="port">
        /// The port of the ships that should be loaded.
        /// </param>
        public void LoadShips(Port port);

        /// <summary>
        /// Reset the port to an empty state.
        /// </summary>
        /// <remarks>
        /// It clears the port and container list.
        /// </remarks>
        /// <param name="port">
        /// The port that should be reset.
        /// </param>
        public void ResetPort(Port port);
    }
}
