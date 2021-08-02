namespace CargoTravelCalculator.Models
{
    /// <summary>
    /// An enum for the different states the transports can have.
    /// </summary>
    public enum TransportState
    {
        /// <summary> The transport is waiting in the facility. </summary>
        Waiting,
        /// <summary> The transport is delivering goods to a destination. </summary>
        Delivering,
        /// <summary> The transport is returning from the destination. </summary>
        Returning
    }
}
