namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// Transport is a parent class that represent a thing used for transporting goods.
    /// </summary>
    /// <remarks>
    /// In this project transport can be a Truck or a Ship.
    /// </remarks>
    public class Transport 
    { 
        public string Id { get; set; }
        public string CameFrom { get; set; }
        public string GoTo { get; set; }
        public Container Container { get; set; }
        public TransportState State { get; set; }
        public int HoursMoving { get; set; }
        public string StartEndPoint => $"{CameFrom}-{GoTo}";

        public Transport()
        {
            State = TransportState.Waiting;
            Container = null;
            HoursMoving = 0;
            GoTo = "";
        }
    }
}