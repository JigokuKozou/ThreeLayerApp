using ThreeLayerApp.BLL;
using ThreeLayerApp.DAL;
using ThreeLayerApp.Entities;
using ThreeLayerApp.PLL;

namespace ThreeLayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new MemoryRepo<Man>();
            var logic = new ManLogicImpl(repo);
            ConsoleInterface consoleInterface = new ConsoleInterface(logic);

            consoleInterface.Start();
        }
    }
}
