using System;
using System.ComponentModel;

namespace CargoTravelCalculator.Models
{
    public class Transport
    {
        public string Id { get; set; }
        public string CameFrom { get; set; }
        public string GoTo { get; set; }
        public Container Container { get; set; }
        public TransportState State { get; set; }
        public int HoursMoving { get; set; }
        public string StartEndPoint
        {
            get => $"{CameFrom}-{GoTo}";
            set => StartEndPoint = value;
        }

        public Transport()
        {
            State = TransportState.Waiting;
            Container = null;
            HoursMoving = 0;
            GoTo = "";
        }
    }
}