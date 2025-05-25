using System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace Ex03.GarageLogic
{
				public class Car : Vehicle
				{
					private const int i_NumberOfWheels = 5;
				 //private const int m_MaxAirPressure = 30;
				 private Enums.CarColor m_Color { get; set; }
				 private int m_NumberOfDoors { get; set; }




					public Car (string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine, i_NumberOfWheels)
					{
								//SetEngine(i_Engine,
					}

				public override Dictionary<string,string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
				{
								Dictionary<string,string> keyValuePairs = base.CreatePropertiesDictionaryFromLine(i_Properties);

								keyValuePairs.Add("CarColor", i_Properties[8]);
								keyValuePairs.Add("NumberOfDoors", i_Properties[9]);

								return keyValuePairs;
					}

								public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
								{
												base.UpdateVehicleProperties(i_Properties);
												m_Color = (Enums.CarColor)Enum.Parse(typeof(Enums.CarColor), i_Properties["CarColor"]);
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
