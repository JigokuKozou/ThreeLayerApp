using System;

namespace ThreeLayerApp.Entities
{
    public class Student : Man
    {
        private int _yearStartOfStudy;

        private int _course;

        private int _group;

        public Student(string name, int age, float weigth, float height, 
            int yearStartOfStudy, int course, int group) : base(name, age, weigth, height)
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

        public override string ToString()
            => base.ToString() + 
            "Год начала обучения: " + YearStartOfStudy + Environment.NewLine +
            "Курс: " + Course + Environment.NewLine +
            "Группа: " + Group + Environment.NewLine;

        public override bool Equals(object obj)
        {
            if (obj is Student other)
                return Equals(other);

            return base.Equals(obj);
        }

        public override int GetHashCode() 
            => HashCode.Combine(base.GetHashCode(), YearStartOfStudy, Course, Group);

        public bool Equals(Student other)
        {
            return base.Equals(other) &&
                YearStartOfStudy == other.YearStartOfStudy &&
                Course == other.Course &&
                Group == other.Group;
        }
    }
}
