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

												foreach (string line in lines)
												{
																string[] vehicleData = line.Split(',');
																Console.WriteLine(vehicleData.Length)

																string vehicleType = vehicleData[0].Trim();
																string licensePlate = vehicleData[1].Trim();
																string modelName = vehicleData[2].Trim();
																float energyPercentage = float.Parse(vehicleData[3].Trim());
																string tierModel = vehicleData[4].Trim();
																float currAirPressure = float.Parse(vehicleData[5].Trim());
																string ownerName = vehicleData[6].Trim();
																string ownerPhone = vehicleData[7].Trim();

																Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
																// Handle specific vehicle properties
																if (vehicleData.Length > 8)
																{
																				Dictionary<string, string> specificProperties = new Dictionary<string, string>();
																				for (int i = 8; i < vehicleData.Length; i++)
																				{
																								string[] property = vehicleData[i].Split('=');
																								specificProperties[property[0].Trim()] = property[1].Trim();
																				}
																				newVehicle.AddDetails(energyPercentage, tierModel, currAirPressure, new List<Wheel>(), ownerName, ownerPhone, specificProperties);
																}
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