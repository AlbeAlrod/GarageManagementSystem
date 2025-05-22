using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;


namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		protected readonly string m_Model;
		protected readonly string m_LicenseNumber;
		protected float m_EnergyPrecent { get; set; }
		protected VehicleStatus m_VehicleStatus { get; set; }
		protected Engine m_Engine { get; set; }
		protected List<Wheel> m_Wheels; //Collection of wheels
		protected ContactInfo m_ContactInfo;
		public abstract void AddRestProperties(List<string> i_RestProperties);

		public virtual void AddDetails(float i_EnergyPrecent, string i_WheelModel, float i_CurrentAirPressure, List<Wheel> i_ListOfWheels, string i_OwnerName, string i_OwnerNumber, List<string> i_RestProperties)
		{
			m_EnergyPrecent = i_EnergyPrecent;
			//CreateListOfWheels(i_WheelModel, i_CurrentAirPressure);
			m_ContactInfo = new ContactInfo(i_OwnerName, i_OwnerNumber);
			m_Wheels = i_ListOfWheels;
			AddRestProperties(i_RestProperties);
		}
		public virtual Dictionary<string, string> CreatePropertiesDictionary(string[] i_Headers, string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
			for (int i = 0; i < i_Headers.Length; i++)
			{
				keyValuePairs[i_Headers[i]] = i_Properties[i];
			}
			return keyValuePairs;
		}
		public virtual void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			m_EnergyPrecent = float.Parse(i_Properties["EnergyPercentage"]);
			foreach (Wheel wheel in m_Wheels)
			{
				wheel.UpdateTiersModel(i_Properties["TierModel"]);
				wheel.UpdateTiersAirPressure(float.Parse(i_Properties["CurrAirPressure"]));
			}
			m_ContactInfo = new ContactInfo(i_Properties["OwnerName"], i_Properties["OwnerNamePhone"]);
		}





		public void SetEnergyPrecent(float i_EnergyPrecent)
		{
			m_EnergyPrecent = i_EnergyPrecent;
		}

		public void SetContactInfo(ContactInfo i_contactInfo)
		{
			m_ContactInfo = i_contactInfo;
		}

		public void SetVehicleStatus(VehicleStatus i_VehicleStatus)
		{
			m_VehicleStatus = i_VehicleStatus;
		}
		public string GetLisenceNumber()
		{
			return m_LicenseNumber;
		}


		public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
		{
			m_Model = i_Model;
			m_LicenseNumber = i_LicenseNumber;
			m_Engine = i_Engine;
		}
	}
}
