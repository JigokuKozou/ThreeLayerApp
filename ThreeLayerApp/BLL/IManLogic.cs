using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.BLL
{
    public interface IManLogic
    {
        Man Create(string name, int age, float weigth, float height);

        IEnumerable<Man> FindAll();

        Man Update(int index, string name, int age, float weigth, float height);

        bool TryDelete(int index);

        Man Find(int index);
    }
}
