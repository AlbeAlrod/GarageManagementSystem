using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;


namespace Ex03.GarageLogic
{
				public abstract class Vehicle
				{
								protected readonly string m_Model;
								protected readonly string m_LisenceNumber;
								protected float m_EnergyPrecent ;
								private VehicleStatus m_VehicleStatus{  get; set; }
								protected Engine m_Engine;

								private List<Wheel> m_Wheels;//Collection of wheels
								internal VehicleStatus VehicleStatus;

								public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
								{
								m_Model = i_Model;
								m_LisenceNumber = i_LicenseNumber;	
								m_Engine = i_Engine;
								}
				}
}
