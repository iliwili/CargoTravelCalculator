using System;
using System.Collections.Generic;
using CargoTravelCalculator.Models;
using System.Threading;
using CargoTravelCalculator.Helpers;

namespace CargoTravelCalculator.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class FacilityService
    {
        private readonly TransportService _transportService;
        private readonly FactoryService _factoryService;
        private readonly PortService _portService;

        public FacilityService()
        {
            _factoryService = new FactoryService();
            _portService = new PortService();
            _transportService = new TransportService();
        }
        public void InitializeTransport(Factory factory, Port port, int numberOfTrucks = 2, int numberOfShips = 1)
        {
            for (int i = 0; i < numberOfTrucks; i++)
            {
                factory.Trucks.Add(new Truck { Id = $"Truck.{i + 1}" });
            }

            for (int i = 0; i < numberOfShips; i++)
            {
                port.Ships.Add(new Ship { Id = $"Ship.{i + 1}" });
            }
        }

        public void InitializeContainers(char[] cargo, List<Container> containers, Factory factory)
        {
            for (int i = 0; i < cargo.Length; i++)
            {
                containers.Add(new Container { Id = i, Destination = cargo[i].ToString().ToUpper() });
            }
            factory.Containers.AddRange(containers);
        }

        public int CalculateCargoTravelTime(char[] cargo, List<Container> containers, Factory factory, Port port, Warehouse warehouseA, Warehouse warehouseB)
        {
            _factoryService.ResetFactory(factory);
            _portService.ResetPort(port);

            InitializeTransport(factory, port, Settings.NumberOfTrucks, Settings.NumberOfShips);
            InitializeContainers(cargo, containers, factory);

            int hours = 0;
            while (containers.Count != 0)
            {
                hours++;
                if (Settings.LogTravelInformation)
                {
                    LogFacilityStates(factory, port);
                    Thread.Sleep(500);
                }

                _factoryService.LoadTrucks(factory);
                _portService.LoadShips(port);

                foreach (Truck truck in _factoryService.GetTrucksByState(factory, new[] { TransportState.Delivering, TransportState.Returning }))
                {
                    truck.HoursMoving++;

                    _transportService.HandleTruckArrival(truck, containers, port, warehouseB);
                }

                foreach (Ship ship in _portService.GetShipsByState(port, new[] { TransportState.Delivering, TransportState.Returning }))
                {
                    ship.HoursMoving++;

                    _transportService.HandleShipArrival(ship, containers, port, warehouseA);
                }
            }

            return hours;
        }

        public void LogFacilityStates(Factory factory, Port port)
        {
            _factoryService.PrintCurrentState(factory);
            _portService.PrintCurrentState(port);
            Console.WriteLine();
        }
    }
}