using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
				public class ElectricCar : Car
				{			
								public ElectricCar(string i_Model, string i_LisenceNumber) : base(i_Model, i_LisenceNumber, new ElectricEngine())
								{
								}

								
				}
}
