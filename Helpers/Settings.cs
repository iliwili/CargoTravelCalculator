using System.Collections.Generic;

namespace CargoTravelCalculator.Helpers
{
    /// <summary>
    /// The Settings class has variables that can change the output of the program when changed.
    /// </summary>
    /// <remarks>
    /// The <see cref="StartEndPointMap"/> is a map that contains all the different routes and the time it takes to go a certain route.
    /// The <see cref="LogTravelInformation"/> is a boolean for enabling/disabling the logging of the travel information.
    /// The <see cref="NumberOfTrucks"/> is a int that represent how many trucks the factory has available to use.
    /// The <see cref="NumberOfShips"/> is a int that represent how many ships the port has available to use.
    /// </remarks>
    public static class Settings
    {
        public static Dictionary<string, int> StartEndPointMap = new()
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