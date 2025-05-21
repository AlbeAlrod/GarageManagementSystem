using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
				public class Program
				{
				 public static void Main()
					{
					VehicleManagment Garage = new VehicleManagment();
												string filePath = "C:\\Users\\Guy\\source\\repos\\Ex03-Garage\\Vehicles.txt";
												Garage.LoadVehiclesFromFile(filePath);		
											//	Garage.PrintAllVehicles();
					}
				}
}
