using CargoTravelCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoTravelCalculator.Services
{
    public class PortService
    {
        private readonly ShipService _shipService;

        public PortService()
        {
            _shipService = new ShipService();
        }

        public List<Ship> GetShipsByState(Port port, TransportState[] states)
        {
            return port.Ships.Where(ship => states.Contains(ship.State)).ToList();
        }

        public void LoadShips(Port port)
        {
            port.Containers.ForEach(container =>
            {
                _shipService.LoadShip(port.Ships.Find(t => t.State == TransportState.Waiting), container);
            });

            port.Ships.ForEach(truck => port.Containers.RemoveAll(container => container == truck.Container));
        }

        public void ResetPort(Port port)
        {
            port.Containers.Clear();
            port.Ships.Clear();
        }

        public void PrintCurrentState(Port port)
        {
            foreach (Ship ship in port.Ships)
            {
                Console.WriteLine($"Ship:  {ship.Id,-8} State: {ship.State,-10} Start-EndPoint: {ship.StartEndPoint}");
            }
        }
    }
}