using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public FuelType FuelType { get; }

        public override float CurrentEnergy { get; protected set; }
        public override float MaxCapacity { get; protected set; }

        public FuelEngine(FuelType i_FuelType, float i_MaxCapacity)
        {
            FuelType = i_FuelType;
            MaxCapacity = i_MaxCapacity;
            CurrentEnergy = 0f;
        }

        public override void AddEnergy(float i_AmountToAdd)
        {
            if (i_AmountToAdd < 0 || CurrentEnergy + i_AmountToAdd > MaxCapacity)
            {
                throw new ArgumentOutOfRangeException(nameof(i_AmountToAdd), "Fuel amount exceeds capacity");
            }

            CurrentEnergy += i_AmountToAdd;
        }
    }
}
