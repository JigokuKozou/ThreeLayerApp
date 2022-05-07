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

        private static string[] _actionNames = Enum.GetNames(typeof(Actions))[1..];

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
                Console.WriteLine();

                switch (action)
                {
                    case Actions.None:
                        continue;
                    case Actions.Add:
                        if (IsManLogic)
                            AddMan();
                        else
                            AddStudent();
                        break;
                    case Actions.Get:
                        if (IsManLogic)
                            GetMen();
                        else
                            GetStudents();
                        break;
                    case Actions.GetAll:
                        if (IsManLogic)
                            GetAllMen();
                        else
                            GetAllStudents();
                        break;
                    case Actions.Update:
                        if (IsManLogic)
                            UpdateMen();
                        else
                            UpdateStudents();
                        break;
                    case Actions.Delete:
                        if (IsManLogic)
                            DeleteMen();
                        else
                            DeleteStudents();
                        break;
                    case Actions.Exit:
                        break;
                    default:
                        throw new NotImplementedException(action + " action not implemented");
                }

                Console.WriteLine();
            }
        }

        private void AddMan()
        {
            if (RequestManInfo(out string name, out int age, out float weigth, out float height))
            {
                _manLogic.Create(name, age, weigth, height);
            }
            else
            {
                Console.WriteLine("Не верный формат данных");
            }
        }

        private void AddStudent()
        {
            if (RequestStudentInfo(out string name, out int age, out float weigth, out float height, out int yearOfStudy,
                out int course, out int group))
            {
                _studentLogic.Create(name, age, weigth, height, yearOfStudy, course, group);
            }
            else
            {
                Console.WriteLine("Не верный формат данных");
            }
        }

        private void GetMen()
        {
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0)
            {
                --index;

                try
                {
                    Console.Write(Environment.NewLine + _manLogic.Find(index));
                }
                catch (Exception)
                {
                    Console.WriteLine("Человек не найден");
                }
            }
            else Console.WriteLine("Не верный формат");
        }

        private void GetStudents()
        {
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                --index;

                try
                {
                    Console.Write(Environment.NewLine + _studentLogic.Find(index));
                }
                catch (Exception)
                {
                    Console.WriteLine("Студент не найден");
                }
            }
            else Console.WriteLine("Не верный формат");
        }

        private void GetAllMen()
        {
            var men = _manLogic.FindAll();
            if (men is null || !men.Any())
            {
                Console.WriteLine("Пусто");
                return;
            }

            string name = "Имя";
            string age = "Возраст";
            string weigth = "Вес";
            string height = "Рост";

            int maxIdLength = men.Count().ToString().Length;

            int maxNameLength = men.Max(x => x.Name.Length);
            maxNameLength = maxNameLength > name.Length ? maxNameLength : name.Length;

            int maxAgeLength = men.Max(x => x.Age).ToString().Length;
            maxAgeLength = maxAgeLength > age.Length ? maxAgeLength : age.Length;

            int maxWeigthLength = men.Max(x => x.Weigth).ToString().Length;
            maxWeigthLength = maxWeigthLength > weigth.Length ? maxWeigthLength : weigth.Length;

            int maxHeightLength = men.Max(x => x.Height).ToString().Length;
            maxHeightLength = maxHeightLength > height.Length ? maxHeightLength : height.Length;

            string format = $"{{0, {maxNameLength}}}   {{1, {maxAgeLength}}}   {{2, {maxWeigthLength}}}   {{3, {maxHeightLength}}}";

            var IndexedMen = men.Select(man => string.Format(format, man.Name, man.Age, man.Weigth, man.Height)).ToArray();
            IndexedMen = Number(IndexedMen).ToArray();

            format = new string(' ', maxIdLength + 2) + format;
            Show(IndexedMen, string.Format(format, name, age, weigth, height));
        }

        private void GetAllStudents()
        {
            var students = _studentLogic.FindAll();
            if (students is null || !students.Any())
            {
                Console.WriteLine("Пусто");
                return;
            }

            string name = "Имя";
            string age = "Возраст";
            string weigth = "Вес";
            string height = "Рост";
            string yearStartOfStudy = "Год начала обучения";
            string course = "Курс";
            string group = "Группа";

            int maxIdLength = students.Count().ToString().Length;

            int maxNameLength = students.Max(x => x.Name.Length);
            maxNameLength = maxNameLength > name.Length ? maxNameLength : name.Length;

            int maxAgeLength = students.Max(x => x.Age).ToString().Length;
            maxAgeLength = maxAgeLength > age.Length ? maxAgeLength : age.Length;

            int maxWeigthLength = students.Max(x => x.Weigth).ToString().Length;
            maxWeigthLength = maxWeigthLength > weigth.Length ? maxWeigthLength : weigth.Length;

            int maxHeightLength = students.Max(x => x.Height).ToString().Length;
            maxHeightLength = maxHeightLength > height.Length ? maxHeightLength : height.Length;

            int maxYearLength = students.Max(x => x.YearStartOfStudy).ToString().Length;
            maxYearLength = maxYearLength > yearStartOfStudy.Length ? maxYearLength : yearStartOfStudy.Length;

            int maxCourseLength = students.Max(x => x.Course).ToString().Length;
            maxCourseLength = maxCourseLength > course.Length ? maxCourseLength : course.Length;

            int maxGroupLength = students.Max(x => x.Group).ToString().Length;
            maxGroupLength = maxGroupLength > group.Length ? maxGroupLength : group.Length;

            string format = $"{{0, {maxNameLength}}}   {{1, {maxAgeLength}}}   {{2, {maxWeigthLength}}}   {{3, {maxHeightLength}}}" +
                $"   {{4, {maxYearLength}}}   {{5, {course}}}   {{6, {group}}}";

            var IndexedMen = students.Select(
                man => string.Format(format, man.Name, man.Age, man.Weigth, man.Height, man.YearStartOfStudy, man.Course, man.Group))
                .ToArray();
            IndexedMen = Number(IndexedMen).ToArray();

            format = new string(' ', maxIdLength + 2) + format;
            Show(IndexedMen, string.Format(format, name, age, weigth, height));
        }

        private void UpdateMen()
        {
            if (RequestManInfo(out int index, out string name, out int age, out float weigth, out float height))
            {
                --index;

                try
                {
                    Console.WriteLine(Environment.NewLine + _manLogic.Update(index, name, age, weigth, height));
                }
                catch (Exception)
                {
                    Console.WriteLine("Человек не найден");
                }
            }
        }

        private void UpdateStudents()
        {
            if (RequestStudentInfo(out int index, out string name, out int age, out float weigth, out float height, 
                out int yearOfStudy, out int course, out int group))
            {
                --index;

                try
                {
                    Console.WriteLine(Environment.NewLine + 
                        _studentLogic.Update(index, name, age, weigth, height, yearOfStudy, course, group));
                }
                catch (Exception)
                {
                    Console.WriteLine("Человек не найден");
                }
            }
        }

        private void DeleteMen()
        {
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int index) || index > 0)
            {
                --index;

                if (_manLogic.TryDelete(index))
                {
                    Console.WriteLine("Человек удалён");
                }
                else
                {
                    Console.WriteLine("Человек не найден");
                }
            }
        }

        private void DeleteStudents()
        {
            Console.Write("Введите номер: ");

            if (int.TryParse(Console.ReadLine(), out int index) || index > 0)
            {
                --index;

                if (_studentLogic.TryDelete(index))
                {
                    Console.WriteLine("Студент удалён");
                }
                else
                {
                    Console.WriteLine("Студент не найден");
                }
            }
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

        private void ShowActions() => Show(_actionNames, "Actions");

        private bool RequestManInfo(out int index, out string name, out int age, out float weigth, out float height)
        {
            Console.WriteLine("Введите индекс, имя, возраст, вес, рост");
            var arguments = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return ConvertToManInfo(arguments, out index, out name, out age, out weigth, out height);
        }

        private bool RequestStudentInfo(out int index, out string name, out int age, out float weigth,
            out float height, out int yearOfStudy, out int course, out int group)
        {
            Console.WriteLine("Введите индекс, имя, возраст, вес, рост, год начала обучения, курс, группа");
            var arguments = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return ConvertToStudentInfo(arguments, out index, out name, out age, out weigth, out height, out yearOfStudy, out course, out group);
        }

        private bool RequestManInfo(out string name, out int age, out float weigth, out float height)
        {
            Console.WriteLine("Введите имя, возраст, вес, рост");
            var arguments = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return ConvertToManInfo(arguments, out name, out age, out weigth, out height);
        }

        private bool RequestStudentInfo(out string name, out int age, out float weigth,
            out float height, out int yearOfStudy, out int course, out int group)
        {
            Console.WriteLine("Введите индекс, имя, возраст, вес, рост");
            var arguments = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return ConvertToStudentInfo(arguments, out name, out age, out weigth, out height, 
                out yearOfStudy, out course, out group);
        }

        private static void Show(IEnumerable<string> collection, string label = "", int margin = 1)
        {
            int maxLength = collection.Max(x => x.Length);
            maxLength = label?.Length > maxLength ? label.Length : maxLength;

            string line = '+' + new string('-', maxLength + 2 * margin) + '+';
            string marginSpace = new string(' ', margin);
            string format = '|' + marginSpace + $"{{0, -{maxLength}}}" + marginSpace + '|';

            if (label is not null && label.Length != 0)
            {
                Console.WriteLine(line);
                Console.WriteLine(format, label);
            }

            Console.WriteLine(line);
            foreach (string item in collection)
            {
                Console.WriteLine(format, item);
            }
            Console.WriteLine(line);
        }

        private static IEnumerable<string> Number(IEnumerable<string> collection)
        {
            int maxIdLength = collection.Count().ToString().Length;
            string format = $"{{0, {maxIdLength}}}) {{1}}";

            int counter = 1;
            foreach (var item in collection)
            {
                yield return string.Format(format, counter++, item);
            }
        }

        private bool ConvertToStudentInfo(string[] arguments, out int index, out string name, out int age, out float weigth,
            out float height, out int yearOfStudy, out int course, out int group)
        {
            name = "None";
            weigth = height = age = yearOfStudy = course = group = index = 1;

            if (arguments?.Length == 8 &&
                int.TryParse(arguments[0], out index))
            {
                if (index < 0)
                {
                    Console.WriteLine("Индекс не может быть меньше 0");
                    return false;
                }

                if (ConvertToStudentInfo(arguments[1..], out name, out age, out weigth, out height, out yearOfStudy, out course, out group))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ConvertToManInfo(string[] arguments, out int index, out string name, out int age, out float weigth, 
            out float height)
        {
            name = "None";
            weigth = height = age = index = 1;

            if (arguments?.Length == 5 &&
                int.TryParse(arguments[0], out index))
            {
                if (index < 0)
                {
                    Console.WriteLine("Индекс не может быть меньше 0");
                    return false;
                }

                return ConvertToManInfo(arguments[1..], out name, out age, out weigth, out height);
            }
            else return false;
        }

        private bool ConvertToStudentInfo(string[] arguments, out string name, out int age, out float weigth,
            out float height, out int yearOfStudy, out int course, out int group)
        {
            name = "None";
            weigth = height = age = yearOfStudy = course = group = 1;

            if (arguments?.Length == 7 &&
                ConvertToManInfo(arguments[..^3], out name, out age, out weigth, out height) &&
                int.TryParse(arguments[4], out yearOfStudy) &&
                int.TryParse(arguments[5], out course) &&
                int.TryParse(arguments[6], out group))
            {
                if (yearOfStudy < 0)
                {
                    Console.WriteLine("Год начала обучения не может быть ниже 0");
                    return false;
                }
                if (course < 0)
                {
                    Console.WriteLine("Курс не может быть ниже 0");
                    return false;
                }
                if (group < 0)
                {
                    Console.WriteLine("Группа не может быть ниже 0");
                    return false;
                }
            }
            else return false;

            return true;
        }
        
        private bool ConvertToManInfo(string[] arguments, out string name, out int age, out float weigth, out float height)
        {
            name = "None";
            weigth = height = age = 1;

            if (arguments?.Length == 4 &&
                int.TryParse(arguments[1], out age) &&
                float.TryParse(arguments[2], out weigth) &&
                float.TryParse(arguments[3], out height))
            {
                name = arguments[0];

                if (age < 0)
                {
                    Console.WriteLine("Возраст не может быть ниже 0");
                    return false;
                }
                if (weigth <= 0)
                {
                    Console.WriteLine("Вес не может быть ниже или равняться 0");
                    return false;
                }
                if (height < 0)
                {
                    Console.WriteLine("Рост не может быть ниже 0");
                    return false;
                }
            }
            else return false;

            return true;
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
