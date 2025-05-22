using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
	public class Motorcycle : Vehicle
	{
		private Enums.MotorcycleLicenseType m_LicenseType;
		private int m_EngineCapacity;

		public MotorcycleLicenseType LicenseType => m_LicenseType;
		public int EngineCapacity => m_EngineCapacity;

		public Motorcycle(string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine)
		{
			m_Wheels = new List<Wheel>(2);

		}

		public override void AddRestProperties(List<string> i_Parameters)
		{
			if (!Enum.TryParse(i_Parameters[0], out m_LicenseType))
			{
				throw new FormatException("Invalid license type.");
			}
			if (!int.TryParse(i_Parameters[1], out m_EngineCapacity))
			{
				throw new FormatException("Invalid engine capacity.");
			}
		}
		public override Dictionary<string, string> CreatePropertiesDictionary(string[] i_Headers, string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionary(i_Headers, i_Properties);

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
