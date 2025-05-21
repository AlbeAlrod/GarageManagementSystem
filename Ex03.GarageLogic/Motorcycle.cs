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

					}

								public override void AddRestProperties(Dictionary<string, string> i_Parameters)
								{
												m_LicenseType = (Enums.MotorcycleLicenseType)Enum.Parse(typeof(Enums.MotorcycleLicenseType), i_Parameters["LicenseType"]);
												m_EngineCapacity = int.Parse(i_Parameters["EngineCapacity"]);
								}


				}
}
