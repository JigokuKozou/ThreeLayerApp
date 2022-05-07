using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    public class ManTextRepo : IRepo<Man>
    {
        private const string pathSaves = "Men.txt";

        public Man Add(Man man)
        {
            var men = LoadMens();
            men.Add(man);

            Save(men);

            return man;
        }

        public IEnumerable<Man> GetAll() => LoadMens();

        public bool TryDelete(int index)
        {
            var men = LoadMens();

            bool result = 0 <= index && index < men.Count;

            if (result)
            {
                men.RemoveRange(index, 1);

                Save(men);
            }

            return result;
        }

        public Man Update(int index, Man man)
        {
            var men = LoadMens();

            men[index] = man;

            Save(men);

            return man;
        }

        private List<Man> LoadMens()
        {
            if (File.Exists(pathSaves))
            {
                return JsonSerializer.Deserialize<List<Man>>(File.ReadAllText(pathSaves)) ?? new List<Man>();
            }

            return new List<Man>();
        }

        private void Save(IEnumerable<Man> men)
            => File.WriteAllText(pathSaves, JsonSerializer.Serialize(men), Encoding.UTF8);
    }
}
