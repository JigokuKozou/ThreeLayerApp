using ThreeLayerApp.BLL;
using ThreeLayerApp.DAL;
using ThreeLayerApp.PLL;

namespace ThreeLayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manRepo = new ManTextRepo();
            var manLogic = new ManLogicImpl(manRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(manLogic);

            consoleInterface.Start();
        }
    }
}
