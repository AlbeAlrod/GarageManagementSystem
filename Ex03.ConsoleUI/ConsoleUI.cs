using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

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

																consoleUIHelper.PrintMenu();
																MenuChoice userChoise = (MenuChoice)Enum.Parse(typeof(MenuChoice), consoleUIHelper.ReadValidOption());
																
																switch(userChoise) 
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





																}



									}
								}

								

				}
}
