using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void Main()
        {
            LoadVehiclesFromFile("Vehicles.db");

            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                string choice = ReadValidOption();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddNewVehicle();
                            break;
                        case "2":
                            ShowAllVehicles();
                            break;
                        case "3":
                            UpdateVehicleStatus();
                            break;
                        case "4":
                            RefuelVehicle();
                            break;
                        case "5":
                            RechargeVehicle();
                            break;
                        case "6":
                            InflateVehicleWheels();
                            break;
                        case "7":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void LoadVehiclesFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                Console.WriteLine($"Loading vehicles from {filePath}...");
                var vehicles = DataLoader.LoadVehiclesFromFile(filePath);
                foreach (var vehicle in vehicles)
                {
                    try
                    {
                        s_GarageManager.AddVehicle(vehicle);
                    }
                    catch
                    {
                        // רכב כבר קיים - מתעלמים
                    }
                }
                Console.WriteLine($"Loaded {vehicles.Count} vehicles.");
            }
            else
            {
                Console.WriteLine($"Data file {filePath} not found, starting with empty garage.");
            }
            Console.WriteLine();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("=== Garage Management System ===");
            Console.WriteLine("1. Add New Vehicle");
            Console.WriteLine("2. Show All Vehicles");
            Console.WriteLine("3. Update Vehicle Status");
            Console.WriteLine("4. Refuel Vehicle");
            Console.WriteLine("5. Recharge Vehicle");
            Console.WriteLine("6. Inflate Vehicle Wheels");
            Console.WriteLine("7. Exit");
            Console.Write("Please select an option (1-7): ");
        }

        private static string ReadValidOption()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && "1234567".Contains(input))
                {
                    return input;
                }
                Console.Write("Invalid input. Please enter a number between 1 and 7: ");
            }
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        private static float ReadFloat(string prompt, float min = float.MinValue, float max = float.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (float.TryParse(input, out float value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        Console.WriteLine($"Value must be between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }
            }
        }

        private static T ReadEnum<T>(string prompt) where T : struct
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (Enum.TryParse<T>(input, true, out T value))
                {
                    return value;
                }
                Console.WriteLine($"Invalid value. Valid options: {string.Join(", ", Enum.GetNames(typeof(T)))}");
            }
        }

        private static void AddNewVehicle()
        {
            Console.WriteLine("Enter vehicle type (FuelCar, ElectricCar, FuelMotorcycle, ElectricMotorcycle, Truck):");
            string type;
            HashSet<string> validTypes = new HashSet<string> { "FuelCar", "ElectricCar", "FuelMotorcycle", "ElectricMotorcycle", "Truck" };
            while (true)
            {
                type = Console.ReadLine();
                if (validTypes.Contains(type))
                    break;
                Console.Write("Invalid vehicle type. Please enter one of the listed types: ");
            }

            string license = ReadNonEmptyString("Enter license number: ");
            string model = ReadNonEmptyString("Enter model name: ");

            Engine engine = type switch
            {
                "FuelCar" => new FuelEngine(FuelType.Octane95, 45f),
                "ElectricCar" => new ElectricEngine(50f),
                "FuelMotorcycle" => new FuelEngine(FuelType.Octane96, 6f),
                "ElectricMotorcycle" => new ElectricEngine(5f),
                "Truck" => new FuelEngine(FuelType.Soler, 120f),
                _ => throw new Exception("Unknown vehicle type")
            };

            Vehicle vehicle = VehicleCreator.CreateVehicle(type, license, model);

            int wheelsCount = type switch
            {
                "FuelCar" => 4,
                "ElectricCar" => 4,
                "FuelMotorcycle" => 2,
                "ElectricMotorcycle" => 2,
                "Truck" => 12,
                _ => 4
            };

            Console.WriteLine("Enter wheel manufacturer name:");
            string wheelManufacturer = ReadNonEmptyString("> ");

            float currentAirPressure = ReadFloat("Enter current air pressure: ", 0, 32f);
            float maxAirPressure = 32f;

            vehicle.CreateWheels(wheelsCount, wheelManufacturer, currentAirPressure, maxAirPressure);

            // Extra properties input
            List<string> extraProps = new List<string>();
            switch (type)
            {
                case "FuelCar":
                case "ElectricCar":
                    var carColor = ReadEnum<CarColor>("Enter car color (Yellow, Black, White, Silver): ");
                    extraProps.Add(carColor.ToString());
                    int doors = (int)ReadEnum<DoorsNumber>("Enter number of doors (2,3,4,5): ");
                    extraProps.Add(doors.ToString());
                    break;

                case "FuelMotorcycle":
                case "ElectricMotorcycle":
                    var licenseType = ReadEnum<MotorcycleLicenseType>("Enter motorcycle license type (A, A1, A2, B1, B2, AB): ");
                    extraProps.Add(licenseType.ToString());
                    int engineCapacity = (int)ReadFloat("Enter engine capacity (cc): ", 1, 2000);
                    extraProps.Add(engineCapacity.ToString());
                    break;

                case "Truck":
                    bool hazardous = false;
                    while (true)
                    {
                        Console.Write("Does it carry hazardous materials? (true/false): ");
                        string hazInput = Console.ReadLine();
                        if (bool.TryParse(hazInput, out hazardous)) break;
                        Console.WriteLine("Invalid input. Please enter true or false.");
                    }
                    extraProps.Add(hazardous.ToString());
                    float cargoCap = ReadFloat("Enter cargo capacity (kg): ", 0);
                    extraProps.Add(cargoCap.ToString());
                    break;
            }

            vehicle.AddDetails(0, wheelManufacturer, currentAirPressure, vehicle.Wheels, "DefaultOwner", "0000000000", extraProps);

            s_GarageManager.AddVehicle(vehicle);
            Console.WriteLine("Vehicle added successfully!");
        }

        private static void ShowAllVehicles()
        {
            var allVehicles = s_GarageManager.GetAllVehicles();
            foreach (var vehicle in allVehicles)
            {
                Console.WriteLine(vehicle);
                Console.WriteLine("-------------------------");
            }
        }

        private static void UpdateVehicleStatus()
        {
            string license = ReadNonEmptyString("Enter license number of vehicle: ");
            VehicleStatus status = ReadEnum<VehicleStatus>("Enter new status (InRepair, Ready, Paid): ");
            s_GarageManager.UpdateVehicleStatus(license, status);
            Console.WriteLine("Status updated.");
        }

        private static void RefuelVehicle()
        {
            string license = ReadNonEmptyString("Enter license number of vehicle: ");
            float amount = ReadFloat("Enter amount of fuel: ", 0);
            FuelType fuelType = ReadEnum<FuelType>("Enter fuel type (Octane95, Octane96, Soler): ");
            var vehicle = s_GarageManager.GetVehicle(license);
            vehicle.Refuel(amount, fuelType);
            Console.WriteLine("Vehicle refueled.");
        }

        private static void RechargeVehicle()
        {
            string license = ReadNonEmptyString("Enter license number of vehicle: ");
            float amount = ReadFloat("Enter amount of charge (hours): ", 0);
            var vehicle = s_GarageManager.GetVehicle(license);
            vehicle.Recharge(amount);
            Console.WriteLine("Vehicle recharged.");
        }

        private static void InflateVehicleWheels()
        {
            string license = ReadNonEmptyString("Enter license number of vehicle: ");
            var vehicle = s_GarageManager.GetVehicle(license);

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            vehicle.InflateAllWheelsToMax();
            Console.WriteLine("All wheels inflated to max.");
        }
    }
}