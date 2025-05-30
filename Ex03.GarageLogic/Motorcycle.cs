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
		private const int k_NumberOfWheels = 2;
		private const float k_MaxAirPressure = 100f;

		private MotorcycleLicenseType m_LicenseType { get; set; }
		private int m_EngineCapacity { get; set; }
  public float MaxAirPressure
    {
        get { return k_MaxAirPressure; }
    }
		public Motorcycle(string i_Model, string i_LicenseNumber, Engine i_Engine)
			: base(i_Model, i_LicenseNumber, i_Engine, k_NumberOfWheels)
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
			Dictionary<string, string> parametersForUser = base.CreateParametersDictForUser();
			parametersForUser.Add("LicenseType", "Enter license type:");
			parametersForUser.Add("EngineCapacity", "Enter engine capacity:");
			return parametersForUser;
		}

		public override string GetDetails()
		{
			StringBuilder detailsBuilder = new StringBuilder(base.GetDetails());
			detailsBuilder.AppendLine($"License type: {m_LicenseType}");
			detailsBuilder.AppendLine($"Engine capacity: {m_EngineCapacity} cc");
			return detailsBuilder.ToString();
		}


	}
}
