using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class FuelEngine : Engine
	{
		public FuelType FuelType { get; }

		public override float CurrentEnergy { get; protected set; }
		public override float MaxCapacity { get; protected set; }

		public FuelEngine(FuelType fuelType, float maxCapacity)
		{
			FuelType = fuelType;
			MaxCapacity = maxCapacity;
			CurrentEnergy = 0f;
		}

		public override void AddEnergy(float i_Quantity)
		{
			if (i_Quantity < 0 || CurrentEnergy + i_Quantity > MaxCapacity)
			{
				throw new ArgumentOutOfRangeException("Fuel amount exceeds capacity");
			}

			CurrentEnergy += i_Quantity;
		}


	}
}
