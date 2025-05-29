using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Ex03.GarageLogic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Car : Vehicle
	{
		private const int k_NumberOfWheels = 5;
		private const float k_MaxAirPressure = 30f;
		private const float k_FuelTankCapacity = 48f;
		private const FuelType k_FuelType = FuelType.Octan95; // או Octan32 לפי ההגדרה שלך

		private CarColor m_Color { get; set; }
		private int m_NumberOfDoors { get; set; }

		public Car(string i_Model, string i_LicenseNumber, Engine i_Engine) : base(i_Model, i_LicenseNumber, i_Engine, k_NumberOfWheels)
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
			Dictionary<string, string> paramsDict = base.CreateParametersDictForUser();
			paramsDict.Add("CarColor", "Enter car color:");
			paramsDict.Add("NumberOfDoors", "Enter number of doors:");
			return paramsDict;
		}

		public override string GetDetails()
    {
        StringBuilder details = new StringBuilder(base.GetDetails());
        details.AppendLine($"Car color: {m_Color}");
        details.AppendLine($"Number of doors: {m_NumberOfDoors}");
        return details.ToString();
    }


	}
}
