using System;

namespace ThreeLayerApp.Entities
{
    public class Man
    {
        protected string _name;

        protected int _age;

        protected float _weigth;

        protected float _height;

        public Man(string name, int age, float weigth, float height)
        {
            Name = name;
            Age = age;
            Weigth = weigth;
            Height = height;
        }

        public string Name
        {
            get => _name; 
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(Name));

                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Age));

                _age = value;
            }
        }

        public float Weigth
        {
            get => _weigth;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Weigth));

                _weigth = value;
            }
        }

        public float Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Height));

                _height = value;
            }
        }

        public override string ToString()
            => "Человек " + Environment.NewLine +
            "Имя: " + Name + Environment.NewLine +
            "Возраст: " + Age + Environment.NewLine +
            "Вес: " + Weigth + Environment.NewLine +
            "Рост: " + Height + Environment.NewLine;

        public override bool Equals(object obj)
        {
            if (obj is Man other)
                return Equals(other);
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Age, Weigth, Height);
        }

        public bool Equals(Man other)
        {
            if (other is null)
                return false;

            return Name == other.Name && 
                Age == other.Age && 
                Weigth == other.Weigth &&
                Height == other.Height;
        }
    }
}
