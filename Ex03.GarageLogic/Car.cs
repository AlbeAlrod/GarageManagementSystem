using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Car : Vehicle
	{
		public const int k_MinDoors = 2;
		public const int k_MaxDoors = 5;
		private const int k_NumberOfWheels = 5;
		private const float k_MaxAirPressure = 30f;
		private const float k_FuelTankCapacity = 48f;
		private const FuelType k_FuelType = FuelType.Octan95;

		private CarColor m_Color { get; set; }
		private int m_NumberOfDoors { get; set; }

		public Car(string i_Model, string i_LicenseNumber, Engine i_Engine)
			: base(i_Model, i_LicenseNumber, i_Engine, k_NumberOfWheels)
		{
			m_Wheels = new List<Wheel>(k_NumberOfWheels);

			for (int i = 0; i < k_NumberOfWheels; i++)
			{
				m_Wheels.Add(new Wheel(k_MaxAirPressure));
			}
		}

		public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			base.UpdateVehicleProperties(i_Properties);
			m_Color = (CarColor)Enum.Parse(typeof(CarColor), i_Properties["CarColor"]);
			m_NumberOfDoors = int.Parse(i_Properties["NumberOfDoors"]);
		}

		public override Dictionary<string, string> CreateParametersDictForUser()
		{
			Dictionary<string, string> parametersForUser = base.CreateParametersDictForUser();

			parametersForUser.Add("CarColor", "Enter car color:");
			parametersForUser.Add("NumberOfDoors", "Enter number of doors:");

			return parametersForUser;
		}

		public override Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
		{
			var keyValuePairs = base.CreatePropertiesDictionaryFromLine(i_Properties);

			keyValuePairs.Add("CarColor", i_Properties[8]);
			keyValuePairs.Add("NumberOfDoors", i_Properties[9]);

			return keyValuePairs;
		}

		public override string GetDetails()
		{
			StringBuilder detailsBuilder = new StringBuilder(base.GetDetails());

			detailsBuilder.AppendLine($"Car color: {m_Color}");
			detailsBuilder.AppendLine($"Number of doors: {m_NumberOfDoors}");

			return detailsBuilder.ToString();
		}
	}
}
