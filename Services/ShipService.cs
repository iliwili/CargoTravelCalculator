using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services
{
    public class ShipService
    {
        public bool HasArrived(Ship ship, int totalHours)
        {
            return (totalHours - ship.HoursMoving) == 0;
        }

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

        public void ResetShip(Ship ship)
        {
            ship.CameFrom = "P";
            ship.GoTo = "";
            ship.State = TransportState.Waiting;
            ship.HoursMoving = 0;
        }
    }
}