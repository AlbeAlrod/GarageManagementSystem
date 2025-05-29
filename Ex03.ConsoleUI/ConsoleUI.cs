using System;
using Ex03.GarageLogic;
using Ex03.ConsoleUI;

namespace Ex03.ConsoleUI
{
	public class ConsoleUI
	{
		private readonly Garage r_Garage;
		private readonly ConsoleUIHelper r_Helper;

		public ConsoleUI()
		{
			r_Garage = new Garage();
			r_Helper = new ConsoleUIHelper();
		}

		public void Start()
		{
			bool isSessionActive = true;
			string filePath = "../../../../Vehicles.db";
			while (isSessionActive)
			{
				try
				{
					r_Helper.PrintMenu();
					MenuChoice userChoice = r_Helper.ReadValidOption();

					switch (userChoice)
					{
						case MenuChoice.LoadVehicles:
							r_Helper.LoadVehicles(r_Garage, filePath);
							break;

						case MenuChoice.AddNewVehicle:
							r_Helper.AddNewVehicle(r_Garage);
							break;

						case MenuChoice.ShowAllVehicles:
							r_Helper.ShowAllVehicles(r_Garage);
							break;

						case MenuChoice.ShowVehiclesByStatus:
							r_Helper.ShowVehiclesByStatus(r_Garage);
							break;

						case MenuChoice.UpdateVehicleStatus:
							r_Helper.UpdateVehicleStatus(r_Garage);
							break;

						case MenuChoice.InflateVehicleWheels:
							r_Helper.InflateAirPressureToMax(r_Garage);
							break;

						case MenuChoice.RefuelVehicle:
							r_Helper.RefuelVehicle(r_Garage);
							break;

						case MenuChoice.RechargeVehicle:
							r_Helper.RechargeVehicle(r_Garage);
							break;

						case MenuChoice.ShowVehicleDetails:
							r_Helper.ShowVehicleDetails(r_Garage);
							break;

						case MenuChoice.Exit:
							isSessionActive = false;
							break;

						default:
							Console.WriteLine("Invalid choice.");
							break;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
			}

			Console.WriteLine("Bye Bye");
		}
	}
}
