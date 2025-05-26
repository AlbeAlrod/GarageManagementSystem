using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

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
												while (true)
												{			
																int numOfChoises = Enum.GetValues(typeof(MenuChoise)).Length;
																int userChoise;
																bool isValidInput;
																string input = Console.ReadLine();
																do
																{
																				Console.Write($"Please choose a number between {1} and {numOfChoises}: ");
																				isValidInput = int.TryParse(Console.ReadLine(), out userChoise) && userChoise >= 1 && userChoise <= numOfChoises;
																				
																				if(!isValidInput)
																				{
																								Console.Write($"Invalid input. Please enter a number between 1 and {numOfChoises}: ");
																				}
																}

																while (!isValidInput);
												}
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
												bool isExist = i_Garage.FindVehicleByLicenseNumber(vehicleLicenseNumber);
												if (isExist) 
												{
																Console.WriteLine("This vehicle already exist in the garage!");
																//Change vehicle status to in progress.
																
												}
												else
												{



												}
								}

				}
}
