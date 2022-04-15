using System.Collections.Generic;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    public interface IManRepo
    {
        Man Add(Man man);

        Man Update(int index, Man man);

        bool TryDelete(int index);

        IEnumerable<Man> GetAll();
    }
}
