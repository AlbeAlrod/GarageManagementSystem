using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		protected readonly string m_Model;
		protected readonly string m_LicenseNumber;
		public float EnergyPrecent { get; protected set; }
		public VehicleStatus VehicleStatus { get; protected set; }
		protected Engine m_Engine { get; set; }
		protected List<Wheel> m_Wheels; // Collection of wheels
		protected ContactInfo m_ContactInfo;

		// אירועים לשינויים חשובים (אופציונלי)
		public event Action<VehicleStatus> VehicleStatusChanged;
		public event Action<float> EnergyPercentageChanged;

		public abstract void AddRestProperties(List<string> i_RestProperties);

		public virtual void AddDetails(float i_EnergyPrecent, string i_WheelModel, float i_CurrentAirPressure,
									   List<Wheel> i_ListOfWheels, string i_OwnerName, string i_OwnerNumber, List<string> i_RestProperties)
		{
			EnergyPrecent = i_EnergyPrecent;
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
			EnergyPrecent = float.Parse(i_Properties["EnergyPercentage"]);
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

		protected void SetEnergyPrecent(float i_EnergyPrecent)
		{
			if (i_EnergyPrecent < 0 || i_EnergyPrecent > 100)
			{
				throw new ArgumentOutOfRangeException(nameof(i_EnergyPrecent), "Energy percent must be between 0 and 100.");
			}
			EnergyPrecent = i_EnergyPrecent;
			EnergyPercentageChanged?.Invoke(EnergyPrecent);
		}

		protected void SetVehicleStatus(VehicleStatus i_VehicleStatus)
		{
			// אפשר להוסיף כאן בדיקות אם רוצים
			VehicleStatus = i_VehicleStatus;
			VehicleStatusChanged?.Invoke(VehicleStatus);
		}

		public void UpdateVehicleStatus(VehicleStatus i_NewStatus)
		{
			if (VehicleStatus == VehicleStatus.InRepair && i_NewStatus == VehicleStatus.Paid)
			{
				throw new InvalidOperationException("Cannot change status directly from InRepair to Paid. Must be Ready first.");
			}
			// בדיקות נוספות אפשריות

			SetVehicleStatus(i_NewStatus);
		}

		public string GetLicenseNumber()
		{
			return m_LicenseNumber;
		}

		public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
		{
			m_Model = i_Model;
			m_LicenseNumber = i_LicenseNumber;
			m_Engine = i_Engine;
			VehicleStatus = VehicleStatus.InRepair; // סטטוס התחלתי
		}

		// מתודה ליצירת גלגלים
		public void CreateWheels(int i_NumberOfWheels, string i_ManufacturerName,
								 float i_CurrentAirPressure, float i_MaxAirPressure)
		{
			m_Wheels = Wheel.CreateListOfWheels(i_NumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
		}

		// מתודה לניפוח גלגל בודד לפי אינדקס
		public void InflateWheelToMax(int i_WheelIndex)
		{
			if (m_Wheels == null || i_WheelIndex < 0 || i_WheelIndex >= m_Wheels.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(i_WheelIndex), "Invalid wheel index or wheels not initialized.");
			}
			m_Wheels[i_WheelIndex].InflateToMax();
		}

		// מתודה לניפוח כל הגלגלים בבת אחת
		public void InflateAllWheelsToMax()
		{
			if (m_Wheels == null)
			{
				throw new InvalidOperationException("Wheels not initialized.");
			}

			foreach (Wheel wheel in m_Wheels)
			{
				wheel.InflateToMax();
			}
		}

		// טעינת דלק (רק למנוע דלק)
		public void Refuel(float i_Amount, FuelType i_FuelType)
		{
			if (m_Engine is FuelEngine fuelEngine)
			{
				fuelEngine.AddEnergy(i_Amount, i_FuelType);
				SetEnergyPrecent(GetEnergyPercentage());
			}
			else
			{
				throw new InvalidOperationException("This vehicle does not have a fuel engine.");
			}
		}

		// טעינת סוללה (רק למנוע חשמלי)
		public void Recharge(float i_Amount)
		{
			if (m_Engine is ElectricEngine electricEngine)
			{
				electricEngine.AddEnergy(i_Amount);
				SetEnergyPrecent(GetEnergyPercentage());
			}
			else
			{
				throw new InvalidOperationException("This vehicle does not have an electric engine.");
			}
		}
		public List<Wheel> Wheels
		{
			get { return m_Wheels; }
		}
	}
}