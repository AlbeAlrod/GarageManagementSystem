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
			vehicles.Add(i_Vehicle.GetLisenceNumber(), i_Vehicle);
		}
		public void LoadVehiclesFromFile(string i_FilePath)
		{
			string[] lines = File.ReadAllLines(i_FilePath);
            string[] headers = lines[0].Split(',');
			foreach (string line in lines)
			{
				string[] vehicleData = line.Split(',');

				string vehicleType = vehicleData[0].Trim();
				string licensePlate = vehicleData[1].Trim();
				string modelName = vehicleData[2].Trim();

				Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
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