using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
				public class ValueRangeException : Exception
				{
								float m_MaxValue;
								float m_MinValue;
								float m_ActualValue;

								public ValueRangeException(float i_MinValue, float i_MaxValue, float i_ActualValue) : base($"Value {i_ActualValue} not in range [{i_MinValue}..{i_MaxValue}]")
								{
												m_MinValue = i_MinValue;
												m_MaxValue = i_MaxValue;
												m_ActualValue = i_ActualValue;
								}


				}
}
