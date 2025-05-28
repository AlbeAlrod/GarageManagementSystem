using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
		private string m_ManufacturerName;
		private float m_CurrentAirPressure;
		private float m_MaxAirPressure;

		public void AddAir(float i_AmountOfAirToAdd)
		{
			if (i_AmountOfAirToAdd < 0)
			{
				throw new ArgumentException("Amount to add must be non-negative");
			}

			float newAirPressure = m_CurrentAirPressure + i_AmountOfAirToAdd;

			if (newAirPressure > m_MaxAirPressure)
			{
				throw new ValueRangeException(0, m_MaxAirPressure - m_CurrentAirPressure, i_AmountOfAirToAdd);
			}

			m_CurrentAirPressure = newAirPressure;
		}

		public void UpdateTiersModel(string i_ManufacturerName)
		{
			m_ManufacturerName = i_ManufacturerName;
		}

		public void UpdateTiersAirPressure(float i_AmountOfAirPressure)
		{
			m_CurrentAirPressure = i_AmountOfAirPressure;
		}

		public void InflateToMax()
		{
			m_CurrentAirPressure = m_MaxAirPressure;
		}

		public float CurrentAirPressure
		{
			get { return m_CurrentAirPressure; }
		}

		public float MaxAirPressure
		{
			get { return m_MaxAirPressure; }
		}

		public string ManufacturerName
		{
			get { return m_ManufacturerName; }
		}
	}
}