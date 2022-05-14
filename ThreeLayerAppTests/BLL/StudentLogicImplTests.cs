using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeLayerApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayerApp.Entities;
using ThreeLayerApp.DAL;

namespace ThreeLayerApp.BLL.Tests
{
    [TestClass()]
    public class StudentLogicImplTests
    {
        private static StudentLogicImpl _studentLogic = new(new MemoryRepo<Student>());

        private const string name = "Nikita";
        private const int age = 18;
        private const float weigth = 87;
        private const float height = 187;
        private const int yearStartOfStudy = 2020;
        private const int course = 2;
        private const int group = 221;

        [TestCleanup()]
        public void CleanUp()
        {
            _studentLogic = new(new MemoryRepo<Student>());
        }

        [TestMethod()]
        public void CreateTest_CorrectData()
        {
            var actual = _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);

            Assert.IsTrue(
                actual?.Name == name &&
                actual?.Age == age &&
                actual?.Weigth == weigth &&
                actual?.Height == height &&
                actual?.YearStartOfStudy == yearStartOfStudy &&
                actual?.Course == course &&
                actual?.Group == group
                );
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTest_NullName_Exception()
        {
            _studentLogic.Create(null, age, weigth, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_AgeLessThan0_Exception()
        {
            _studentLogic.Create(name, -1, weigth, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_WeightIs0_Exception()
        {
            _studentLogic.Create(name, age, 0, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_WeightLessThan0_Exception()
        {
            _studentLogic.Create(name, age, -1, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_HeightIs0_Exception()
        {
            _studentLogic.Create(name, age, weigth, 0, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_HeightLessThan0_Exception()
        {
            _studentLogic.Create(name, age, weigth, -1, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_YearStartOfStudyLessThan0_Exception()
        {
            _studentLogic.Create(name, age, weigth, height, -1, course, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_CourseLessThan0_Exception()
        {
            _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, -1, group);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_GroupLessThan0_Exception()
        {
            _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateTest_IndexLessThan0_Exception()
        {
            _studentLogic.Update(-1, name, age, weigth, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        public void UpdateTest_0_Correct()
        {
            var expected = new Student(name, age + 3, weigth - 5, height + 2, yearStartOfStudy + 2, course + 1, group + 1);

            _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);
            var actual = _studentLogic.Update(0, expected.Name, expected.Age, expected.Weigth, 
                expected.Height, expected.YearStartOfStudy, expected.Course, expected.Group);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateTest_IndexMoreThanLength_Exception()
        {
            _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);
            var actual = _studentLogic.Update(1, name, age, weigth, height, yearStartOfStudy, course, group);
        }

        [TestMethod()]
        public void TryDeleteTest_0_Correct()
        {
            _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);
            Assert.IsTrue(_studentLogic.TryDelete(0) && _studentLogic.FindAll().Any() == false);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTest_IndexLessThan0_Exception()
        {
            var man = _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);
            var actual = _studentLogic.Find(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindTest_IndexMoreThanLength_Exception()
        {
            _studentLogic.Find(0);
        }

        [TestMethod()]
        public void FindTest_0_Correct()
        {
            var student = _studentLogic.Create(name, age, weigth, height, yearStartOfStudy, course, group);

            Assert.AreEqual(_studentLogic.Find(0), student);
        }
    }
}