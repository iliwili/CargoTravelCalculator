using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Models;
using CargoTravelCalculator.Services.Interfaces;

namespace CargoTravelCalculator.Services
{
    /// <inheritdoc cref="IShipService"/>
    public class ShipService : IShipService
    {
        public void LoadShip(Ship ship, Container container)
        {
            if (ship != null)
            {
                ship.Container = container;
                ship.State = TransportState.Delivering;
                ship.GoTo = container.Destination;
            }
        }

        public void UnloadShip(Ship ship)
        {
            ship.GoTo = ship.CameFrom;
            ship.CameFrom = ship.Container.Destination;
            ship.State = TransportState.Returning;
            ship.HoursMoving = 0;
            ship.Container = null;
        }

        public void HandleShipArrival(Ship ship, List<Container> containers, Port port, Warehouse warehouse)
        {
            // checking if the ship arrived at the destination
            if (Settings.StartEndPointMap.FirstOrDefault(t => t.Key == ship.StartEndPoint).Value - ship.HoursMoving == 0)
            {
                var container = ship.Container;
                switch (ship.GoTo)
                {
                    case "A":
                        warehouse.Containers.Add(container);
                        UnloadShip(ship);
                        containers.Remove(container);
                        break;
                    case "P":
                        ship.CameFrom = "P";
                        ship.GoTo = "";
                        ship.State = TransportState.Waiting;
                        ship.HoursMoving = 0;
                        break;
                }
            }
        }
    }
}