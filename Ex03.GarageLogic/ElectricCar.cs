using System;
using System.Collections.Generic;
using Ex03.GarageLogic;



namespace Ex03.GarageLogic
{
	public class ElectricCar : Car
	{
		private const float k_BatteryCapacity = 50f;
		public ElectricCar(string i_Model, string i_LicenseNumber)
	: base(i_Model, i_LicenseNumber, new ElectricEngine(50f))
		{
		}


	}
}
