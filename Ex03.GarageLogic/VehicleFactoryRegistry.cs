using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleFactoryRegistry
    {
        private static readonly Dictionary<string, Func<string, string, Vehicle>> s_vehicleFactories = new();

        public static void Register(string vehicleType, Func<string, string, Vehicle> creator)
        {
            s_vehicleFactories[vehicleType] = creator;
        }

        public static Vehicle Create(string vehicleType, string licenseID, string modelName)
        {
            if (!s_vehicleFactories.TryGetValue(vehicleType, out var creator))
            {
                throw new ArgumentException($"Vehicle type {vehicleType} not registered.");
            }

            return creator(licenseID, modelName);
        }

        public static IEnumerable<string> GetSupportedTypes() => s_vehicleFactories.Keys;
    }
}