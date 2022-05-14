using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ThreeLayerApp.DAL;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL.Tests
{
    [TestClass()]
    public class ManLogicImplTests
    {
        private static ManLogicImpl manLogic = new(new MemoryRepo<Man>());

        private const string name = "Nikita";
        private const int age = 18;
        private const float weigth = 87;
        private const float height = 187;

        [TestCleanup()]
        public void CleanUp()
        {
            manLogic = new(new MemoryRepo<Man>());
        }

        [TestMethod()]
        public void CreateTest_CorrectData()
        {
            var actual = manLogic.Create(name, age, weigth, height);

            Assert.IsTrue(
                actual?.Name == name &&
                actual?.Age == age &&
                actual?.Weigth == weigth &&
                actual?.Height == height
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTest_NullName_Exception()
        {
            manLogic.Create(null, age, weigth, height);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_AgeLessThan0_Exception()
        {
            manLogic.Create(name, -1, weigth, height);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_WeightIs0_Exception()
        {
            manLogic.Create(name, age, 0, height);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_WeightLessThan0_Exception()
        {
            manLogic.Create(name, age, -1, height);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_HeightIs0_Exception()
        {
            manLogic.Create(name, age, weigth, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_HeightLessThan0_Exception()
        {
            manLogic.Create(name, age, weigth, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateTest_IndexLessThan0_Exception()
        {
            manLogic.Update(-1, name, age, weigth, height);
        }

        [TestMethod()]
        public void UpdateTest_0_Correct()
        {
            var expected = new Man(name, age + 3, weigth - 5, height + 2);

            manLogic.Create(name, age, weigth, height);
            var actual = manLogic.Update(0, expected.Name, expected.Age, expected.Weigth, expected.Height);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateTest_IndexMoreThanLength_Exception()
        {
            manLogic.Create(name, age, weigth, height);
            var actual = manLogic.Update(1, name, age, weigth, height);
        }

        [TestMethod()]
        public void TryDeleteTest_0_Correct()
        {
            manLogic.Create(name, age, weigth, height);
            Assert.IsTrue(manLogic.TryDelete(0) && manLogic.FindAll().Any() == false);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTest_IndexLessThan0_Exception()
        {
            var man = manLogic.Create(name, age, weigth, height);
            var actual = manLogic.Find(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTest_IndexMoreThanLength_Exception()
        {
            manLogic.Find(0);
        }

        [TestMethod()]
        public void FindTest_0_Correct()
        {
            var man = manLogic.Create(name, age, weigth, height);

            Assert.AreEqual(manLogic.Find(0), man);
        }
    }
}