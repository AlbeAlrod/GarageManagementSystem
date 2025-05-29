using System;

namespace Ex03.GarageLogic
{
    public class VehicleValidator
    {
        private readonly Garage m_Garage;

        public VehicleValidator(Garage i_Garage)
        {
            m_Garage = i_Garage;
        }

        public bool IsValidLicensePlate(string i_LicenseNumber)
        {
            if (string.IsNullOrEmpty(i_LicenseNumber))
            {
                throw new ArgumentException("License number cannot be empty");
            }

            return true;
        }

        public bool IsLicensePlateExists(string i_LicenseNumber)
        {
            return m_Garage.IsVehicleExistInGarage(i_LicenseNumber);
        }
    }
}