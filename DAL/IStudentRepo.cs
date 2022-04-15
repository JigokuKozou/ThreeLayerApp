using System;
using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    internal interface IStudentRepo
    {
        Student Add(Student man);

        Student Update(Student man);

        List<Student> GetAll();

        bool TryDelete(Guid id);

        bool TryDelete(int index);
    }
}
