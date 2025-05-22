using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
	public class Car : Vehicle
	{
		private const int k_NumberOfWheels = 5;
		public CarColor m_Color { get; set; }
		public int m_NumberOfDoors { get; set; }


		public Car(string i_Model, string i_LisenceNumber, Engine i_Engine) : base(i_Model, i_LisenceNumber, i_Engine)
		{
			m_Wheels = new List<Wheel>(k_NumberOfWheels);
		}


		public override void AddRestProperties(List<string> i_Parameters)
		{
			if (i_Parameters.Count < 2)
			{
				throw new ArgumentException("Not enough parameters to initialize Car properties.");
			}
			m_Color = (CarColor)Enum.Parse(typeof(CarColor), i_Parameters[0]);
			m_NumberOfDoors = int.Parse(i_Parameters[1]);
		}
		public override Dictionary<string, string> CreatePropertiesDictionary(string[] i_Headers, string[] i_Properties)
		{
			Dictionary<string, string> keyValuePairs = base.CreatePropertiesDictionary(i_Headers, i_Properties);

			keyValuePairs.Add("CarColor", i_Properties[8]);
			keyValuePairs.Add("NumberOfDoors", i_Properties[9]);

			return keyValuePairs;
		}
		public override void UpdateVehicleProperties(Dictionary<string, string> i_Properties)
		{
			base.UpdateVehicleProperties(i_Properties);
			m_Color = (CarColor)Enum.Parse(typeof(CarColor), i_Properties["CarColor"]);
			m_NumberOfDoors = int.Parse(i_Properties["NumberOfDoors"]);
		}


        public override string ToString()
        {
            return $"{base.ToString()}\nCar Specifics:\n  Color: {m_Color}\n  Number of Doors: {m_NumberOfDoors}";
        }
	}
}
