namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// A ship transports containers from the port to another facility.
    /// </summary>
    public class Ship : Transport
    {
        public Ship()
        {
            CameFrom = "P";
            GoTo = "";
        }
    }
}