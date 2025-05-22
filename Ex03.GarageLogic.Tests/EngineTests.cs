using NUnit.Framework;
using System;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Tests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void FuelEngine_AddEnergy_Valid_ShouldIncreaseEnergy()
        {
            var engine = new FuelEngine(FuelType.Octane95, 50);
            engine.AddEnergy(20, FuelType.Octane95);
            Assert.AreEqual(20, engine.CurrentEnergy);
        }

        [Test]
        public void FuelEngine_AddEnergy_InvalidFuel_ShouldThrow()
        {
            var engine = new FuelEngine(FuelType.Octane95, 50);
            Assert.Throws<ArgumentException>(() => engine.AddEnergy(10, FuelType.Octane96));
        }

        [Test]
        public void FuelEngine_AddEnergy_OverCapacity_ShouldThrow()
        {
            var engine = new FuelEngine(FuelType.Octane95, 50);
            Assert.Throws<ValueRangeException>(() => engine.AddEnergy(60, FuelType.Octane95));
        }

        [Test]
        public void ElectricEngine_AddEnergy_Valid_ShouldIncreaseEnergy()
        {
            var engine = new ElectricEngine(50);
            engine.AddEnergy(25);
            Assert.AreEqual(25, engine.CurrentEnergy);
        }

        [Test]
        public void ElectricEngine_AddEnergy_OverCapacity_ShouldThrow()
        {
            var engine = new ElectricEngine(50);
            Assert.Throws<ValueRangeException>(() => engine.AddEnergy(60));
        }
    }
}