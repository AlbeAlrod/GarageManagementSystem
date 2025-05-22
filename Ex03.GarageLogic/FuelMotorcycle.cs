using static Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public class FuelMotorcycle : Motorcycle
	{
        private const FuelType k_FuelType = FuelType.Octane95;

		public FuelMotorcycle(string i_ModelName, string i_LicenseNumber)
			: base(i_ModelName, i_LicenseNumber, new FuelEngine(k_FuelType, FuelEngine.k_DefaultCapacities[k_FuelType]))
		{

		}
	}
}
