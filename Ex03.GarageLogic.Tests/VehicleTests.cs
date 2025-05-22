using NUnit.Framework;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Tesla", "5678", new ElectricEngine(50));
            car.CreateWheels(4, "Michelin", 30f, 32f);
        }

        [Test]
        public void AddRestProperties_ShouldSetColorAndDoors()
        {
            var extraProps = new List<string> { "White", "4" };
            car.AddRestProperties(extraProps);
            Assert.AreEqual(CarColor.White, car.m_Color);
            Assert.AreEqual(4, car.m_NumberOfDoors);
        }

        [Test]
        public void GetEnergyPercentage_ShouldReturnCorrectValue()
        {
            car.Recharge(25);
            Assert.AreEqual(50, car.GetEnergyPercentage());
        }

        [Test]
        public void UpdateVehicleStatus_ShouldThrowIfInvalidTransition()
        {
            car.SetVehicleStatus(VehicleStatus.InRepair);
            Assert.Throws<System.InvalidOperationException>(() => car.UpdateVehicleStatus(VehicleStatus.Paid));
        }

        [Test]
        public void InflateWheelToMax_ShouldSetCorrectPressure()
        {
            car.InflateWheelToMax(0);
            Assert.AreEqual(32f, car.Wheels[0].m_CurrentAirPressure);
        }

        [Test]
        public void InflateAllWheelsToMax_ShouldSetAllToMax()
        {
            car.InflateAllWheelsToMax();
            foreach (var wheel in car.Wheels)
            {
                Assert.AreEqual(32f, wheel.m_CurrentAirPressure);
            }
        }
    }
}