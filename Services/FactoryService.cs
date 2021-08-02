using System.Collections.Generic;
using System.Linq;
using CargoTravelCalculator.Helpers;
using CargoTravelCalculator.Models;
using CargoTravelCalculator.Services.Interfaces;

namespace CargoTravelCalculator.Services
{
    /// <inheritdoc cref="IFactoryService"/>
    public class FactoryService : IFactoryService
    {
        private readonly ITruckService _truckService;

        public FactoryService(ITruckService truckService)
        {
            _truckService = truckService;
        }

        public void InitializeFactory(Factory factory, List<Container> containers)
        {
            // add the containers to the factory
            factory.Containers.AddRange(containers);

            // initialize the number trucks that the factory needs
            for (int i = 0; i < Settings.NumberOfTrucks; i++)
            {
                factory.Trucks.Add(new Truck { Id = $"Truck.{i + 1}" });
            }
        }

        public List<Truck> GetTrucksByState(Factory factory, TransportState[] states)
        {
            return factory.Trucks.Where(truck => states.Contains(truck.State)).ToList();
        }

        public void LoadTrucks(Factory factory)
        {
            // load up the available trucks if there are containers available
            factory.Containers.ForEach(container =>
            {
                _truckService.LoadTruck(factory.Trucks.Find(t => t.State == TransportState.Waiting), container);
            });

            // removes unloaded containers from the factory
            factory.Trucks.ForEach(truck => factory.Containers.RemoveAll(container => container == truck.Container));
        }

        public void ResetFactory(Factory factory)
        {
            factory.Containers.Clear();
            factory.Trucks.Clear();
        }
    }
}