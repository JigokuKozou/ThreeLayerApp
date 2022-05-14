using System.Collections.Generic;
using System.Linq;
using ThreeLayerApp.DAL;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public class ManLogicImpl : IManLogic
    {
        private IRepo<Man> _repository;

        public ManLogicImpl(IRepo<Man> repository)
        {
            _repository = repository;
        }

        public Man Create(string name, int age, float weigth, float height)
        {
            var man = new Man(name, age, weigth, height);

            return _repository.Add(man);
        }

        public Man Update(int index, string name, int age, float weigth, float height)
        {
            var man = new Man(name, age, weigth, height);
            _repository.Update(index, man);

            return man;
        }

        public bool TryDelete(int index) => _repository.TryDelete(index);

        public IEnumerable<Man> FindAll() => _repository.GetAll();

        public Man Find(int index)
        {
            if (index < 0)
                throw new System.ArgumentOutOfRangeException(nameof(index));

            try
            {
                return _repository.GetAll().Skip(index).First();
            }
            catch
            {
                throw new System.ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}
