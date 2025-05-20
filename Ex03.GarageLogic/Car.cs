using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
				public class Car : Vehicle
				{
				 public Enums.CarColor m_Color { get; set; }
				 public int m_NumberOfDoors { get; set; }

					protected Engine  m_Engine { get; set; }

					public Car (string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine)
					{
								
					}

				}
}
