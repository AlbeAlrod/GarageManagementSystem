using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using System.Linq.Expressions;

namespace Ex03.ConsoleUI
{
				public class ConsoleUI
				{
								private readonly Garage garage;
								public ConsoleUI()
								{
												garage = new Garage();
								}
								public void Start()
								{
								ConsoleUIHelper consoleUIHelper = new ConsoleUIHelper();
								bool isSessionActive = true;
								string filePath = "C:\\Users\\Guy\\source\\repos\\Ex03-Garage\\Vehicles.txt";

												while (isSessionActive)
												{
																try
																{
																				consoleUIHelper.PrintMenu();

																				bool isValid = Enum.TryParse(Console.ReadLine(), out MenuChoice userChoice);
																				if (!isValid)
																				{
																								throw new FormatException("You Typed invalid number!");
																				}
																				switch (userChoice)
																				{
																								case MenuChoice.LoadVehicles:
																												consoleUIHelper.LoadVehicles(garage, filePath);
																												break;
																								case MenuChoice.AddNewVehicle:
																												consoleUIHelper.AddNewVehicle(garage);
																												break;
																								case MenuChoice.ShowAllVehicles:
																												consoleUIHelper.ShowAllVehicles(garage);
																												break;
																								case MenuChoice.UpdateVehicleStatus:
																												consoleUIHelper.UpdateVehicleStatus(garage);
																												break;
																								case MenuChoice.InflateVehicleWheels:
																												consoleUIHelper.InflateAirPressureToMax(garage);
																												break;
																								case MenuChoice.RefuelVehicle:
																												consoleUIHelper.RefuelVehicle(garage);
																												break;
																								case MenuChoice.RechargeVehicle:
																												consoleUIHelper.RechargeVehicle(garage);
																												break;
																								case MenuChoice.ShowVehicleDetails:
																												consoleUIHelper.ShowVehicleDetails(garage);
																												break;
																								case MenuChoice.Exit:
																												isSessionActive = false;
																												break;
																								default:
																												float invalidValue = (int)userChoice;
																												throw new ValueRangeException(1, 9, invalidValue);

																				}
																				
																}
																catch (FormatException formatE)
																{
																				Console.WriteLine($"FormatException: {formatE.Message}");
																}
																catch (ArgumentException argumentE)
																{
																				Console.WriteLine($"ArgumentException: {argumentE.Message}");
																}
																catch (ValueRangeException rangeE)
																{
																				Console.WriteLine($"ValueOutOfRangeException: {rangeE.Message}");
																}
												}

												Console.WriteLine("Bye Bye");
								}

								

				}
}
