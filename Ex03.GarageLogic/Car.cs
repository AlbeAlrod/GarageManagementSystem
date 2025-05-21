using System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace Ex03.GarageLogic
{
				public class Car : Vehicle
				{
				 public Enums.CarColor m_Color { get; set; }
				 public int m_NumberOfDoors { get; set; }


					public Car (string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine)
					{
							m_Wheels = new List<Wheel>(5);
					}

				
					public override void AddRestProperties(List<string> i_Parameters)
					{
										m_Color = (Enums.CarColor)Enum.Parse(typeof(Enums.CarColor), i_Parameters[0]);
										m_NumberOfDoors = int.Parse(i_Parameters[1]);
				}
				public override Dictionary<string,string> CreatePropertiesDictionary(string[] i_Properties)
				{
								Dictionary<string,string> keyValuePairs = base.CreatePropertiesDictionary(i_Properties);

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


				}
}
