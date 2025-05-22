using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
	public class GarageApp
	{
		public static void Main()
		{
			VehicleManagment garage = new VehicleManagment();
			string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Vehicles.txt");
			garage.LoadVehiclesFromFile(filePath);
			//	garage.PrintAllVehicles();
		}
	}
}
