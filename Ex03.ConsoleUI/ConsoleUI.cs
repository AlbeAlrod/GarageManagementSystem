using System;
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
												while (isSessionActive)
												{
																consoleUIHelper.PrintMenu();
																Enums.MenuChoise userChoise = (Enums.MenuChoise)Enum.Parse(typeof(Enums.MenuChoise), consoleUIHelper.ReadValidOption());
																
																switch(userChoise) 
																{





																}



									}
								}

								

				}
}
