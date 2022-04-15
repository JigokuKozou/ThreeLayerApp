using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public class StudentLogicImpl : IStudentLogic
    {
        public Student Create(string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group)
            => new Student(name, age, weigth, height, yearStartOfStudy, course, group);

        public bool TryDelete(int index)
        {
            throw new System.NotImplementedException();
        }

        public Student Update(int index, string name, int age, float weigth, float height, int yearStartOfStudy, int course, int group)
        {
            throw new System.NotImplementedException();
        }
    }
}
