using System;
using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    public class ManInMemoryRepo : IRepo<Man>
    {
        protected List<Man> _men = new();

        public virtual Man Add(Man man)
        {
            if (!_men.Contains(man))
            {
                _men.Add(man);
                return man;
            }
            else
            {
                throw new ArgumentException("Man already exists");
            }
        }

        public virtual Man Update(int index, Man man)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index));

            _men[index] = man;

            return man;
        }

        public virtual IEnumerable<Man> GetAll() => _men;

        public virtual bool TryDelete(int index)
        {
            bool isInRange = IsInRange(index);

            if (isInRange)
                _men.RemoveAt(index);

            return isInRange;
        }

        protected bool IsInRange(int index) 
            => 0 <= index && index <= _men.Count;
    }
}
