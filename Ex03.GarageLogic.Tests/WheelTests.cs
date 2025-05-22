using NUnit.Framework;
using System;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic.Tests
{
    [TestFixture]
    public class WheelTests
    {
        [Test]
        public void Constructor_ValidParams_ShouldCreateWheel()
        {
            var wheel = new Wheel("Michelin", 30, 32);
            Assert.IsNotNull(wheel);
        }

        [Test]
        public void AddAir_ValidAmount_ShouldIncreasePressure()
        {
            var wheel = new Wheel("Michelin", 20, 32);
            wheel.AddAir(5);
            Assert.AreEqual(25, wheel.m_CurrentAirPressure);
        }

        [Test]
        public void AddAir_TooMuch_ShouldThrow()
        {
            var wheel = new Wheel("Michelin", 30, 32);
            Assert.Throws<ValueRangeException>(() => wheel.AddAir(5));
        }

        [Test]
        public void InflateToMax_ShouldSetPressureToMax()
        {
            var wheel = new Wheel("Michelin", 20, 32);
            wheel.InflateToMax();
            Assert.AreEqual(32, wheel.m_CurrentAirPressure);
        }
    }
}