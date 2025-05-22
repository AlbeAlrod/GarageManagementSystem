using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		private bool m_HazardousMaterials;
		private float m_CargoCapacity;

		public bool HazardousMaterials => m_HazardousMaterials;
		public float CargoCapacity => m_CargoCapacity;

		public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName, new FuelEngine(FuelType.Soler, 120f))
		{
			m_Wheels = new List<Wheel>(12);
		}
		public override void AddRestProperties(List<string> i_Parameters)
		{
			if (!bool.TryParse(i_Parameters[0], out m_HazardousMaterials))
			{
				throw new FormatException("Invalid format for hazardous materials flag.");
			}

			if (!float.TryParse(i_Parameters[1], out m_CargoCapacity))
			{
				throw new FormatException("Invalid format for cargo capacity.");
			}
		}

		public override Dictionary<string, string> CreatePropertiesDictionary(string[] i_Headers, string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionary(i_Headers, i_Properties);

			keyValuePairs.Add("HazardousMaterials", i_Properties[8]);
			keyValuePairs.Add("CargoCapacity", i_Properties[9]);

			return keyValuePairs;
		}
		public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			base.UpdateVehicleProperties(i_Properties);
			m_HazardousMaterials = bool.Parse(i_Properties["HazardousMaterials"]);
			m_CargoCapacity = float.Parse(i_Properties["CargoCapacity"]);
		}


	}
}
