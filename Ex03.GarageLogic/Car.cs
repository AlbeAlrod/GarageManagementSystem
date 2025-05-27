using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
				public class Car : Vehicle
				{
					private const int k_NumberOfWheels = 5;
				 //private const int m_MaxAirPressure = 30;
				 private CarColor m_Color { get; set; }
				 private int m_NumberOfDoors { get; set; }


				public Car(string i_Model, string i_LicenseNumber, Engine i_Engine) : base(i_Model, i_LicenseNumber, i_Engine, k_NumberOfWheels)
		{
			m_Wheels = new List<Wheel>(5);
		}


		public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			base.UpdateVehicleProperties(i_Properties);
			m_Color = (CarColor)Enum.Parse(typeof(CarColor), i_Properties["CarColor"]);
			m_NumberOfDoors = int.Parse(i_Properties["NumberOfDoors"]);
		}

								public override Dictionary<string, string> CreateParametersDictForUser()
								{
								   Dictionary<string,string> paramsDict = base.CreateParametersDictForUser();
												paramsDict.Add("CarColor", "Enter car color:");
												paramsDict.Add("NumberOfDoors", "Enter number of doors:");
												return paramsDict;
								}

								


	}
}
