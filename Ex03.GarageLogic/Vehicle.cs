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
		protected List<Wheel> m_Wheels; // Collection of wheels
		protected ContactInfo m_ContactInfo;

		public abstract void AddRestProperties(List<string> i_RestProperties);

		public virtual void AddDetails(float i_EnergyPrecent, string i_WheelModel, float i_CurrentAirPressure,
									   List<Wheel> i_ListOfWheels, string i_OwnerName, string i_OwnerNumber, List<string> i_RestProperties)
		{
			m_EnergyPrecent = i_EnergyPrecent;
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

		public float GetEnergyPercentage()
		{
			if (m_Engine == null)
			{
				return 0f;
			}
			return (m_Engine.CurrentEnergy / m_Engine.MaxCapacityOfEnergy) * 100f;
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

		public void UpdateVehicleStatus(VehicleStatus i_NewStatus)
		{
			if (m_VehicleStatus == VehicleStatus.InRepair && i_NewStatus == VehicleStatus.Paid)
			{
				throw new InvalidOperationException("Cannot change status directly from InRepair to Paid. Must be Ready first.");
			}
			// הוספת בדיקות לוגיות נוספות אפשרית כאן

			m_VehicleStatus = i_NewStatus;
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
			m_VehicleStatus = VehicleStatus.InRepair; // סטטוס התחלתי
		}

		// מתודה ליצירת גלגלים
		public void CreateWheels(int i_NumberOfWheels, string i_ManufacturerName,
								 float i_CurrentAirPressure, float i_MaxAirPressure)
		{
			m_Wheels = Wheel.CreateListOfWheels(i_NumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
		}

		public override string ToString()
		{
			string wheelsInfo = m_Wheels != null ? string.Join(", ", m_Wheels) : "N/A";
			string contactInfo = m_ContactInfo != null ? m_ContactInfo.ToString() : "N/A";
			string engineInfo = m_Engine != null ? m_Engine.ToString() : "N/A";

			return string.Format(
				"Model: {0}\nLicense Number: {1}\nEnergy Percentage: {2}%\nVehicle Status: {3}\nContact Info: {4}\nEngine: {5}\nWheels: [{6}]",
				m_Model,
				m_LicenseNumber,
				m_EnergyPrecent,
				m_VehicleStatus,
				contactInfo,
				engineInfo,
				wheelsInfo
			);
		}

		public List<Wheel> Wheels
		{
			get { return m_Wheels; }
		}
		
		public VehicleStatus VehicleStatus
		{
			get { return m_VehicleStatus; }
		}
	}
}