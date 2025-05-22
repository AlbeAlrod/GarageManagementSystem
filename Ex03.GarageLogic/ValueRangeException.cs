using System;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }
        public float ActualValue { get; }

        public ValueRangeException(float i_Min, float i_Max, float i_Actual)
            : base($"Value {i_Actual} not in range [{i_Min}..{i_Max}].")
        {
            MinValue = i_Min;
            MaxValue = i_Max;
            ActualValue = i_Actual;
        }
    }
}