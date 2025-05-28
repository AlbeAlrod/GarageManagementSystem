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
								public string GetLicenseNumberFromUser()
								{
												string licenseNumber;
												bool isValidInput = false;

												do
												{
																Console.WriteLine("Please enter the vehicle's license number:");
																licenseNumber = Console.ReadLine();

																try
																{
																				ValidateLicenseNumber(licenseNumber);
																				isValidInput = true;
																}
																catch (ArgumentException ex)
																{
																				Console.WriteLine($"Invalid input: {ex.Message}");
																				Console.WriteLine("Please try again.");
																}
												} while (!isValidInput);

												return licenseNumber;
								}
								public string GetVehicleModelFromUser(int i_NumberOfSupportedModels)
								{
												string model;
												bool isValidInput = false;

												do
												{
																Console.WriteLine("Please enter the vehicle's model:");
																model = Console.ReadLine();

																try
																{
																				if (string.IsNullOrEmpty(model))
																				{
																								throw new ArgumentException("Input cannot be empty");
																				}

																				// Check if the model is a number and in range
																				if (int.TryParse(model, out int modelNumber))
																				{
																								if (modelNumber < 1 || modelNumber > i_NumberOfSupportedModels)
																								{
																												throw new ValueRangeException(1, i_NumberOfSupportedModels, modelNumber);
																								}
																				}

																				isValidInput = true;
																}
																catch (ValueRangeException)
																{
																				Console.WriteLine($"The value is not in the valid range (1 - {i_NumberOfSupportedModels}). Please enter again.");
																}
																catch (ArgumentException ex)
																{
																				Console.WriteLine($"Invalid input: {ex.Message}, Please enter again.");
																}
												} while (!isValidInput);

												return model;
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
												string vehicleLicenseNumber = GetLicenseNumberFromUser();
												bool isExist = i_Garage.IsVehicleExistInGarage(vehicleLicenseNumber);

												if (isExist)
												{
																Console.WriteLine("This vehicle already exist in the garage!");
																i_Garage.ModifyVehicleStatus(vehicleLicenseNumber, VehicleStatus.InRepair);
												}
												else //The car not exist
												{
																PrintVehiclesTypes(VehicleCreator.SupportedTypes);
																string choosenVehicleByUser = GetVehicleType();
																string vehicleModel = GetVehicleModelFromUser(VehicleCreator.SupportedTypes.Count);

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
								public void PrintVehicleStatuses()
								{
												var statuses = Enum.GetValues(typeof(VehicleStatus)).Cast<VehicleStatus>().ToArray();
												int i = 1;

												foreach (var status in statuses)
												{
																Console.WriteLine($"{i++} - {status}");
												}
								}

								public void UpdateVehicleStatus(Garage i_Garage)
								{
												string vehicleLicenseNumber = GetLicenseNumberFromUser();

												if (i_Garage.IsVehicleExistInGarage(vehicleLicenseNumber))
												{

																//Check if the licensenumber exist in the garage
																Console.WriteLine("Please select the new status from the following options: ");

																PrintVehicleStatuses();

																int choise;
																bool correct;

																do
																{
																				Console.WriteLine("Your Choise: ");

																				correct = int.TryParse(Console.ReadLine(), out choise) && choise >= 1 && choise <= Enum.GetValues(typeof(VehicleStatus)).Length;
																				if(!correct)
																				{
																								Console.WriteLine("Invalid input");
																				}
																}
																while (!correct);

																i_Garage.ModifyVehicleStatus(vehicleLicenseNumber, (VehicleStatus)choise);
												}
												else
												{
																throw new ArgumentException("Vehicle doesn't exist in the garage.");

												}
        }

								public void InflateAirPressureToMax(Garage i_Garage)
								{

								}
								public void RefuelVehicle(Garage i_Garage)
								{

								}
								public void RechargeVehicle(Garage i_Garage)
								{

								}
								public void ShowVehicleDetails(Garage i_garage)
								{

								}
								private void ValidateLicenseNumber(string i_LicenseNumber)
								{
												if (string.IsNullOrEmpty(i_LicenseNumber))
												{
																throw new ArgumentException("License number cannot be empty");
												}
								}


								}
}
