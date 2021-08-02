using CargoTravelCalculator.Models;
using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Services.Interfaces;

namespace CargoTravelCalculator.Services
{
    /// <inheritdoc cref="IPortService"/>
    public class PortService : IPortService
    {
        private readonly IShipService _shipService;

        public PortService(IShipService shipService)
        {
            _shipService = shipService;
        }

        public void InitializePort(Port port)
        {
            // initialize the number ships that the port needs
            for (int i = 0; i < Settings.NumberOfShips; i++)
            {
                port.Ships.Add(new Ship { Id = $"Ship.{i + 1}" });
            }
        }

        public List<Ship> GetShipsByState(Port port, TransportState[] states)
        {
            return port.Ships.Where(ship => states.Contains(ship.State)).ToList();
        }

        public void LoadShips(Port port)
        {
            // load up the available ships if there are containers available
            port.Containers.ForEach(container =>
            {
                _shipService.LoadShip(port.Ships.Find(t => t.State == TransportState.Waiting), container);
            });

            // removes unloaded containers from the port
            port.Ships.ForEach(truck => port.Containers.RemoveAll(container => container == truck.Container));
        }

        public void ResetPort(Port port)
        {
            port.Containers.Clear();
            port.Ships.Clear();
        }
    }
}