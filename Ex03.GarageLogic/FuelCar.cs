using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
				public class FuelCar : Car
				{
							//	public Engine m_Engine;

								public FuelCar(string i_Model, string i_LisenceNumber): base(i_Model, i_LisenceNumber, new FuelEngine())
								{

								}


				}
}
