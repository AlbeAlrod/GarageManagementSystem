using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public class FuelMotorcycle : Motorcycle
	{

		private const float k_MaxAirPressure = 30f;
		private const float k_FuelTankCapacity = 5.8f;
		private const FuelType k_FuelType = FuelType.Octan98;

		public FuelMotorcycle(string i_Model, string i_LicenseNumber)
		   : base(i_Model, i_LicenseNumber, new FuelEngine(k_FuelType, k_FuelTankCapacity))
		{
			m_Wheels = new List<Wheel>(2);
			for (int i = 0; i < 2; i++)
			{
				m_Wheels.Add(new Wheel(k_MaxAirPressure));
			}
		}
	}
}
