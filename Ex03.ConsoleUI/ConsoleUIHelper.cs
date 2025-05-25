using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
				public class ConsoleUIHelper
				{
								public void PrintMenu()
								{
												Console.WriteLine("=== Garage Management System ===");
												Console.WriteLine("1. Load vehicles from file");
												Console.WriteLine("2. Add New Vehicle");
												Console.WriteLine("3. Show All Vehicles");
												Console.WriteLine("4. Update Vehicle Status");
												Console.WriteLine("5. Refuel Vehicle");
												Console.WriteLine("6. Recharge Vehicle");
												Console.WriteLine("7. Inflate Vehicle Wheels");
												Console.WriteLine("8. Show Vehicle details");
												Console.WriteLine("9. Exit");
												Console.Write("Please select an option (1-9): ");
								}
								public string ReadValidOption()
								{
												while (true)
												{
																string input = Console.ReadLine();
																if (!string.IsNullOrEmpty(input) && input.Length == 1 && "1234567".Contains(input))
																{
																				return input;
																}
																Console.Write("Invalid input. Please enter a number between 1 and 7: ");
												}
								}

				}
}
