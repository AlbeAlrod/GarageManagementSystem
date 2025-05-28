using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

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
			Console.WriteLine("4. Show Vehicles by Status");
			Console.WriteLine("5. Update Vehicle Status");
			Console.WriteLine("6. Refuel Vehicle");
			Console.WriteLine("7. Recharge Vehicle");
			Console.WriteLine("8. Inflate Vehicle Wheels");
			Console.WriteLine("9. Show Vehicle details");
			Console.WriteLine("10. Exit");
		}

		public MenuChoice ReadValidOption() => InputValidator.GetValidMenuChoice();
		public string GetLicenseNumberFromUser() => InputValidator.GetLicenseNumber();
		public string GetVehicleModelFromUser() => InputValidator.GetVehicleModel(); public string GetVehicleType() => InputValidator.GetVehicleType();

		public Dictionary<string, string> GetParametersFromUser(Dictionary<string, string> paramTemplate)
		{
			Dictionary<string, string> userInputs = new();

			foreach (var param in paramTemplate)
			{
				string key = param.Key;
				string prompt = param.Value;
				string input = string.Empty;
				bool isValid = false;

				while (!isValid)
				{
					try
					{
						if (key.ToLower().Contains("percentage") || key.ToLower().Contains("air") || key.ToLower().Contains("capacity"))
						{
							Console.WriteLine(prompt);
							input = Console.ReadLine()?.Trim() ?? string.Empty;
							if (!float.TryParse(input, out float number) || number < 0)
								throw new FormatException("Please enter a valid positive number.");
						}
						else if (key.ToLower().Contains("hazard"))
						{
							Console.WriteLine(prompt);
							input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
							if (input != "yes" && input != "no")
								throw new FormatException("Please answer Yes or No.");
						}
						else if (key.ToLower().Contains("license"))
						{
							var licenseType = InputValidator.GetValidEnumFromUser<LicenseType>(prompt);
							input = licenseType.ToString();
						}
						else if (key.ToLower().Contains("fuel"))
						{
							var fuelType = InputValidator.GetValidEnumFromUser<FuelType>(prompt);
							input = fuelType.ToString();
						}
						else if (key.ToLower().Contains("phone"))
						{
							Console.WriteLine(prompt);
							input = Console.ReadLine()?.Trim() ?? string.Empty;

							if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{7,15}$"))
								throw new FormatException("Phone number must contain only digits (7–15 digits).");
						}
						else
						{
							Console.WriteLine(prompt);
							input = Console.ReadLine()?.Trim() ?? string.Empty;
							if (string.IsNullOrWhiteSpace(input))
								throw new FormatException("Input cannot be empty.");
						}

						isValid = true;
					}
					catch (FormatException ex)
					{
						Console.WriteLine($"❌ {ex.Message} Try again.");
					}
				}

				userInputs[key] = input;
			}

			return userInputs;
		}
		public void PrintVehiclesTypes(List<string> types)
		{
			for (int i = 0; i < types.Count; i++)
			{
				Console.WriteLine($"{i + 1}: {types[i]}");
			}
		}

		public void PrintVehicleStatuses()
		{
			int i = 1;
			foreach (VehicleStatus status in Enum.GetValues(typeof(VehicleStatus)))
			{
				Console.WriteLine($"{i++} - {status}");
			}
		}

		public void LoadVehicles(Garage garage, string filePath)
		{
			try
			{
				garage.LoadVehiclesFromFile(filePath);
				Console.WriteLine("Vehicles loaded from file successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading vehicles: {ex.Message}");
			}
		}

		public void AddNewVehicle(Garage garage)
		{
			try
			{
				string license = GetLicenseNumberFromUser();
				if (garage.IsVehicleExistInGarage(license))
				{
					Console.WriteLine("Vehicle already exists in the garage.");
					garage.ModifyVehicleStatus(license, VehicleStatus.InRepair);
					return;
				}

				PrintVehiclesTypes(VehicleCreator.SupportedTypes);
				int choice = InputValidator.GetValidIntInRange("Please choose which type of vehicle you would like to bring: ", 1, VehicleCreator.SupportedTypes.Count);
				string type = VehicleCreator.SupportedTypes[choice - 1];
				string model = GetVehicleModelFromUser();

				Vehicle vehicle = VehicleCreator.CreateVehicle(type, license, model);
				vehicle.UpdateVehicleProperties(GetParametersFromUser(vehicle.CreateParametersDictForUser()));

				CustomerInfo customer = new CustomerInfo();
				Dictionary<string, string> customerInputs = GetParametersFromUser(customer.CreateParametersDictForUser());
				customer.UpdateCustomerParams(customerInputs);

				garage.AddCustomer(customer);
				garage.AddVehicleToVehiclesInfo(vehicle, customer, VehicleStatus.InRepair);

				Console.WriteLine("New vehicle added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding vehicle: {ex.Message}");
			}
		}

		public void ShowAllVehicles(Garage garage)
		{
			try { garage.PrintAllVehicles(); }
			catch (Exception ex) { Console.WriteLine($"Error showing vehicles: {ex.Message}"); }
		}

		public void UpdateVehicleStatus(Garage garage)
		{
			string license = GetLicenseNumberFromUser();
			if (!garage.IsVehicleExistInGarage(license)) throw new ArgumentException("Vehicle doesn't exist in the garage.");

			Console.WriteLine("Please select the new status:");
			PrintVehicleStatuses();
			int choice = InputValidator.GetValidIntInRange("Your Choice: ", 1, Enum.GetValues(typeof(VehicleStatus)).Length);
			garage.ModifyVehicleStatus(license, (VehicleStatus)choice);
		}

		public void InflateAirPressureToMax(Garage garage)
		{
			string license = GetLicenseNumberFromUser();
			if (!garage.IsVehicleExistInGarage(license)) { Console.WriteLine("Vehicle not found in the garage."); return; }

			foreach (var wheel in garage.GetVehicleInfo(license).Vehicle.Wheels)
				wheel.InflateToMax();

			Console.WriteLine("All wheels inflated to max air pressure.");
		}

		public void ShowVehicleDetails(Garage garage)
		{
			string license = GetLicenseNumberFromUser();
			if (!garage.IsVehicleExistInGarage(license)) { Console.WriteLine("Vehicle not found in the garage."); return; }

			VehicleInfo info = garage.GetVehicleInfo(license);
			Console.WriteLine(info.ToString());
		}

		public void RefuelVehicle(Garage garage)
		{
			string license = GetLicenseNumberFromUser();
			if (!garage.IsVehicleExistInGarage(license))
			{
				Console.WriteLine("Vehicle not found in the garage.");
				return;
			}

			VehicleInfo info = garage.GetVehicleInfo(license);
			if (info.Vehicle.Engine is not FuelEngine engine)
			{
				Console.WriteLine("❌ This vehicle does not support refueling with fuel.");
				return;
			}

			Console.WriteLine("Available fuel types:");
			foreach (string name in Enum.GetNames(typeof(FuelType)))
			{
				Console.WriteLine("- " + name);
			}

			FuelType type = InputValidator.GetValidFuelType();
			if (type != engine.FuelType)
			{
				Console.WriteLine($"❌ This vehicle requires {engine.FuelType}, you entered {type}.");
				return;
			}

			float amount = InputValidator.GetPositiveFloat("Enter amount to refuel:");
			try
			{
				engine.AddEnergy(amount);
				Console.WriteLine("✅ Vehicle refueled successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public void RechargeVehicle(Garage garage)
		{
			string license = GetLicenseNumberFromUser();
			if (!garage.IsVehicleExistInGarage(license))
			{
				Console.WriteLine("Vehicle not found in the garage.");
				return;
			}

			VehicleInfo info = garage.GetVehicleInfo(license);
			if (info.Vehicle.Engine is not ElectricEngine)
			{
				Console.WriteLine("❌ This vehicle does not support recharging.");
				return;
			}

			float amount = InputValidator.GetPositiveFloat("Enter amount of charge to add (in hours):");
			try
			{
				garage.RechargeVehicle(license, amount);
				Console.WriteLine("✅ Vehicle recharged successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public void ShowVehiclesByStatus(Garage garage)
		{
			try
			{
				Console.WriteLine("Select vehicle status to filter:");
				PrintVehicleStatuses();
				int choice = InputValidator.GetValidIntInRange("Your choice: ", 1, Enum.GetValues(typeof(VehicleStatus)).Length);
				foreach (var info in garage.GetVehiclesByStatus((VehicleStatus)choice).Values)
					Console.WriteLine(info.ToString());
			}
			catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
		}
	}
}
