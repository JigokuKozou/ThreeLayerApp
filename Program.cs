using ThreeLayerApp.BLL;
using ThreeLayerApp.DAL;
using ThreeLayerApp.PLL;

namespace ThreeLayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IManRepo manRepo = new ManInMemoryRepo();
            IManLogic manLogic = new ManLogicImpl(manRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(manLogic);

            consoleInterface.Start();
        }
    }
}
