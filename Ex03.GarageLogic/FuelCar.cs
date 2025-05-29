using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public FuelCar(string i_Model, string i_LicenseNumber)
            : base(i_Model, i_LicenseNumber, new FuelEngine(FuelType.Octan96, 45f))
        {
        }
    }
}
