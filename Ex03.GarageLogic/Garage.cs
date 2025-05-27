using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
				public class Garage
				{
								//	private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
								private Dictionary<string, VehicleInfo> m_Vehicles = new Dictionary<string, VehicleInfo>();
								private List<CustomerInfo> m_Customers = new List<CustomerInfo>(); 

								public void AddVehicleToVehiclesInfo(Vehicle i_Vehicle, CustomerInfo i_Customer, VehicleStatus i_Stauts)
								{
												VehicleInfo newVehicleInfo = new VehicleInfo(i_Vehicle, i_Customer, i_Stauts);

												m_Vehicles.Add(i_Vehicle.LicenseNumber, newVehicleInfo);
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

																CustomerInfo customer = new CustomerInfo();
																customer.UpdateCustomerParams(restProperties);		
																AddVehicleToVehiclesInfo(newVehicle, customer, VehicleStatus.InRepair);
												}
								}

								public bool IsVehicleExistInGarage(string i_LicenseNumber)
								{
												return m_Vehicles.ContainsKey(i_LicenseNumber);
								}
								public void PrintAllVehicles()
								{
												foreach (var vehicle in m_Vehicles) // Assuming 'vehicles' is a collection of Vehicle objects
												{
																Console.WriteLine(vehicle.Value.ToString());
												}
								}
								public void ModifyVehicleStatus(string i_vehicleLicenseNumber, VehicleStatus i_NewStatus)
								{
												

								}
								public void AddNewVehicle(string i_VehicleType)
								{
												
								}
								public void AddCustomer(CustomerInfo i_Customer)
								{
												m_Customers.Add(i_Customer);
								}

				}
}