using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
				public class Motorcycle : Vehicle
				{
				 public Enums.MotorcycleLicenseType m_LicenseType{  get; set; }
					public int m_EngineCapacity { get; set; }

					public Motorcycle(string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine)
					{
												m_Wheels = new List<Wheel>(2);
					 }

								public override void AddRestProperties(List<string> i_Parameters)
								{
												m_LicenseType = (Enums.MotorcycleLicenseType)Enum.Parse(typeof(Enums.MotorcycleLicenseType), i_Parameters[0]);
												m_EngineCapacity = int.Parse(i_Parameters[1]);
								}
								public override Dictionary<string, string> CreatePropertiesDictionary(string[] i_Properties)
								{
												Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionary(i_Properties);

												keyValuePairs.Add("LicenseType", i_Properties[8]);
												keyValuePairs.Add("EngineCapacity", i_Properties[9]);

												return keyValuePairs;
								}
								public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
								{
												base.UpdateVehicleProperties(i_Properties);
												m_LicenseType = (Enums.MotorcycleLicenseType)Enum.Parse(typeof(Enums.MotorcycleLicenseType), i_Properties["LicenseType"]);
												m_EngineCapacity = int.Parse(i_Properties["EngineCapacity"]);
								}


				}
}
