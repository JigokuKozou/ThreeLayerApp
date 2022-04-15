using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public interface IManLogic
    {
        public Man Create(string name, int age, float weigth, float height);

        public Man Update(int index, string name, int age, float weigth, float height);

        public bool TryDelete(int index);

        IEnumerable<Man> FindAll();

        Man Find(int index);
    }
}
