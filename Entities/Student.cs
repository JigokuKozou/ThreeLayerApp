using System;

namespace ThreeLayerApp.Entities
{
    public class Student : Man
    {
        private int _yearStartOfStudy;

        private int _course;

        private int _group;

        public Student(string name, int age, float weigth, float heigth, 
            int yearStartOfStudy, int course, int group) : base(name, age, weigth, heigth)
        {
            YearStartOfStudy = yearStartOfStudy;
            Course = course;
            Group = group;
        }

        public int YearStartOfStudy
        {
            get => _yearStartOfStudy;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(YearStartOfStudy));

                _yearStartOfStudy = value;
            }
        }

        public int Course
        {
            get => _course;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Course));

                _course = value;
            }
        }

        public int Group
        {
            get => _group;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Group));

                _group = value;
            }
        }
    }
}
