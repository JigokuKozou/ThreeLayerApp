using System;
using System.Collections.Generic;
using System.Linq;
using ThreeLayerApp.BLL;

namespace ThreeLayerApp.PLL
{
    public class ConsoleInterface
    {
        private IManLogic _manLogic;

        private IStudentLogic _studentLogic;

        private static string[] _actionNames = Enum.GetNames(typeof(Actions));

        public ConsoleInterface(IManLogic manLogic)
        {
            _manLogic = manLogic;
        }

        public ConsoleInterface(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        public bool IsManLogic => _manLogic != null;

        public void Start()
        {
            Actions action = Actions.None;

            while (action is not Actions.Exit)
            {
                action = RequestAction();

                switch (action)
                {
                    case Actions.None:
                        continue;
                    case Actions.Add:
                        Add();
                        break;
                    case Actions.Get:
                        break;
                    case Actions.GetAll:
                        break;
                    case Actions.Update:
                        break;
                    case Actions.Delete:
                        break;
                    case Actions.Exit:
                        break;
                    default:
                        throw new NotImplementedException(action + " action not implemented");
                }
            }
        }

        private void Add()
        {
            Console.WriteLine("Введите имя, возраст, вес, рост");
            var arguments = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arguments.Length == 4 && 
                int.TryParse(arguments[1], out int age) &&
                float.TryParse(arguments[2], out float weigth) &&
                float.TryParse(arguments[2], out float height))
            {
                _manLogic.Create(arguments[0], age, weigth, height);
            }
            else
            {
                Console.WriteLine("Не верный формат данных");
            }
        }

        private void GetAll()
        {
            var man = _manLogic.FindAll();
            int maxNameLength = man.Max(x => x.Name).Length;
            Show();
        }

        private Actions RequestAction()
        {
            ShowActions();

            Actions result;
            do
            {
                Console.Write(">>> ");
            } while (!Enum.TryParse(Console.ReadLine(), out result));

            return result;
        }

        private void ShowActions()
        {
            string actions = " Actions ";
            int maxLength = _actionNames.Max(x => x.Length);
            maxLength = actions.Length > maxLength ? actions.Length : maxLength;

            string line = '+' + new string('-', maxLength) + '+';

            Console.WriteLine(line);
            Console.WriteLine('|' + actions + '|');
            Console.WriteLine(line);
            for (int i = 1; i < _actionNames.Length; i++)
            {
                Console.WriteLine($"| { _actionNames[i] }");
            }
            Console.WriteLine(line + Environment.NewLine);
        }

        private static void Show(IEnumerable<string> collection, string label = "")
        {
            int maxLength = collection.Max(x => x.Length);
            maxLength = label?.Length > maxLength ? label.Length : maxLength;

            string line = '+' + new string('-', maxLength + 2) + '+';

            if (label is not null && label.Length != 0)
            {
                Console.WriteLine(
                    line + Environment.NewLine +
                    "| " + label + " |" + Environment.NewLine);
            }

            Console.WriteLine(line);
            foreach (string item in collection)
            {
                Console.WriteLine($"| {{0,{{{ maxLength }}} |", item);
            }
        }
    }

    internal enum Actions
    {
        None,
        Add,
        Get,
        GetAll,
        Update,
        Delete,
        Exit,
    }
}
