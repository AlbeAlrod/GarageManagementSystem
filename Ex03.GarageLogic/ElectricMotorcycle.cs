using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public class ElectricMotorcycle : Motorcycle
	{
		private const float k_BatteryCapacity = 2.5f;

		public ElectricMotorcycle(string i_Model, string i_LisenceNumber) 
			: base(i_Model, i_LisenceNumber, new ElectricEngine(k_BatteryCapacity))
		{

		}

	}
}
