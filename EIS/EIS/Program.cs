using System;
using System.Configuration;
using System.Text;
using System.Diagnostics;
using TempMethod;
using IoC;
using AbsFabAndBuilder;
using Iterators;

namespace EIS
{
    class Program
    {
        private static string _serializer = ConfigurationManager.AppSettings["serializer"];
        private static int _labsNum = 7;
        private static TrivialIoCC _iocc = new TrivialIoCC();

        static void Main(string[] args)
        {
            var theme = Menu();

            switch (theme)
            {
                case 1: { TemplateMethod(); break; }
                case 2: { IterPlusObserv(); break; }
                case 3: { IoC(); break; }
                case 4: { AbsFabPlusBuilder(); break; }
                case 5: { GraphTraversal();  break; }
                default: { Console.WriteLine("Что-то явно пошло не так :("); break; }
            }
        }

        static int Menu()
        {
            Console.WriteLine("Пожалуйста, выберите тему для воспроизведения:");
            Console.WriteLine("1: Шаблонный метод.");
            Console.WriteLine("2: Итератор и Наблюдатель.");
            Console.WriteLine("3: Инверсия управления.");
            Console.WriteLine("4: Абстрактная фабрика и Строитель.");
            Console.WriteLine("5: Обход графа в глубину и в ширину с помощью паттерна Итератор");
            Console.WriteLine("Введите цифру (пожалуйста, именно цифру, мне лень было писать защиту от дурака) и нажмите на Enter:");
            var inp = Console.ReadLine();
            Console.WriteLine();
            var tp = int.TryParse(inp, out int res);
            if (!tp)
            {
                Console.WriteLine("Ну я ж ведь просил!");
                Console.WriteLine();
                return Menu();
            }
            else
                return res > _labsNum ? Menu() : res;
        }

        static void TemplateMethod()
        {
            Abstract impl1 = new Impl1();
            Impl2 impl2 = new Impl2();

            impl1.StartOperations();
            Console.WriteLine();
            impl2.StartOperations();

            Console.WriteLine();
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void IterPlusObserv()
        {
            Console.WriteLine(new NotImplementedException().Message);
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void IoC()
        {
            if (_serializer == "xml")
                _iocc.Inject<ITrivialIntf, TrivialXml>();
            else if (_serializer == "json")
                _iocc.Inject<ITrivialIntf, TrivialJson>();

            var apple = new Apple();
            var car = new Car();
            var book = new Book();

            Console.WriteLine("В конфиге мы ждем " + _serializer + " и в нашем контейнере имплементация для ITrivialIntf: " + _iocc.Get<ITrivialIntf>());
            Console.WriteLine();
            Console.WriteLine("Начинаем скармливать сериализатору классы Apple, Car, Book:");

            Console.WriteLine("Apple:");
            Console.WriteLine(_iocc.Get<ITrivialIntf>().TrivialSerializer(apple));
            Console.WriteLine();

            Console.WriteLine("Car:");
            Console.WriteLine(_iocc.Get<ITrivialIntf>().TrivialSerializer(car));
            Console.WriteLine();

            Console.WriteLine("Book:");
            Console.WriteLine(_iocc.Get<ITrivialIntf>().TrivialSerializer(book));

            Console.WriteLine();
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void AbsFabPlusBuilder()
        {
            Console.WriteLine("Начинаем клепать игры!");
            Console.WriteLine();

            var fifa = BuilderHub.CreateGame(new FIFABuilder(), new FIFA());
            var starWars = BuilderHub.CreateGame(new StarWarsBuilder(), new StarWars());
            var typical = BuilderHub.CreateGame(new TypicalEAGameBuilder(), null);

            Console.WriteLine("Построили и произвели FIFA.");
            ShowGameDescription(fifa);
            Console.WriteLine();

            Console.WriteLine("Построили и произвели Star Wars.");
            ShowGameDescription(starWars);
            Console.WriteLine();

            Console.WriteLine("Построили и произвели типичную игру EA.");
            ShowGameDescription(typical);
            Console.WriteLine();

            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void GraphTraversal()
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine("Обходим графа и становимся маркизом");
            Console.WriteLine("Создаем граф как дерево как структуру офисов продаж...");

            var root = CreateTree();
            Console.WriteLine("...дерево создано, начинаем обходы и сравнивание затраченного времени.");
            Console.WriteLine();

            var summ = 0;
            stopWatch.Start();
            var widthIterator = new WidthIterator(root);
            foreach (var node in widthIterator)
                summ += node.SucceededSales;
            stopWatch.Stop();
            Console.WriteLine("Сумма после обхода в ширину: " + summ);
            Console.WriteLine("Затраченное время: " + stopWatch.ElapsedTicks + " ticks");
            Console.WriteLine();
            summ = 0;

            root.Reset();
            stopWatch.Start();
            var depthIterator = new DepthIterator(root);
            foreach (var node in depthIterator)
                summ += node.SucceededSales;
            stopWatch.Stop();
            Console.WriteLine("Сумма после обхода в глубину: " + summ);
            Console.WriteLine("Затраченное время: " + stopWatch.ElapsedTicks + " ticks");
            Console.WriteLine();

            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        private static Node CreateTree()
        {
            Console.WriteLine("Создаем корневое подразделение");
            Node root = new Node();
            var summ = root.SucceededSales;
            Console.WriteLine("Число продаж в корневом подразделении: " + summ);

            var sb = new StringBuilder("Число продаж в региональных офисах продаж: ");
            root.GenerateChilds();
            foreach(var ch in root.Childs)
            {
                summ += ch.SucceededSales;
                sb.Append($"{ch.SucceededSales} ");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            sb.Append("Число продаж в локальных офисах продаж: ");
            foreach (var ch in root.Childs)
            {
                ch.GenerateChilds();
                foreach (var chch in ch.Childs)
                {
                    summ += chch.SucceededSales;
                    sb.Append($"{chch.SucceededSales} ");
                }
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("Итоговое число продаж: " + summ);

            return root;
            
        }

        private static void ShowGameDescription(Game game)
        {
            Console.WriteLine("Композитор: " + (game.Composer == null ? "А зачем он нужен?" : game.Composer));
            Console.WriteLine("Цветовой фон: " + (game.Color == null ? "А нет его" : game.Color));
            Console.WriteLine("Сеттинг. " + (game.Setting == null ? "Это все прошлый век!" : game.Setting.ToString()));
            Console.WriteLine("Оружие. " + (game.Weapon == null ? "Мы за мир! BLM!" : game.Weapon.ToString()));
        }
    }
}
