using System;
using System.Collections.Generic;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class DataLoader
    {
        public static List<Vehicle> LoadVehiclesFromFile(string filePath)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Data file not found: " + filePath);
                return vehicles;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("*****")) // לדלג על שורות ריקות או קו מפריד
                    continue;

                string[] parts = line.Split(',');

                try
                {
                    string vehicleType = parts[0];
                    string licenseNumber = parts[1];
                    string modelName = parts[2];

                    Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licenseNumber, modelName);

                    // המרת שאר הפרטים בהתאם לפורמט, לדוגמה:
                    // parts[3] = EnergyPercentage
                    // parts[4] = TierModel
                    // parts[5] = CurrAirPressure
                    // parts[6] = OwnerName
                    // parts[7] = OwnerPhone
                    // parts[8...] = פרטים ספציפיים לרכב

                    List<string> restProperties = new List<string>();
                    for (int i = 8; i < parts.Length; i++)
                    {
                        restProperties.Add(parts[i]);
                    }

                    // יצירת גלגלים (לדוגמה 4 גלגלים עם פרמטרים מהשורה)
                    int numberOfWheels = vehicleType switch
                    {
                        "FuelCar" => 4,
                        "ElectricCar" => 4,
                        "FuelMotorcycle" => 2,
                        "ElectricMotorcycle" => 2,
                        "Truck" => 12,
                        _ => 4 // ברירת מחדל
                    };

                    List<Wheel> wheels = Wheel.CreateListOfWheels(numberOfWheels, parts[4], float.Parse(parts[5]), 32f);
                    vehicle.AddDetails(
                        i_EnergyPrecent: float.Parse(parts[3]),
                        i_WheelModel: parts[4],
                        i_CurrentAirPressure: float.Parse(parts[5]),
                        i_ListOfWheels: wheels,
                        i_OwnerName: parts[6],
                        i_OwnerNumber: parts[7],
                        i_RestProperties: restProperties
                    );

                    vehicles.Add(vehicle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading vehicle from line: {line}");
                    Console.WriteLine("Reason: " + ex.Message);
                }
            }

            return vehicles;
        }
    }
}