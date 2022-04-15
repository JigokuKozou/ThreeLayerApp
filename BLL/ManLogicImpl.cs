using System.Collections.Generic;
using System.Linq;
using ThreeLayerApp.DAL;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public class ManLogicImpl : IManLogic
    {
        private IManRepo _manRepo;

        public ManLogicImpl(IManRepo manRepo)
        {
            _manRepo = manRepo;
        }

        public Man Create(string name, int age, float weigth, float height)
        {
            var man = new Man(name, age, weigth, height);
            _manRepo.Add(man);
            return man;
        }

        public Man Update(int index, string name, int age, float weigth, float height)
        {
            var man = new Man(name, age, weigth, height);
            _manRepo.Update(index, man);

            return man;
        }

        public bool TryDelete(int index) => _manRepo.TryDelete(index);

        public IEnumerable<Man> FindAll() => _manRepo.GetAll();

        public Man Find(int index) => _manRepo.GetAll().Skip(index).First();
    }
}
