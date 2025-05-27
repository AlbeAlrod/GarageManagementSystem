using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
//using static Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
				public class ConsoleUIHelper
				{
								public void PrintMenu()
								{
												Console.WriteLine("=== Garage Management System ===");
												Console.WriteLine("1. Load vehicles from file");
												Console.WriteLine("2. Add New Vehicle");
												Console.WriteLine("3. Show All Vehicles");
												Console.WriteLine("4. Update Vehicle Status");
												Console.WriteLine("5. Refuel Vehicle");
												Console.WriteLine("6. Recharge Vehicle");
												Console.WriteLine("7. Inflate Vehicle Wheels");
												Console.WriteLine("8. Show Vehicle details");
												Console.WriteLine("9. Exit");
								}
								public string ReadValidOption()
								{
																int numOfChoises = Enum.GetValues(typeof(MenuChoice)).Length;
																int userChoise;
																bool isValidInput;
																do
																{
																				Console.Write($"Please choose a number between {1} and {numOfChoises}: ");
																				isValidInput = int.TryParse(Console.ReadLine(), out userChoise) && userChoise >= 1 && userChoise <= numOfChoises;

																				if (!isValidInput)
																				{
																								Console.Write($"Invalid input. ");
																				}
																}

																while (!isValidInput);
												return userChoise.ToString();
								}
								public void LoadVehicles(Garage i_Garage, string filePath)
								{
												if (File.Exists(filePath))
												{
																try
																{
																				i_Garage.LoadVehiclesFromFile(filePath);
																}

																catch (IOException ex)
																{
																				Console.WriteLine($"Error opening file: {ex.Message}");
																}
																catch (UnauthorizedAccessException ex)
																{
																				Console.WriteLine($"Access denied: {ex.Message}");
																}

												}
								}
								public void AddNewVehicle(Garage i_Garage)
								{
												Console.WriteLine("Please enter the vehcile license number: ");
												string vehicleLicenseNumber = Console.ReadLine();
												bool isExist = i_Garage.IsVehicleExistInGarage(vehicleLicenseNumber);
												if (isExist)
												{
																Console.WriteLine("This vehicle already exist in the garage!");
																i_Garage.ModifyVehicleStatus(vehicleLicenseNumber, VehicleStatus.InRepair);
																//Change vehicle status to in progress.

												}
												else //The car not exist
												{
																PrintVehiclesTypes(VehicleCreator.SupportedTypes);
																string choosenVehicleByUser = GetVehicleType();
																Console.WriteLine("Please Enter vehicle model:");
																string vehicleModel = Console.ReadLine();

																//Vehicle create and params:
																Vehicle newVehicle = VehicleCreator.CreateVehicle(choosenVehicleByUser, vehicleLicenseNumber, vehicleModel);
																Dictionary<string, string> DataMembersDict = newVehicle.CreateParametersDictForUser();
																Dictionary<string, string> userInputDictionaryForVehicle = GetParametersFromUser(DataMembersDict);
																newVehicle.UpdateVehicleProperties(userInputDictionaryForVehicle);

																//Customer create and params:
																CustomerInfo newCustomer = new CustomerInfo();
																Dictionary<string,string> customerParamsDict = newCustomer.CreateParametersDictForUser();
																Dictionary<string, string> userInputDictionaryForCustomerInfo = GetParametersFromUser(customerParamsDict);
																i_Garage.AddCustomer(newCustomer);

																i_Garage.AddVehicleToVehiclesInfo(newVehicle, newCustomer, VehicleStatus.InRepair);
												}
								}

								public void PrintVehiclesTypes(List<string> i_VehiclesTypes)
								{
												int i = 1;

												foreach (string vehicleType in i_VehiclesTypes)
												{
																Console.WriteLine($"{i}: {vehicleType}");
																i++;
												}
								}
								public string GetVehicleType()
								{
												Console.WriteLine("Please choose which type of vehicle you would like to bring:");
												if (Enum.TryParse(Console.ReadLine(), out SupportedTypes chosenVehicle))
												{
																if (!((int)chosenVehicle >= 1 && (int)chosenVehicle <= Enum.GetValues(typeof(SupportedTypes)).Length))
																{
																				throw new ValueRangeException(1, Enum.GetValues(typeof(SupportedTypes)).Length, (int)chosenVehicle);
																}
												}
												string userChoosenVehicle = chosenVehicle.ToString();
												return userChoosenVehicle;
								}

								public Dictionary<string, string> GetParametersFromUser(Dictionary<string, string> i_DicParam)
								{
												string input;
												Dictionary<string, string> userInputParams = new Dictionary<string, string>();
												foreach (var pairParam in i_DicParam)
												{
																Console.WriteLine(pairParam.Value);
																input = Console.ReadLine();
																userInputParams.Add(pairParam.Key, input);
												}
												return userInputParams;
								}

								public void ShowAllVehicles(Garage i_Garage)
								{
												i_Garage.PrintAllVehicles();
											
								}
				}
}
