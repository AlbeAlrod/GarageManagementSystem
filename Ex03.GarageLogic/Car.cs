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
								
					}
					public override void AddRestProperties(Dictionary<string, string> i_Parameters)
					{
										m_Color = (Enums.CarColor)Enum.Parse(typeof(Enums.CarColor), i_Parameters["Color"]);
										// המרה ישירה של מספר הדלתות
										m_NumberOfDoors = int.Parse(i_Parameters["NumberOfDoors"]);
				}

				}
}
