using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_BatteryCapacity = 2.5f;

        public ElectricMotorcycle(string i_Model, string i_LicenseNumber)
            : base(i_Model, i_LicenseNumber, new ElectricEngine(k_BatteryCapacity))
        {
        }
    }
}
