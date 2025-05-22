using System;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergy { get; set; }
        protected float m_MaxCapacityOfEnergy { get; set; }

        public abstract void AddEnergy(float i_Amount);

        public virtual void AddEnergy(float i_Amount, FuelType i_FuelType)
        {
            throw new NotImplementedException("This method must be overridden by fuel engines.");
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
        }

        public float MaxCapacityOfEnergy
        {
            get { return m_MaxCapacityOfEnergy; }
        }

        public override string ToString()
        {
            return $"Current Energy: {m_CurrentEnergy}, Max Capacity: {m_MaxCapacityOfEnergy}";
        }
    }
}