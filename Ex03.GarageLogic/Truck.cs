using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
				public class Truck : Vehicle
				{
								private const int i_NumberOfwheels = 12;
							 private bool m_HazardousMaterials;
								private float m_CargoCapacity;

								public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName, new FuelEngine(), i_NumberOfwheels)
								{
								}
								public override void AddRestProperties(List<string> i_Parameters)
								{
												m_HazardousMaterials = bool.Parse(i_Parameters[0]);
												m_CargoCapacity = float.Parse(i_Parameters[1]);
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
												m_HazardousMaterials = bool.Parse(i_Properties["HazardousMaterials"]);
												m_CargoCapacity = float.Parse(i_Properties["CargoCapacity"]);
								}

									public override Dictionary<string, string> CreateParametersDictForUser()
								{
								   Dictionary<string,string> paramsDict = base.CreateParametersDictForUser();
												paramsDict.Add("HazardousMaterials", "Does the trunk curry hazardous materials ? Yes/No:");
												paramsDict.Add("CargoCapacity", "Enter the cargo capacity:");
												return paramsDict;
								}


				}
}
