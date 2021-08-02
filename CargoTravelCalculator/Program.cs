using System;
using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Models;
using CargoTravelCalculator.Services;
using CargoTravelCalculator.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CargoTravelCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating 
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFacilityService, FacilityService>()
                .AddSingleton<IFactoryService, FactoryService>()
                .AddSingleton<IPortService, PortService>()
                .AddSingleton<IShipService, ShipService>()
                .AddSingleton<ITruckService, TruckService>()
                .BuildServiceProvider();

            var facilityService = serviceProvider.GetService<IFacilityService>();

            Factory factory = new Factory();
            Port port = new Port();
            Warehouse warehouseA = new Warehouse();
            Warehouse warehouseB = new Warehouse();
            List<Container> containers = new List<Container>();


            string option = "";

            while (option.ToLower() != "q")
            {
                Console.Clear();
                Console.WriteLine("Welcome to Travel Calculator");
                Console.WriteLine("How can I help you, choose an option from the list!");

                Console.WriteLine("\n1. Calculate from a given sequence.");
                Console.WriteLine("2. Edit some variables.");
                Console.WriteLine("q. Quit.\n");

                option = Helper.ReadStringWithCondition("Option", "choose an option from above", (i) => !"123qQ".Contains(i));

                if (option == "1")
                {
                    string input = "";

                    while (input != "g")
                    {
                        Console.Clear();
                        Console.WriteLine("Give the sequences of the cargo you want to calculate! (seperated by space, example: AB AAB)");
                        Console.WriteLine("g. Go back.\n");

                        input = Helper.ReadStringWithCondition(
                                            "Sequences",
                                            "the sequences should be A's and B's only",
                                            (sequence) => sequence.ToLower() != "g" && !Helper.SequenceRegex.IsMatch(sequence.ToUpper())
                                        ).ToLower();

                        if (input != "g")
                        {
                            Console.Clear();
                            Console.WriteLine("Calculating sequences...\n");
                            string[] sequences = input.Split(" ");

                            for (int i = 0; i < sequences.Length; i++)
                            {
                                int hours = facilityService.CalculateCargoTravelTime(sequences[i].ToArray(), containers, factory, port, warehouseA, warehouseB);

                                Console.Write("Sequence ");
                                Helper.WriteColorLine($"[{i + 1}]", ConsoleColor.Blue, false);
                                Console.Write($": {sequences[i].ToUpper()}, Total Hours: {hours}");
                                Console.WriteLine($"{(Settings.LogTravelInformation ? "\n" : "")}");


                            }

                            Helper.WriteColorLine("\nPress enter to continue!", ConsoleColor.Green, false);
                            Console.ReadLine();
                        }
                    }
                }
                else if (option == "2")
                {
                    string sOption = "";

                    while (sOption.ToLower() != "g")
                    {
                        Console.Clear();
                        Console.WriteLine("Which variable do you want to change?");
                        Console.WriteLine($"1. Number of trucks the factory has available: [{Settings.NumberOfTrucks}]");
                        Console.WriteLine($"2. Number of ships the port has available: [{Settings.NumberOfShips}]");
                        Console.WriteLine($"3. Log the travel information: [{(Settings.LogTravelInformation ? "Yes" : "No")}]");
                        Console.WriteLine("g. Go back.\n");

                        sOption = Helper.ReadStringWithCondition("Option", "choose an option from above", (o) => !"123gG".Contains(o));

                        switch (sOption)
                        {
                            case "1":
                                Console.WriteLine($"How many trucks do you want to use? (Current: {Settings.NumberOfTrucks}): \n");

                                Settings.NumberOfTrucks = Helper.ReadIntWithCondition("Number of trucks");
                                break;
                            case "2":
                                Console.WriteLine($"How many ship do you want to use? (Current: {Settings.NumberOfShips}): \n");

                                Settings.NumberOfShips = Helper.ReadIntWithCondition("Number of ships");
                                break;
                            case "3":
                                Settings.LogTravelInformation = !Settings.LogTravelInformation;
                                break;
                        }
                    }
                }
            }

            Helper.WriteColorLine("It was a pleasure to have you!", ConsoleColor.Blue);
        }
    }
}
