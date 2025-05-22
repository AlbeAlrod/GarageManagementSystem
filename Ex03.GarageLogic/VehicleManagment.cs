using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
	public class VehicleManagment
	{
		private Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

		public void AddVehicle(Vehicle i_Vehicle)
		{
			vehicles.Add(i_Vehicle.GetLicenseNumber(), i_Vehicle);
		}
        public void LoadVehiclesFromFile(string i_FilePath)
        {
            string[] lines = File.ReadAllLines(i_FilePath);
            string[] headers = lines[0].Split(',');
            foreach (string line in lines.Skip(1)) // Skip the header line
            {
                string[] vehicleData = line.Split(',');

                string vehicleType = vehicleData[0].Trim();
                string licensePlate = vehicleData[1].Trim();
                string modelName = vehicleData[2].Trim();

                Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);

                // Determine number of wheels based on vehicle type
                int numberOfWheels = vehicleType switch
                {
                    "FuelCar" => 4,
                    "ElectricCar" => 4,
                    "FuelMotorcycle" => 2,
                    "ElectricMotorcycle" => 2,
                    "Truck" => 12,
                    _ => 0
                };

                // Default wheel parameters
                string defaultWheelManufacturer = "Michelin";
                float defaultCurrentAirPressure = 30f;
                float defaultMaxAirPressure = 32f;

                // Create wheels for the vehicle
                newVehicle.CreateWheels(numberOfWheels, defaultWheelManufacturer, defaultCurrentAirPressure, defaultMaxAirPressure);

                Dictionary<string, string> properties = newVehicle.CreatePropertiesDictionary(headers, vehicleData);
                newVehicle.UpdateVehicleProperties(properties);
                AddVehicle(newVehicle);
            }
        }
		public void PrintAllVehicles()
		{
			foreach (var vehicle in vehicles) // Assuming 'vehicles' is a collection of Vehicle objects
			{
				Console.WriteLine(vehicle.ToString());
			}
		}
	}
}