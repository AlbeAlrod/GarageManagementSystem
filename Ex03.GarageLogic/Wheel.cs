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

		public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
		{
			if (i_CurrentAirPressure > i_MaxAirPressure || i_CurrentAirPressure < 0)
			{
				throw new ValueRangeException(0, i_MaxAirPressure, i_CurrentAirPressure);
			}

			m_ManufacturerName = i_ManufacturerName;
			m_CurrentAirPressure = i_CurrentAirPressure;
			m_MaxAirPressure = i_MaxAirPressure;
		}

		// הוספת אוויר עד למקסימום, עם בדיקות תקינות
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

		// מנפח את כל הגלגל עד למקסימום
		public void InflateToMax()
		{
			m_CurrentAirPressure = m_MaxAirPressure;
		}

		// עדכון דגם היצרן של הגלגל
		public void UpdateTiersModel(string i_ManufacturerName)
		{
			m_ManufacturerName = i_ManufacturerName;
		}

		// עדכון לחץ האוויר הנוכחי
		public void UpdateTiersAirPressure(float i_AmountOfAirPressure)
		{
			if (i_AmountOfAirPressure < 0 || i_AmountOfAirPressure > m_MaxAirPressure)
			{
				throw new ValueRangeException(0, m_MaxAirPressure, i_AmountOfAirPressure);
			}
			m_CurrentAirPressure = i_AmountOfAirPressure;
		}

		// עדכון לחץ האוויר המקסימלי (אם נדרש)
		public void UpdateMaxAirPressure(float i_MaxAirPressure)
		{
			if (i_MaxAirPressure < m_CurrentAirPressure)
			{
				throw new ArgumentException("Max air pressure cannot be less than current air pressure");
			}
			m_MaxAirPressure = i_MaxAirPressure;
		}

		public override string ToString()
		{
			return $"Manufacturer: {m_ManufacturerName}, Current Pressure: {m_CurrentAirPressure}, Max Pressure: {m_MaxAirPressure}";
		}

		// יצירת רשימת גלגלים באותו דגם, לחץ נוכחי ולחץ מקסימלי
		public static List<Wheel> CreateListOfWheels(int numberOfWheels, string manufacturerName, float currentAirPressure, float maxAirPressure)
		{
			List<Wheel> wheels = new List<Wheel>();

			for (int wheelIndex = 0; wheelIndex < numberOfWheels; wheelIndex++)
			{
				wheels.Add(new Wheel(manufacturerName, currentAirPressure, maxAirPressure));
			}

			return wheels;
		}
	}
}