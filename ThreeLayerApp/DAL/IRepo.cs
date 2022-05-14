using System.Collections.Generic;

namespace ThreeLayerApp.DAL
{
    public interface IRepo<T>
    {
        T Add(T man);

        T Update(int index, T man);

        IEnumerable<T> GetAll();

        bool TryDelete(int index);
    }
}
