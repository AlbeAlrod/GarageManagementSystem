using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
	public class FuelMotorcycle : Motorcycle
	{
		private const float k_FuelTankCapacity = 5.8f;
		private const FuelType k_FuelType = FuelType.Octan98;

		public FuelMotorcycle(string i_Model, string i_LicenseNumber)
		   : base(i_Model, i_LicenseNumber, new FuelEngine(k_FuelType, k_FuelTankCapacity))
		{
			m_Wheels = new List<Wheel>(2);
			for (int i = 0; i < 2; i++)
			{
				m_Wheels.Add(new Wheel(MaxAirPressure));
			}
		}

								/*
		public override Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
		{
			var keyValuePairs = base.CreatePropertiesDictionaryFromLine(i_Properties);

			if (i_Properties.Length > 8)
				keyValuePairs.Add("LicenseType", i_Properties[8]);
			else
				keyValuePairs.Add("LicenseType", string.Empty);

			if (i_Properties.Length > 9)
				keyValuePairs.Add("EngineCapacity", i_Properties[9]);
			else
				keyValuePairs.Add("EngineCapacity", string.Empty);

			return keyValuePairs;
		}
								*/
	}
}
