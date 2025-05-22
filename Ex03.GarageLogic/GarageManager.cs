using System;
using System.Collections.Generic;
using System.Linq;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_Vehicles;

        public GarageManager()
        {
            r_Vehicles = new Dictionary<string, Vehicle>();
        }

        // הוספת רכב למלאי
        public void AddVehicle(Vehicle i_Vehicle)
        {
            if (r_Vehicles.ContainsKey(i_Vehicle.GetLisenceNumber()))
            {
                throw new ArgumentException("Vehicle with this license number already exists.");
            }
            r_Vehicles.Add(i_Vehicle.GetLisenceNumber(), i_Vehicle);
        }

        // הסרת רכב לפי מספר רישוי
        public void RemoveVehicle(string i_LicenseNumber)
        {
            if (!r_Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new KeyNotFoundException("Vehicle not found.");
            }
            r_Vehicles.Remove(i_LicenseNumber);
        }

        // קבלת רכב לפי מספר רישוי
        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out Vehicle vehicle))
            {
                throw new KeyNotFoundException("Vehicle not found.");
            }
            return vehicle;
        }

        // עדכון סטטוס רכב
        public void UpdateVehicleStatus(string i_LicenseNumber, VehicleStatus i_NewStatus)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNumber);
            vehicle.UpdateVehicleStatus(i_NewStatus);
        }

        // קבלת כל הרכבים
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return r_Vehicles.Values;
        }

        // חיפוש רכבים לפי סטטוס (אפשר להרחיב עם קריטריונים נוספים)
        public IEnumerable<Vehicle> GetVehiclesByStatus(VehicleStatus i_Status)
        {
            return r_Vehicles.Values.Where(v => v != null && v.VehicleStatus == i_Status);
        }
    }
}