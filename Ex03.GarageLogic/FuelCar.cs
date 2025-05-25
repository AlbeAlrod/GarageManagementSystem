using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class FuelCar : Car
	{
		//	public Engine m_Engine;
		public FuelCar(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber, new FuelEngine(FuelType.Octane96, 45f))
		{
		}


	}
}
