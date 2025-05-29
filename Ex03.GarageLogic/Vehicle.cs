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
				{ "OwnerNamePhone", i_Properties[7] }
			};
			return keyValuePairs;
		}

		public virtual void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			m_EnergyPercent = float.Parse(i_Properties["EnergyPercentage"]);

			TireModel tireModel;
			tireModel = TireModel.Michelin;

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
			Dictionary<string, string> paramDict = new Dictionary<string, string>
			{
				{ "EnergyPercentage", "Enter energy percentage:" },
				{ "CurrAirPressure", "Enter current air pressure (PSI):" }
			};

			return paramDict;
		}

		public void SetEnergyPercent(float i_EnergyPercent)
		{
			m_EnergyPercent = i_EnergyPercent;
		}

		public Engine Engine => m_Engine;

		public List<Wheel> Wheels => m_Wheels;

		public virtual string GetDetails()
		{
			StringBuilder details = new StringBuilder();
			details.AppendLine($"License number: {LicenseNumber}");
			details.AppendLine($"Model: {Model}");
			details.AppendLine($"Energy percent: {m_EnergyPercent}%");
			details.AppendLine($"Wheels count: {m_NumberOfWheels}");
			details.AppendLine("Wheels details:");
			foreach (var wheel in m_Wheels)
			{
				details.AppendLine($"\tManufacturer: {wheel.ManufacturerName}, Air pressure: {wheel.CurrentAirPressure} / {wheel.MaxAirPressure}");
			}
			details.AppendLine($"Engine type: {m_Engine.GetType().Name}");
			details.AppendLine($"Current energy: {m_Engine.CurrentEnergy}");
			details.AppendLine($"Max capacity: {m_Engine.MaxCapacity}");
			return details.ToString();
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

		public static float GetMaxAirPressure(TireModel tireModel)
		{
			if (s_TireMaxAirPressure.TryGetValue(tireModel, out float maxPressure))
			{
				return maxPressure;
			}

			throw new ArgumentException("Unknown tire model: " + tireModel);
		}
	}
}