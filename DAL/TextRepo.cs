using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ThreeLayerApp.DAL
{
    public class TextRepo<T> : IRepo<T>
    {
        public string PathSaves { get; set; } = nameof(T) + ".txt";

        public T Add(T item)
        {
            var men = LoadItems();
            men.Add(item);

            Save(men);

            return item;
        }

        public IEnumerable<T> GetAll() => LoadItems();

        public bool TryDelete(int index)
        {
            var men = LoadItems();

            bool result = 0 <= index && index < men.Count;

            if (result)
            {
                men.RemoveRange(index, 1);

                Save(men);
            }

            return result;
        }

        public T Update(int index, T man)
        {
            var men = LoadItems();

            men[index] = man;

            Save(men);

            return man;
        }

        public void Clear()
        {
            if (File.Exists(PathSaves))
            {
                File.Delete(PathSaves);
            }
        }

        private List<T> LoadItems()
        {
            if (File.Exists(PathSaves))
            {
                return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(PathSaves)) ?? new List<T>();
            }

            return new List<T>();
        }

        private void Save(IEnumerable<T> men)
            => File.WriteAllText(PathSaves, JsonSerializer.Serialize(men), Encoding.UTF8);
    }
}
