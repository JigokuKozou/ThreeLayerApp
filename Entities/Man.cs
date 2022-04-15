using System;

namespace ThreeLayerApp.Entities
{
    [Serializable]
    public class Man
    {
        protected string _name;

        protected int _age;

        protected float _weigth;

        protected float _height;

        public Man(string name, int age, float weigth, float heigth)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Weigth = weigth;
            Height = heigth;
        }

        public Guid Id { get; init; }

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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Height));

                _height = value;
            }
        }
    }
}
