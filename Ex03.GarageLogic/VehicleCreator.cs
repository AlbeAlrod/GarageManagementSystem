using System.Collections.Generic;
using System;

using VehicleFactory = System.Func<string, string, Ex03.GarageLogic.Vehicle>;

namespace Ex03.GarageLogic
{
	public abstract class VehicleCreator
	{
		private static readonly Dictionary<string, VehicleFactory> sr_Factories = new();

		static VehicleCreator()
		{
			Register("FuelCar", (license, model) => new FuelCar(license, model));
			Register("ElectricCar", (license, model) => new ElectricCar(license, model));
			Register("FuelMotorcycle", (license, model) => new FuelMotorcycle(license, model));
			Register("ElectricMotorcycle", (license, model) => new ElectricMotorcycle(license, model));
			Register("Truck", (license, model) => new Truck(license, model));
		}

		public static void Register(string typeName, VehicleFactory factory)
		{
			if (sr_Factories.ContainsKey(typeName))
			{
				throw new InvalidOperationException($"Vehicle type '{typeName}' is already registered.");
			}
			sr_Factories[typeName] = factory;
		}

		public static Vehicle CreateVehicle(string i_VehicleType, string i_LicenseID, string i_ModelName)
		{
			if (sr_Factories.TryGetValue(i_VehicleType, out var factory))
			{
				return factory(i_LicenseID, i_ModelName);
			}

			throw new NotSupportedException($"Unsupported vehicle type: {i_VehicleType}");
		}


		public static List<string> SupportedTypes => new List<string>(sr_Factories.Keys);
	}
}
