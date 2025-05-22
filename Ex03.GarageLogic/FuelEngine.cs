using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public static readonly Dictionary<FuelType, float> k_DefaultCapacities = new Dictionary<FuelType, float>
        {
            { FuelType.Octane95, 38f },
            { FuelType.Octane96, 45f },
            { FuelType.Soler, 120f }
        };

        public FuelType EngineFuelType { get; private set; }

        public FuelEngine(FuelType fuelType, float maxCapacity)
        {
            EngineFuelType = fuelType;
            m_MaxCapacityOfEnergy = maxCapacity;
            m_CurrentEnergy = 0;
        }

        // אסור להשתמש בשיטה הזו עם דלק
        public override void AddEnergy(float i_Amount)
        {
            throw new NotSupportedException("Use AddEnergy with FuelType for FuelEngine.");
        }

        // מימוש טעינת דלק עם בדיקות תקינות
        public override void AddEnergy(float i_Amount, FuelType i_FuelType)
        {
            if (i_FuelType != EngineFuelType)
            {
                throw new ArgumentException($"Incorrect fuel type. Expected: {EngineFuelType}, got: {i_FuelType}");
            }

            if (i_Amount < 0)
            {
                throw new ArgumentException("Amount of fuel must be non-negative.");
            }

            if (m_CurrentEnergy + i_Amount > m_MaxCapacityOfEnergy)
            {
                throw new ValueRangeException(0, m_MaxCapacityOfEnergy - m_CurrentEnergy, i_Amount);
            }

            m_CurrentEnergy += i_Amount;
        }

        public override string ToString()
        {
            return $"Fuel Engine | Type: {EngineFuelType}, Current: {m_CurrentEnergy}L, Max: {m_MaxCapacityOfEnergy}L";
        }
    }
}