using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
	public abstract class Engine
	{
		protected float m_CurrentEnergy { get; set; }
		protected float m_MaxCapacityOfEnergy { get; set; }

		public virtual void AddEnergy(float i_Amount)
		{
			throw new NotImplementedException("This method must be overridden by electric engines.");
		}

		public virtual void AddEnergy(float i_Amount, FuelType i_FuelType)
		{
			throw new NotImplementedException("This method must be overridden by fuel engines.");
		}
	}
}
