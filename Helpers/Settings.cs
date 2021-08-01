using System.Collections.Generic;

namespace CargoTravelCalculator.Helpers
{
    public static class Settings
    {
        public static Dictionary<string, int> StartEndPointMap = new Dictionary<string, int>
        {
            { "F-P", 1 },
            { "P-F", 1 },
            { "P-A", 4 },
            { "A-P", 4 },
            { "F-B", 5 },
            { "B-F", 5 }
        };
        public static bool LogTravelInformation = false;
        public static int NumberOfTrucks = 2;
        public static int NumberOfShips = 1;
    }
}