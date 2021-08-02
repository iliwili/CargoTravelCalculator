using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Models;
using CargoTravelCalculator.Services.Interfaces;

namespace CargoTravelCalculator.Services
{
    /// <inheritdoc cref="ITruckService"/>
    public class TruckService : ITruckService
    {
        public void LoadTruck(Truck truck, Container container)
        {
            if (truck != null)
            {
                truck.GoTo = container.Destination == "A" ? "P" : "B";
                truck.State = TransportState.Delivering;
                truck.Container = container;
            }
        }

        public void UnloadTruck(Truck truck)
        {
            truck.CameFrom = truck.Container.Destination == "A" ? "P" : "B";
            truck.GoTo = "F";
            truck.State = TransportState.Returning;
            truck.HoursMoving = 0;
            truck.Container = null;
        }

        public void HandleTruckArrival(Truck truck, List<Container> containers, Port port, Warehouse warehouse)
        {
            // checking if the truck arrived at the destination
            if (Settings.StartEndPointMap.FirstOrDefault(t => t.Key == truck.StartEndPoint).Value - truck.HoursMoving == 0)
            {
                var container = truck.Container;
                switch (truck.GoTo)
                {
                    case "P":
                        port.Containers.Add(container);
                        UnloadTruck(truck);
                        break;
                    case "B":
                        warehouse.Containers.Add(container);
                        UnloadTruck(truck);
                        containers.Remove(container);
                        break;
                    case "F":
                        truck.CameFrom = "F";
                        truck.GoTo = "";
                        truck.State = TransportState.Waiting;
                        truck.HoursMoving = 0;
                        break;
                }
            }
        }
    }
}