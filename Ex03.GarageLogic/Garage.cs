using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
				public class Garage
				{
								private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
								private List<ContactInfo> m_Contacts =	new List<ContactInfo>();

								public void AddVehicle(Vehicle i_Vehicle)
								{
												m_Vehicles.Add(i_Vehicle.GetLisenceNumber(), i_Vehicle);
								}
								public void LoadVehiclesFromFile(string i_FilePath)
								{
												string[] lines = File.ReadAllLines(i_FilePath);

												foreach (string line in lines)
												{
																string[] vehicleData = line.Split(',');

																string vehicleType = vehicleData[0].Trim();
																string licensePlate = vehicleData[1].Trim();
																string modelName = vehicleData[2].Trim();
															
																Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
																Dictionary<string,string> restProperties = newVehicle.CreatePropertiesDictionaryFromLine(vehicleData);
																newVehicle.UpdateVehicleProperties(restProperties);
																AddVehicle(newVehicle);
												}
								}

								public bool FindVehicleByLicenseNumber(string i_VehicleLicenseNumber)
								{
												bool found = false;

												foreach(Vehicle vehicle in m_Vehicles.Values) 
												{
																string currentVehicleLicenseNumber = vehicle.LicenseNumber;
																if(currentVehicleLicenseNumber == i_VehicleLicenseNumber)
																{
																found = true;
																}
												}

												return found;
								}
								public void PrintAllVehicles()
								{
												foreach (var vehicle in m_Vehicles) // Assuming 'vehicles' is a collection of Vehicle objects
												{
																Console.WriteLine(vehicle.ToString());
												}
								}
				}
}