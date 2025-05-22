using System;
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

            Console.Write("Enter vehicle type: ");
            string vehicleType = Console.ReadLine();

            Console.Write("Enter model name: ");
            string modelName = Console.ReadLine();

            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine();

            try
            {
                Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licenseNumber, modelName);
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