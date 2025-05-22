using System;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergy { get; set; }
        protected float m_MaxCapacityOfEnergy { get; set; }

        // חייבים לממש
        public abstract void AddEnergy(float i_Amount);

        // רק למנועי דלק - מימוש אופציונלי, ברירת מחדל זורק חריגה
        public virtual void AddEnergy(float i_Amount, FuelType i_FuelType)
        {
            throw new NotImplementedException("This method must be overridden by fuel engines.");
        }

        public float CurrentEnergy => m_CurrentEnergy;
        public float MaxCapacityOfEnergy => m_MaxCapacityOfEnergy;

        public override string ToString()
        {
            return $"Current Energy: {m_CurrentEnergy}, Max Capacity: {m_MaxCapacityOfEnergy}";
        }
    }
}