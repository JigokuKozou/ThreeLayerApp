using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public interface IStudentLogic
    {
        public Student Create(string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group);

        public Student Update(int index, string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group);

        public bool TryDelete(int index);
    }
}
