using System;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public override float CurrentEnergy { get; protected set; }
        public override float MaxCapacity { get; protected set; }

        public ElectricEngine(float maxCapacity)
        {
            MaxCapacity = maxCapacity;
            CurrentEnergy = 0f;
        }

        public override void AddEnergy(float i_Quantity)
        {
            if (i_Quantity < 0 || CurrentEnergy + i_Quantity > MaxCapacity)
            {
                throw new ArgumentOutOfRangeException("Charge amount exceeds capacity");
            }

            CurrentEnergy += i_Quantity;
        }
    }
}
