using System;

namespace Ex03.GarageLogic
{
	public abstract class Engine
	{
		public abstract float CurrentEnergy { get; protected set; }
		public abstract float MaxCapacity { get; protected set; }

		public abstract void AddEnergy(float i_AmountToAdd);
	}
}
