using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class Motorcycle : Vehicle
	{
		private const int i_NumberOfWheels = 2;
		private const int m_MaxAirPressure = 30;

		public MotorcycleLicenseType m_LicenseType { get; set; }
		public int m_EngineCapacity { get; set; }

		public Motorcycle(string i_Model, string i_LicenseNumber, Engine i_Engine) : base(i_Model, i_LicenseNumber, i_Engine, 2)
		{
			m_Wheels = new List<Wheel>();
			for (int i = 0; i < 2; i++)
			{
				m_Wheels.Add(new Wheel(30f));
			}
		}

		public override Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionaryFromLine(i_Properties);

			keyValuePairs.Add("LicenseType", i_Properties[8]);
			keyValuePairs.Add("EngineCapacity", i_Properties[9]);

			return keyValuePairs;
		}
		public override void UpdateVehicleProperties(Dictionary<string, string> i_Params)
		{
			base.UpdateVehicleProperties(i_Params);
			m_LicenseType = (MotorcycleLicenseType)Enum.Parse(typeof(MotorcycleLicenseType), i_Params["LicenseType"]);
			m_EngineCapacity = int.Parse(i_Params["EngineCapacity"]);
		}

		public override Dictionary<string, string> CreateParametersDictForUser()
		{
			Dictionary<string, string> paramsDict = base.CreateParametersDictForUser();
			paramsDict.Add("LicenseType", "Enter license type:");
			paramsDict.Add("EngineCapacity", "Enter engine capacity:");
			return paramsDict;
		}

		public override string GetDetails()
		{
			StringBuilder details = new StringBuilder(base.GetDetails());
			details.AppendLine($"License type: {m_LicenseType}");
			details.AppendLine($"Engine capacity: {m_EngineCapacity} cc");
			return details.ToString();
		}


	}
}
