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

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = 0f;
            m_ManufacturerName = string.Empty;
        }

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

        public void UpdateTiersModel(TireModel i_TireModel)
        {
            m_ManufacturerName = i_TireModel.ToString();
        }

        public void UpdateTiersAirPressure(float i_AmountOfAirPressure)
        {
            if (i_AmountOfAirPressure < 0 || i_AmountOfAirPressure > m_MaxAirPressure)
            {
                throw new ValueRangeException(0, m_MaxAirPressure, i_AmountOfAirPressure);
            }
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