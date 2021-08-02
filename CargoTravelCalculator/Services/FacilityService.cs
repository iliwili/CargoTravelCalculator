using System;
using System.Collections.Generic;
using CargoTravelCalculator.Models;
using System.Threading;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Services.Interfaces;

namespace CargoTravelCalculator.Services
{
    /// <inheritdoc cref="IFacilityService"/>
    public class FacilityService : IFacilityService
    {
        private readonly IFactoryService _factoryService;
        private readonly IPortService _portService;
        private readonly ITruckService _truckService;
        private readonly IShipService _shipService;

        public FacilityService(IFactoryService factoryService, IPortService portService, ITruckService truckService, IShipService shipService)
        {
            _factoryService = factoryService;
            _portService = portService;
            _truckService = truckService;
            _shipService = shipService;
        }

        public int CalculateCargoTravelTime(char[] cargo, List<Container> containers, Factory factory, Port port, Warehouse warehouseA, Warehouse warehouseB)
        {
            _factoryService.ResetFactory(factory);
            _portService.ResetPort(port);

            // initialize containers
            for (int i = 0; i < cargo.Length; i++)
            {
                containers.Add(new Container { Id = i, Destination = cargo[i].ToString().ToUpper() });
            }

            // initialize facilities
            _factoryService.InitializeFactory(factory, containers);
            _portService.InitializePort(port);

            // calculate travel time
            int hours = 0;
            while (containers.Count != 0)
            {
                hours++;

                // log the facility states
                if (Settings.LogTravelInformation)
                {
                    LogFacilityTransportStates(factory, port);
                    Thread.Sleep(500);
                }

                // load up the trucks and ships if there are containers available
                _factoryService.LoadTrucks(factory);
                _portService.LoadShips(port);

                // handle the arrival of the trucks
                foreach (Truck truck in _factoryService.GetTrucksByState(factory, new[] { TransportState.Delivering, TransportState.Returning }))
                {
                    truck.HoursMoving++;

                    _truckService.HandleTruckArrival(truck, containers, port, warehouseB);
                }

                // handle the arrival of the ships
                foreach (Ship ship in _portService.GetShipsByState(port, new[] { TransportState.Delivering, TransportState.Returning }))
                {
                    ship.HoursMoving++;

                    _shipService.HandleShipArrival(ship, containers, port, warehouseA);
                }
            }

            return hours;
        }

        public void LogFacilityTransportStates(Factory factory, Port port)
        {
            foreach (Truck truck in factory.Trucks)
            {
                Console.WriteLine(
                    $"Truck: {truck.Id,-8} State: {truck.State,-10} Start-EndPoint: {truck.StartEndPoint}");
            }
            foreach (Ship ship in port.Ships)
            {
                Console.WriteLine($"Ship:  {ship.Id,-8} State: {ship.State,-10} Start-EndPoint: {ship.StartEndPoint}");
            }
            Console.WriteLine();
        }
    }
}