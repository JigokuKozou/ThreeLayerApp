using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL.Tests
{
    [TestClass()]
    public class ManTextRepoTests
    {
        private static TextRepo<Man> repository = new();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            repository.PathSaves = "TestMen.txt";
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            repository.Clear();
        }

        [TestMethod()]
        public void GetAllTest_Empty()
        {
            var actual = repository.GetAll();

            Assert.IsFalse(actual.Any());
        }

        [TestMethod()]
        public void AddTest_Man()
        {
            var man = new Man("Nicolay", 18, 75, 182);
            var expected = new[] { man };

            repository.Add(man);

            var actual = repository.GetAll();

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var man = new Man("Nicolay", 18, 75, 182);
            var newMan = new Man("Nikita", 18, 75, 182);
            var expected = new[] { newMan };

            repository.Add(man);
            repository.Update(0, newMan);

            var actual = repository.GetAll();

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod()]
        public void TryDeleteTest()
        {
            var man = new Man("Nicolay", 18, 75, 182);
            var expected = Array.Empty<Man>();

            repository.Add(man);
            var isDeleted = repository.TryDelete(0);
            var actual = repository.GetAll();

            Assert.IsTrue(isDeleted && actual.SequenceEqual(expected));
        }
    }
}