using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		public bool m_HazardousMaterials;
		public float m_CargoCapacity;
		private const int k_NumberOfWheels = 12;
		public Truck(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber, new FuelEngine(FuelType.Soler, 120f), k_NumberOfWheels)
		{

			m_Engine = new FuelEngine();
			m_VehicleStatus = VehicleStatus.InRepair;
			m_Wheels = new List<Wheel>(k_NumberOfWheels);
		}

		public override void AddRestProperties(List<string> i_Parameters)
		{
			m_HazardousMaterials = bool.Parse(i_Parameters[0]);
			m_CargoCapacity = float.Parse(i_Parameters[1]);
		}

		public override Dictionary<string, string> CreatePropertiesDictionary(string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionary(i_Properties);

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

