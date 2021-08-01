using System;
using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Models;

namespace CargoTravelCalculator.Services
{
    public class FactoryService
    {
        private readonly TruckService _truckService;

        public FactoryService()
        {
            _truckService = new TruckService();
        }
        public List<Truck> GetTrucksByState(Factory factory, TransportState[] states)
        {
            return factory.Trucks.Where(truck => states.Contains(truck.State)).ToList();
        }

        public void LoadTrucks(Factory factory)
        {
            factory.Containers.ForEach(container =>
            {
                _truckService.LoadTruck(factory.Trucks.Find(t => t.State == TransportState.Waiting), container);
            });

            factory.Trucks.ForEach(truck => factory.Containers.RemoveAll(container => container == truck.Container));
        }

        public void ResetFactory(Factory factory)
        {
            factory.Containers.Clear();
            factory.Trucks.Clear();
        }

        public void PrintCurrentState(Factory factory)
        {
            foreach (Truck truck in factory.Trucks)
            {
                Console.WriteLine(
                    $"Truck: {truck.Id,-8} State: {truck.State,-10} Start-EndPoint: {truck.StartEndPoint}");
            }
        }
    }
}