using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public abstract class Engine
	{
		public abstract float CurrentEnergy { get; protected set; }
		public abstract float MaxCapacity { get; protected set; }

		public abstract void AddEnergy(float i_Quantity);
	}
}
