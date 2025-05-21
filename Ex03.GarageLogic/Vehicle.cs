using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;


namespace Ex03.GarageLogic
{
				public abstract class Vehicle
				{
								protected readonly string m_Model;
								protected readonly string m_LisenceNumber;
								protected float m_EnergyPrecent { get; set; }
								protected VehicleStatus m_VehicleStatus { get; set; }
								protected Engine m_Engine { get; set; }
								private List<Wheel> m_Wheels; //Collection of wheels
								private ContactInfo m_ContactInfo;
								public abstract void AddRestProperties(Dictionary<string, string> i_RestProperties);

								public virtual void AddDetails(float i_EnergyPrecent,string i_WheelModel, float i_CurrentAirPressure,List<Wheel> i_ListOfWheels, string i_OwnerName, string i_OwnerNumber, Dictionary<string, string> i_RestProperties)
								{
												m_EnergyPrecent = i_EnergyPrecent;
												//CreateListOfWheels(i_WheelModel, i_CurrentAirPressure);
												m_ContactInfo = new ContactInfo(i_OwnerName, i_OwnerNumber);
												m_Wheels = i_ListOfWheels;
												AddRestProperties(i_RestProperties);
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
												return m_LisenceNumber;
								}


								public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
								{
								m_Model = i_Model;
								m_LisenceNumber = i_LicenseNumber;	
								m_Engine = i_Engine;
								}
				}
}
