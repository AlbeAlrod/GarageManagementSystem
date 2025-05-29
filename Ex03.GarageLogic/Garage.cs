using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInfo> m_Vehicles = new Dictionary<string, VehicleInfo>();
        private List<CustomerInfo> m_Customers = new List<CustomerInfo>();

        public void AddVehicleToVehiclesInfo(Vehicle i_Vehicle, CustomerInfo i_Customer, VehicleStatus i_Status)
        {
            VehicleInfo newVehicleInfo = new VehicleInfo(i_Vehicle, i_Customer, i_Status);
            m_Vehicles.Add(i_Vehicle.LicenseNumber, newVehicleInfo);
        }

        public void LoadVehiclesFromFile(string i_FilePath)
        {
            string[] lines = File.ReadAllLines(i_FilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("*") || line.StartsWith("THE FORMAT"))
                    continue;

                string[] vehicleData = line.Split(',');
                if (vehicleData.Length < 8)
                    continue;

                try
                {
                    string vehicleType = vehicleData[0].Trim();
                    string licensePlate = vehicleData[1].Trim();
                    string modelName = vehicleData[2].Trim();

                    Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);

                    int requiredFields = newVehicle.CreatePropertiesDictionaryFromLine(new string[0]).Count;
                    if (vehicleData.Length < requiredFields)
                        throw new FormatException($"Not enough fields for {vehicleType}. Expected at least {requiredFields}, got {vehicleData.Length}.");

                    Dictionary<string, string> restProperties = newVehicle.CreatePropertiesDictionaryFromLine(vehicleData);
                    newVehicle.UpdateVehicleProperties(restProperties);

                    CustomerInfo customer = new CustomerInfo();
                    customer.UpdateCustomerParams(restProperties);

                    AddVehicleToVehiclesInfo(newVehicle, customer, VehicleStatus.InRepair);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading vehicle data from line: {line}. Exception: {ex.Message}");
                }
            }

            Console.WriteLine("Vehicles loaded successfully.");
        }

        public bool IsVehicleExistInGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void PrintAllVehicles()
        {
            foreach (KeyValuePair<string, VehicleInfo> vehiclePair in m_Vehicles)
            {
                Console.WriteLine(vehiclePair.Value.ToString());
            }
        }

        public void ModifyVehicleStatus(string i_VehicleLicenseNumber, VehicleStatus i_NewStatus)
        {
            VehicleInfo vehicleInfo = GetVehicleInfo(i_VehicleLicenseNumber);
            vehicleInfo.SetVehicleStatus(i_NewStatus);
        }

        public VehicleInfo GetVehicleInfo(string i_LicenseNumber)
        {
            if (m_Vehicles.TryGetValue(i_LicenseNumber, out VehicleInfo vehicleInfo))
            {
                return vehicleInfo;
            }

            throw new ArgumentException(
                $"No vehicle found with license number '{i_LicenseNumber}'.",
                nameof(i_LicenseNumber)
            );
        }

        public void AddNewVehicle(
            string i_VehicleType,
            string i_LicenseNumber,
            string i_Model,
            Dictionary<string, string> i_PropertiesDict,
            CustomerInfo i_Customer,
            VehicleStatus i_Status)
        {
            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_Model);
            newVehicle.UpdateVehicleProperties(i_PropertiesDict);
            AddCustomer(i_Customer);
            AddVehicleToVehiclesInfo(newVehicle, i_Customer, i_Status);
        }

        public void AddCustomer(CustomerInfo i_Customer)
        {
            m_Customers.Add(i_Customer);
        }

        public Dictionary<string, VehicleInfo> GetVehiclesInfo()
        {
            return m_Vehicles;
        }

        public Dictionary<string, VehicleInfo> VehiclesInfo
        {
            get { return m_Vehicles; }
        }

        public void RefuelVehicle(string i_LicenseNumber, FuelType i_FuelType, float i_Amount)
        {
            VehicleInfo vehicleInfo = GetVehicleInfo(i_LicenseNumber);

            if (!(vehicleInfo.Vehicle.Engine is FuelEngine fuelEngine))
            {
                throw new InvalidOperationException("Vehicle does not support fuel engine.");
            }

            if (fuelEngine.FuelType != i_FuelType)
            {
                throw new ArgumentException($"Fuel type mismatch: vehicle requires {fuelEngine.FuelType}");
            }

            if (fuelEngine.CurrentEnergy + i_Amount > fuelEngine.MaxCapacity)
            {
                throw new ArgumentOutOfRangeException("Refuel amount exceeds tank capacity.");
            }

            fuelEngine.AddEnergy(i_Amount);
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_AmountToCharge)
        {
            VehicleInfo vehicleInfo = GetVehicleInfo(i_LicenseNumber);
            Vehicle vehicle = vehicleInfo.Vehicle;

            if (vehicle.Engine is ElectricEngine electricEngine)
            {
                electricEngine.AddEnergy(i_AmountToCharge);
            }
            else
            {
                throw new ArgumentException("This vehicle does not have an electric engine.");
            }
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            if (!m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            VehicleInfo vehicleInfo = m_Vehicles[i_LicenseNumber];
            Vehicle vehicle = vehicleInfo.Vehicle;

            foreach (Wheel wheel in vehicle.Wheels)
            {
                float amountToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.AddAir(amountToAdd);
            }
        }

        public Dictionary<string, VehicleInfo> GetVehiclesByStatus(VehicleStatus i_Status)
        {
            return m_Vehicles
                .Where(pair => pair.Value.VehicleStatus == i_Status)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}