using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class ValueRangeException : Exception
	{
		public float MinValue { get; }
		public float MaxValue { get; }
		public float ActualValue { get; }

		public ValueRangeException(float i_MinValue, float i_MaxValue, float i_ActualValue)
			: base($"Value {i_ActualValue} not in range [{i_MinValue}..{i_MaxValue}]")
		{
			MinValue = i_MinValue;
			MaxValue = i_MaxValue;
			ActualValue = i_ActualValue;
		}

		public ValueRangeException() { }
	}
}
