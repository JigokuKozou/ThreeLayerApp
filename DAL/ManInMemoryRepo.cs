using System;
using System.Collections.Generic;
using System.Linq;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    public class ManInMemoryRepo : IManRepo
    {
        private List<Man> _men = new List<Man>();

        public Man Add(Man man)
        {
            if (!_men.Any(x => x.Id == man.Id))
            {
                _men.Add(man);
                return man;
            }
            else
            {
                throw new ArgumentException("Man already exists");
            }
        }

        public Man Update(int index, Man man)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index));

            _men[index] = man;

            return man;
        }

        public Man Update(Guid id, Man man)
        {
            var old = _men.FirstOrDefault(x => x.Id == id);

            if (old is not null)
            {
                _men[_men.IndexOf(old)] = man;
            }
            else
            {
                throw new ArgumentException("Man not found", nameof(id));
            }

            return man;
        }

        public IEnumerable<Man> GetAll() => _men;

        public bool TryDelete(Guid id)
        {
            var man = _men.FirstOrDefault(x => x.Id == id);
            if (man is not null)
            {
                _men.Remove(man);
                return true;
            }

            return false;
        }

        public bool TryDelete(int index)
        {
            bool isInRange = IsInRange(index);

            if (isInRange)
                _men.RemoveAt(index);

            return isInRange;
        }

        private bool IsInRange(int index) 
            => 0 <= index && index <= _men.Count;
    }
}
