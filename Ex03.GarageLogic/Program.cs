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
													Garage garage = new Garage();
												string filePath = "C:\\Users\\Guy\\source\\repos\\Ex03-Garage\\Vehicles.txt";
												garage.LoadVehiclesFromFile(filePath);
												Console.WriteLine("Hello");
											//	Garage.PrintAllVehicles();
					}
				}
}
