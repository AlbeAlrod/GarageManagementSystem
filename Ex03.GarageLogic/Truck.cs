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
								}
								public override void AddRestProperties(Dictionary<string, string> i_Parameters)
								{
												m_HazardousMaterials = bool.Parse(i_Parameters["HazardousMaterials"]);
												// המרה ישירה של מספר הדלתות
												m_CargoCapacity = float.Parse(i_Parameters["CargoCapacity"]);
								}
				}
}
