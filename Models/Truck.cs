namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// A truck transports containers from the factory to another facility.
    /// </summary>
    public class Truck : Transport
    {
        public Truck()
        {
            CameFrom = "F";
            GoTo = "";
        }
    }
}