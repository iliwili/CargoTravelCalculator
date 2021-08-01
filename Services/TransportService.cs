using CargoTravelCalculator.Models;
using CargoTravelCalculator.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace CargoTravelCalculator.Services
{
    public class TransportService
    {
        private readonly TruckService _truckService;
        private readonly ShipService _shipService;

        public TransportService()
        {
            _truckService = new TruckService();
            _shipService = new ShipService();
        }

        public void HandleTruckArrival(Truck truck, List<Container> containers, Port port, Warehouse warehouseB)
        {
            if (_truckService.HasArrived(truck, Settings.StartEndPointMap.FirstOrDefault(t => t.Key == truck.StartEndPoint).Value))
            {
                var container = truck.Container;
                switch (truck.GoTo)
                {
                    case "P":
                        port.Containers.Add(container);
                        _truckService.UnloadTruck(truck);
                        break;
                    case "B":
                        warehouseB.Containers.Add(container);
                        _truckService.UnloadTruck(truck);
                        containers.Remove(container);
                        break;
                    case "F":
                        _truckService.ResetTruck(truck);
                        break;
                }
            }
        }
        public void HandleShipArrival(Ship ship, List<Container> containers, Port port, Warehouse warehouseA)
        {
            if (_shipService.HasArrived(ship, Settings.StartEndPointMap.FirstOrDefault(t => t.Key == ship.StartEndPoint).Value))
            {
                var container = ship.Container;
                switch (ship.GoTo)
                {
                    case "A":
                        warehouseA.Containers.Add(container);
                        _shipService.UnloadShip(ship);
                        containers.Remove(container);
                        break;
                    case "P":
                        _shipService.ResetShip(ship);
                        break;
                }
            }
        }
    }
}