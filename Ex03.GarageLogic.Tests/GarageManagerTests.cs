using NUnit.Framework;
using System;
using System.Linq;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Tests
{
    [TestFixture]
    public class GarageManagerTests
    {
        private GarageManager garageManager;
        private Vehicle car;

        [SetUp]
        public void Setup()
        {
            garageManager = new GarageManager();
            car = new Car("ModelX", "12345", new ElectricEngine(50));
            car.CreateWheels(4, "Michelin", 30f, 32f);
            garageManager.AddVehicle(car);
        }

        [Test]
        public void AddVehicle_ShouldAddSuccessfully()
        {
            var vehicle = garageManager.GetVehicle("12345");
            Assert.AreEqual(car, vehicle);
        }

        [Test]
        public void AddVehicle_DuplicateLicense_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => garageManager.AddVehicle(car));
        }

        [Test]
        public void RemoveVehicle_ShouldRemoveSuccessfully()
        {
            garageManager.RemoveVehicle("12345");
            Assert.Throws<KeyNotFoundException>(() => garageManager.GetVehicle("12345"));
        }

        [Test]
        public void UpdateVehicleStatus_ShouldUpdate()
        {
            garageManager.UpdateVehicleStatus("12345", VehicleStatus.Ready);
            Assert.AreEqual(VehicleStatus.Ready, garageManager.GetVehicle("12345").VehicleStatus);
        }

        [Test]
        public void GetVehiclesByStatus_ShouldReturnCorrectVehicles()
        {
            garageManager.UpdateVehicleStatus("12345", VehicleStatus.Ready);
            var readyVehicles = garageManager.GetVehiclesByStatus(VehicleStatus.Ready);
            Assert.Contains(car, readyVehicles.ToList());
        }
    }
}