using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
				public abstract class Engine
				{
								public float m_CurrentEnergy { get; }
								public float m_MaxCapacityOfEnergy {  get; }



								public abstract void AddEnergy();



				}
}
