using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
				public class Truck : Vehicle
				{
				 public bool m_HazardousMaterials;
					public float m_CargoCapacity;
								public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName, new FuelEngine())
								{
												m_Wheels = new List<Wheel>(12);
								}
								public override void AddRestProperties(List<string> i_Parameters)
								{
												m_HazardousMaterials = bool.Parse(i_Parameters[0]);
												// המרה ישירה של מספר הדלתות
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
