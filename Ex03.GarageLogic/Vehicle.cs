using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string m_Model;
        protected readonly string m_LicenseNumber;
        protected VehicleStatus m_VehicleStatus { get; set; }
        protected Engine m_Engine { get; set; }
        protected List<Wheel> m_Wheels;
        protected ContactInfo m_ContactInfo;
        private int m_NumberOfWheels { get; }

        public Engine Engine => m_Engine;
        public float EnergyPercentage => (m_Engine.CurrentEnergy / m_Engine.MaxCapacity) * 100f;

        public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine, int i_NumberOfWheels)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_VehicleStatus = VehicleStatus.InRepair;
            m_Wheels = new List<Wheel>(i_NumberOfWheels);
            m_NumberOfWheels = i_NumberOfWheels;
        }

        public string LicenseNumber => m_LicenseNumber;

        public abstract void AddRestProperties(List<string> i_RestProperties);

        public virtual void AddDetails(string i_WheelModel, float i_CurrentAirPressure, List<Wheel> i_ListOfWheels, string i_OwnerName, string i_OwnerNumber, List<string> i_RestProperties)
        {
            m_ContactInfo = new ContactInfo(i_OwnerName, i_OwnerNumber);
            m_Wheels = i_ListOfWheels;
            AddRestProperties(i_RestProperties);
        }

        public virtual Dictionary<string, string> CreatePropertiesDictionary(string[] i_Properties)
        {
            return new Dictionary<string, string>
            {
                { "VehicleType", i_Properties[0] },
                { "LicensePlate", i_Properties[1] },
                { "ModelName", i_Properties[2] },
                { "EnergyPercentage", i_Properties[3] },
                { "TierModel", i_Properties[4] },
                { "CurrAirPressure", i_Properties[5] },
                { "OwnerName", i_Properties[6] },
                { "OwnerNamePhone", i_Properties[7] }
            };
        }

        public virtual void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.UpdateTiersModel(i_Properties["TierModel"]);
                wheel.UpdateTiersAirPressure(float.Parse(i_Properties["CurrAirPressure"]));
            }
            m_ContactInfo = new ContactInfo(i_Properties["OwnerName"], i_Properties["OwnerNamePhone"]);
        }

        public virtual Dictionary<string, string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
        {
            return new Dictionary<string, string>
            {
                { "VehicleType", i_Properties[0] },
                { "LicensePlate", i_Properties[1] },
                { "ModelName", i_Properties[2] },
                { "EnergyPercentage", i_Properties[3] },
                { "TierModel", i_Properties[4] },
                { "CurrAirPressure", i_Properties[5] },
                { "OwnerName", i_Properties[6] },
                { "OwnerNamePhone", i_Properties[7] }
            };
        }

        public virtual Dictionary<string, string> CreateParametersDictForUser()
        {
            return new Dictionary<string, string>
            {
                { "VehicleType", "Enter vehicle type:" },
                { "LicensePlate", "Enter license plate number:" },
                { "ModelName", "Enter model name:" },
                { "EnergyPercentage", "Enter energy percentage:" },
                { "TierModel", "Enter tier model:" },
                { "CurrAirPressure", "Enter current air pressure:" },
                { "OwnerName", "Enter owner name:" },
                { "OwnerNamePhone", "Enter owner phone number:" }
            };
        }

        public void SetContactInfo(ContactInfo i_contactInfo) => m_ContactInfo = i_contactInfo;

        public void SetVehicleStatus(VehicleStatus i_VehicleStatus) => m_VehicleStatus = i_VehicleStatus;

        public string GetLisenceNumber() => m_LicenseNumber;
    }
}