using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
				public class Car : Vehicle
				{
				 public Enums.CarColor Color { get; set; }
				 public int NumberOfDoors { get; set; }

					protected Engine Engine { get; }

				}
}
