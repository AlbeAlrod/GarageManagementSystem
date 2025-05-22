using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
	public class ElectricEngine : Engine
	{
		public const float k_DefaultMaxCapacity = 2.1f;

		public ElectricEngine(float i_MaxCapacity = k_DefaultMaxCapacity)
		{
			m_MaxCapacityOfEnergy = i_MaxCapacity;
			m_CurrentEnergy = 0;
		}

		public override void AddEnergy(float i_Amount)
		{
			if (i_Amount < 0)
			{
				throw new ArgumentException("Amount of energy must be non-negative.");
			}

			if (m_CurrentEnergy + i_Amount > m_MaxCapacityOfEnergy)
			{
				throw new ValueRangeException(0, m_MaxCapacityOfEnergy - m_CurrentEnergy, i_Amount);
			}

			m_CurrentEnergy += i_Amount;
		}
	}
}
