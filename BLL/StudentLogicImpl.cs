using System.Collections.Generic;
using System.Linq;
using ThreeLayerApp.DAL;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public class StudentLogicImpl : IStudentLogic
    {
        private IRepo<Student> _repository;

        public StudentLogicImpl(IRepo<Student> repository)
        {
            _repository = repository;
        }

        public Student Create(string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group)
        {
            var student = new Student(name, age, weigth, height, yearStartOfStudy, course, group);

            return _repository.Add(student);
        }

        public Student Update(int index, string name, int age, float weigth, float height, 
            int yearStartOfStudy, int course, int group)
            => _repository.Update(index, new Student(name, age, weigth, height, yearStartOfStudy, course, group));

        public Student Find(int index) => _repository.GetAll().Skip(index).First();

        public IEnumerable<Student> FindAll() => _repository.GetAll();

        public bool TryDelete(int index) => _repository.TryDelete(index);
    }
}
