using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public override float CurrentEnergy { get; protected set; }
        public override float MaxCapacity { get; protected set; }

        public ElectricEngine(float i_MaxCapacity)
        {
            MaxCapacity = i_MaxCapacity;
            CurrentEnergy = 0f;
        }

        public override void AddEnergy(float i_AmountToAdd)
        {
            if (i_AmountToAdd < 0 || CurrentEnergy + i_AmountToAdd > MaxCapacity)
            {
                throw new ArgumentOutOfRangeException(nameof(i_AmountToAdd), "Charge amount exceeds capacity");
            }

            CurrentEnergy += i_AmountToAdd;
        }
    }
}
