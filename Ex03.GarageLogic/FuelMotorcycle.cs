using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public class FuelMotorcycle : Motorcycle
	{

		public FuelMotorcycle(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber, new FuelEngine(FuelType.Octane95, 38f))
		{
		}
	}
}
