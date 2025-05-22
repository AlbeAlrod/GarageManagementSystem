using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Garage Management System!");
            Console.WriteLine("Supported vehicle types:");
            foreach (string type in VehicleCreator.SupportedTypes)
            {
                Console.WriteLine("- " + type);
            }

            Console.Write("\nEnter vehicle type: ");
            string vehicleType = Console.ReadLine();

            if (!VehicleCreator.SupportedTypes.Contains(vehicleType))
            {
                Console.WriteLine($"Error: Vehicle type '{vehicleType}' is not supported.");
                return;
            }

            Console.Write("Enter model name: ");
            string modelName = Console.ReadLine();

            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();

            List<string> extraProperties = new List<string>();

            switch (vehicleType)
            {
                case "FuelCar":
                case "ElectricCar":
                    Console.Write("Enter car color (Yellow, Black, White, Silver): ");
                    extraProperties.Add(Console.ReadLine());
                    Console.Write("Enter number of doors (2-5): ");
                    extraProperties.Add(Console.ReadLine());
                    break;

                case "FuelMotorcycle":
                case "ElectricMotorcycle":
                    Console.Write("Enter motorcycle license type (A, A1, A2, B1, B2, AB): ");
                    extraProperties.Add(Console.ReadLine());
                    Console.Write("Enter engine capacity (cc): ");
                    extraProperties.Add(Console.ReadLine());
                    break;

                case "Truck":
                    Console.Write("Does it carry hazardous materials? (true/false): ");
                    extraProperties.Add(Console.ReadLine());
                    Console.Write("Enter cargo capacity (kg): ");
                    extraProperties.Add(Console.ReadLine());
                    break;
            }

            Console.Write("Enter wheel manufacturer name: ");
            string wheelManufacturer = Console.ReadLine();

            Console.Write("Enter current air pressure for wheels: ");
            float currentAirPressure = float.Parse(Console.ReadLine());

            float maxAirPressure = 32f; // ניתן לשנות לפי צורך

            int numberOfWheels = vehicleType switch
            {
                "FuelCar" => 4,
                "ElectricCar" => 4,
                "FuelMotorcycle" => 2,
                "ElectricMotorcycle" => 2,
                "Truck" => 12,
                _ => 0
            };

            try
            {
                Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, modelName, licenseNumber);
                vehicle.CreateWheels(numberOfWheels, wheelManufacturer, currentAirPressure, maxAirPressure);

                vehicle.AddDetails(
                    0,
                    wheelManufacturer,
                    currentAirPressure,
                    vehicle.Wheels,
                    "Default Owner",
                    "0000000000",
                    extraProperties);

                Console.WriteLine("\nVehicle created successfully:\n");
                Console.WriteLine(vehicle.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating vehicle: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}