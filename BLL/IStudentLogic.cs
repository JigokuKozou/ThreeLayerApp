using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public interface IStudentLogic
    {
        Student Create(string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group);

        IEnumerable<Student> FindAll();

        Student Update(int index, string name, int age, float weigth, float height,
            int yearStartOfStudy, int course, int group);

        bool TryDelete(int index);

        Student Find(int index);
    }
}
