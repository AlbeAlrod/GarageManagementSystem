namespace Ex03.GarageLogic
{
    public enum CarColor
    {
        Yellow,
        Black,
        White,
        Silver,
        Red,
        Blue
    }

    public enum MotorcycleLicenseType
    {
        A,
        A1,
        A2,
        B1,
        B2,
        AB
    }

    public enum FuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,

    }

    public enum VehicleStatus
    {
        InRepair,
        Ready,
        Paid
    }

    public enum MenuChoice
    {
        LoadVehicles = 1,
        AddNewVehicle,
        ShowAllVehicles,
        UpdateVehicleStatus,
        RefuelVehicle,
        RechargeVehicle,
        InflateVehicleWheels,
        ShowVehicleDetails,
        Exit
    }
    public enum SupportedTypes
				{
     FuelCar = 1,
     ElectricCar,
     FuelMotorcycle,
     ElectricMotorcycle,
     Truck
    }
}