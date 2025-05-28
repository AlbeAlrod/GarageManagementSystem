using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		private const int k_NumberOfWheels = 12;
		private const float k_MaxFuelCapacity = 120f;
		private const FuelType k_TruckFuelType = FuelType.Solar;

		private bool m_HazardousMaterials;
		private float m_CargoCapacity;

		public Truck(string i_Model, string i_LicenseNumber)
			: base(i_Model, i_LicenseNumber, new FuelEngine(k_TruckFuelType, k_MaxFuelCapacity), k_NumberOfWheels)
		{
		}



		public override Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionaryFromLine(i_Properties);
			keyValuePairs.Add("HazardousMaterials", i_Properties[8]);
			keyValuePairs.Add("CargoCapacity", i_Properties[9]);
			return keyValuePairs;
		}

		public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			base.UpdateVehicleProperties(i_Properties);
			if (i_Properties["HazardousMaterials"] == "No")
				m_HazardousMaterials = false;
			else
				m_HazardousMaterials = true;
			m_CargoCapacity = float.Parse(i_Properties["CargoCapacity"]);
		}

		public override Dictionary<string, string> CreateParametersDictForUser()
		{
			Dictionary<string, string> paramsDict = base.CreateParametersDictForUser();
			paramsDict.Add("HazardousMaterials", "Does the truck carry hazardous materials? Yes/No:");
			paramsDict.Add("CargoCapacity", "Enter the cargo capacity:");
			return paramsDict;
		}
	}
}