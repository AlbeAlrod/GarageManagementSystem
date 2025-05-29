using System;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class InputValidator
    {
        public static MenuChoice GetValidMenuChoice()
        {
            int numOfChoices = Enum.GetValues(typeof(MenuChoice)).Length;

            while (true)
            {
                Console.Write($"Please choose a number between 1 and {numOfChoices}: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int userChoice) && Enum.IsDefined(typeof(MenuChoice), userChoice))
                {
                    return (MenuChoice)userChoice;
                }

                Console.WriteLine("Invalid input, please try again.");
            }
        }

        public static string GetNonEmptyString(string i_Prompt)
        {
            while (true)
            {
                Console.WriteLine(i_Prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input!;
                }

                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        public static string GetLicenseNumber()
        {
            while (true)
            {
                string licenseNumber = GetNonEmptyString("Please enter the vehicle's license number:");

                try
                {
                    ValidateLicenseNumber(licenseNumber);
                    return licenseNumber;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message} Please try again.");
                }
            }
        }

        private static void ValidateLicenseNumber(string i_LicenseNumber)
        {
            if (!int.TryParse(i_LicenseNumber, out int result) || result <= 0)
            {
                throw new ArgumentException("License number must be a positive whole number.");
            }
        }

        public static string GetVehicleModel()
        {
            Console.WriteLine("Please enter the vehicle model:");
            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Model cannot be empty. Please enter again:");
                input = Console.ReadLine();
            }

            return input;
        }

        public static string GetVehicleType()
        {
            while (true)
            {
                string input = GetNonEmptyString("Please choose which type of vehicle you would like to bring:");

                if (Enum.TryParse(input, true, out SupportedTypes chosenVehicle))
                {
                    return chosenVehicle.ToString();
                }

                Console.WriteLine("Invalid vehicle type, please try again.");
            }
        }

        public static int GetValidIntInRange(string i_Prompt, int i_Min, int i_Max)
        {
            while (true)
            {
                Console.WriteLine(i_Prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= i_Min && choice <= i_Max)
                {
                    return choice;
                }

                Console.WriteLine("Invalid choice, try again.");
            }
        }

        public static float GetPositiveFloat(string i_Prompt)
        {
            while (true)
            {
                Console.WriteLine(i_Prompt);
                string? input = Console.ReadLine();

                if (float.TryParse(input, out float value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }

        public static FuelType GetValidFuelType()
        {
            while (true)
            {
                Console.WriteLine("Enter fuel type:");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && Enum.TryParse(input, true, out FuelType fuelType))
                {
                    return fuelType;
                }

                Console.WriteLine("Invalid fuel type. Please enter a valid one.");
            }
        }

        public static string GetValidPhoneNumber()
        {
            while (true)
            {
                string input = GetNonEmptyString("Please enter owner phone number:");
                if (input.All(char.IsDigit) && (input.Length == 9 || input.Length == 10))
                {
                    return input;
                }
                Console.WriteLine("Invalid phone number. Please enter only digits (9–10 digits).");
            }
        }

        public static string GetValidName()
        {
            return GetNonEmptyString("Please enter owner name:");
        }

        public static string GetCustomerName()
        {
            return GetNonEmptyString("Please enter owner name:");
        }

        public static string GetCustomerPhoneNumber()
        {
            return GetNonEmptyString("Please enter owner phone number:");
        }

        public static TEnum GetValidEnumFromUser<TEnum>(string i_Prompt) where TEnum : struct, Enum
        {
            bool isEnumValueValid = false;
            TEnum selectedEnumValue = default;

            while (!isEnumValueValid)
            {
                Console.WriteLine($"{i_Prompt} ({string.Join("/", Enum.GetNames(typeof(TEnum)))})");
                string? userInput = Console.ReadLine()?.Trim();

                if (Enum.TryParse<TEnum>(userInput, true, out selectedEnumValue) && Enum.IsDefined(typeof(TEnum), selectedEnumValue))
                {
                    isEnumValueValid = true;
                }
                else
                {
                    Console.WriteLine("❌ Invalid value. Please try again.");
                }
            }

            return selectedEnumValue;
        }
    }
}