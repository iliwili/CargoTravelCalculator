using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services
{
    public class TruckService
    {
        public bool HasArrived(Truck truck, int totalHours)
        {
            return (totalHours - truck.HoursMoving) == 0;
        }

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

        public void ResetTruck(Truck truck)
        {
            truck.CameFrom = "F";
            truck.GoTo = "";
            truck.State = TransportState.Waiting;
            truck.HoursMoving = 0;
        }
    }
}