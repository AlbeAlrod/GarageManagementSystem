using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;


namespace Ex03.GarageLogic
{
				public abstract class Vehicle
				{
								private readonly string m_Model;
								private readonly string m_LisenceNumber;
								private int m_NumberOfWheels { get; }
								private int m_MaxAirPressure{ get; }			
								protected float m_EnergyPrecent { get; set; }
								protected VehicleStatus m_VehicleStatus { get; set; }
								protected Engine m_Engine { get; set; }
								protected List<Wheel> m_Wheels; 
								protected ContactInfo m_ContactInfo;

								public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine, int i_NumberOfWheels)
								{
												m_Model = i_Model;
												m_LisenceNumber = i_LicenseNumber;
												m_Engine = i_Engine;
												m_Wheels = new List<Wheel>();
												m_NumberOfWheels = i_NumberOfWheels;
								}
								public string LicenseNumber
								{
												get { return m_LisenceNumber; }
								}

					
								public virtual Dictionary<string,string> CreatePropertiesDictionaryFromLine(string[] i_Properties)
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
													 { "OwnerNamePhone", i_Properties[7] }
												};
													return keyValuePairs;	
									}
									public virtual void UpdateVehicleProperties(Dictionary<string,string> i_Properties)
									{
												m_EnergyPrecent = float.Parse(i_Properties["EnergyPercentage"]);
												foreach (Wheel  wheel in m_Wheels)
												{ 
												wheel.UpdateTiersModel(i_Properties["TierModel"]);
												wheel.UpdateTiersAirPressure(float.Parse(i_Properties["CurrAirPressure"]));
												}
												m_ContactInfo = new ContactInfo(i_Properties["OwnerName"], i_Properties["OwnerNamePhone"]);
									}

									public virtual Dictionary<string,string> CreateParametersDictForUser()
									{
												Dictionary<string, string> paramDict = new Dictionary<string, string>();
												paramDict.Add("VehicleType", "Enter vehicle type:");
												paramDict.Add("LicensePlate", "Enter license plate number:");
												paramDict.Add("ModelName", "Enter model name:");
												paramDict.Add("EnergyPercentage", "Enter energy precentage:");
												paramDict.Add("TierModel", "Enter tier model:");
												paramDict.Add("CurrAirPressure", "Enter current air pressure:");
												paramDict.Add("OwnerName", "Enter owner name:");
												paramDict.Add("OwnerNamePhone", "Enter owner name phone");

												return paramDict;
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


							
				}
}
