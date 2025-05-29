using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		private const int k_NumberOfWheels = 12;
		private const float k_MaxAirPressure = 27f;
		private const float k_FuelTankCapacity = 135f;
		private const FuelType k_FuelType = FuelType.Solar;

		private bool m_HazardousMaterials;
		private float m_CargoCapacity;


		public Truck(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber, new FuelEngine(k_FuelType, k_FuelTankCapacity), k_NumberOfWheels)
		{
			m_Wheels = new List<Wheel>(k_NumberOfWheels);
			for (int i = 0; i < k_NumberOfWheels; i++)
			{
				m_Wheels.Add(new Wheel(k_MaxAirPressure));
			}
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
			paramsDict.Add("CargoCapacity", "Enter the cargo capacity (in cubic meters):");
			return paramsDict;
		}

		public override string GetDetails()
		{
			StringBuilder details = new StringBuilder(base.GetDetails());
			details.AppendLine($"Carries hazardous materials: {(m_HazardousMaterials ? "Yes" : "No")}");
			details.AppendLine($"Cargo capacity: {m_CargoCapacity} cubic meters");
			return details.ToString();
		}
	}
}