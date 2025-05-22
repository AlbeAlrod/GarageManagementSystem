using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        //	public Engine m_Engine;

        public FuelCar(string i_Model, string i_LisenceNumber)
            : base(i_Model, i_LisenceNumber, new FuelEngine(FuelType.Octane96, FuelEngine.k_DefaultCapacities[FuelType.Octane96]))
        {

        }

        public override string ToString()
        {
            FuelEngine fuelEngine = m_Engine as FuelEngine;
            string fuelTypeString = fuelEngine != null ? fuelEngine.EngineFuelType.ToString() : "Unknown";

            return string.Format(
                "{0}\nFuel Type: {1}",
                base.ToString(),
                fuelTypeString);
        }
    }
}
