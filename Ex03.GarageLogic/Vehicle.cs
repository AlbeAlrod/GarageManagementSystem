using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string m_Model;
        private readonly string m_LicenseNumber;
        protected int m_NumberOfWheels { get; }
        protected float m_EnergyPercent { get; set; }
        protected Engine m_Engine { get; set; }
        protected List<Wheel> m_Wheels;

        public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine, int i_NumberOfWheels)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_NumberOfWheels = i_NumberOfWheels;
            m_Wheels = new List<Wheel>(i_NumberOfWheels);
        }

        public string LicenseNumber => m_LicenseNumber;
        public string Model => m_Model;

        public virtual Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                { "VehicleType", i_Properties[0] },
                { "LicensePlate", i_Properties[1] },
                { "ModelName", i_Properties[2] },
                { "EnergyPercentage", i_Properties[3] },
                { "TierModel", i_Properties[4] },
                { "CurrAirPressure", i_Properties[5] },
                { "OwnerName", i_Properties[6] },
                { "OwnerPhoneNumber", i_Properties[7] }
            };
            return keyValuePairs;
        }

        public virtual void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
        {
            m_EnergyPercent = float.Parse(i_Properties["EnergyPercentage"]);

            TireModel tireModel = TireModel.Michelin; // אפשר להחליף לפי ערך מתאים מהקלט
            float airPressure = float.Parse(i_Properties["CurrAirPressure"]);

            if (m_Wheels.Count == 0)
            {
                for (int i = 0; i < m_NumberOfWheels; i++)
                {
                    float maxAirPressure = TireMaxAirPressure.GetMaxAirPressure(tireModel);
                    Wheel newWheel = new Wheel(maxAirPressure);
                    m_Wheels.Add(newWheel);
                }
            }

            foreach (Wheel wheel in m_Wheels)
            {
                wheel.UpdateTiersModel(tireModel);
                wheel.UpdateTiersAirPressure(airPressure);
            }
        }

        public virtual Dictionary<string, string> CreateParametersDictForUser()
        {
            Dictionary<string, string> parametersForUser = new Dictionary<string, string>
            {
                { "EnergyPercentage", "Enter energy percentage:" },
                { "CurrAirPressure", "Enter current air pressure (PSI):" }
            };

            return parametersForUser;
        }

        public void SetEnergyPercent(float i_EnergyPercent)
        {
            m_EnergyPercent = i_EnergyPercent;
        }

        public Engine Engine => m_Engine;

        public List<Wheel> Wheels => m_Wheels;

        public virtual string GetDetails()
        {
            StringBuilder detailsBuilder = new StringBuilder();
            detailsBuilder.AppendLine($"License number: {LicenseNumber}");
            detailsBuilder.AppendLine($"Model: {Model}");
            detailsBuilder.AppendLine($"Energy percent: {m_EnergyPercent}%");
            detailsBuilder.AppendLine($"Wheels count: {m_NumberOfWheels}");
            detailsBuilder.AppendLine("Wheels details:");
            foreach (Wheel wheel in m_Wheels)
            {
                detailsBuilder.AppendLine($"\tManufacturer: {wheel.ManufacturerName}, Air pressure: {wheel.CurrentAirPressure} / {wheel.MaxAirPressure}");
            }
            detailsBuilder.AppendLine($"Engine type: {m_Engine.GetType().Name}");
            detailsBuilder.AppendLine($"Current energy: {m_Engine.CurrentEnergy}");
            detailsBuilder.AppendLine($"Max capacity: {m_Engine.MaxCapacity}");
            return detailsBuilder.ToString();
        }
    }

    public static class TireMaxAirPressure
    {
        private static readonly Dictionary<TireModel, float> s_TireMaxAirPressure = new Dictionary<TireModel, float>()
        {
            { TireModel.Michelin, 32f },
            { TireModel.Goodyear, 30f },
            { TireModel.Continental, 31f },
            { TireModel.Pirelli, 33f },
            { TireModel.Bridgestone, 34f },
        };

        public static float GetMaxAirPressure(TireModel i_TireModel)
        {
            if (s_TireMaxAirPressure.TryGetValue(i_TireModel, out float maxPressure))
            {
                return maxPressure;
            }

            throw new ArgumentException("Unknown tire model: " + i_TireModel);
        }
    }
}