using System;
using System.Configuration;
using TempMethod;
using IoC;

namespace EIS
{
    class Program
    {
        private static string serializer = ConfigurationManager.AppSettings["serializer"];
        private static int labsNum = 4;
        private static TrivialIoCC iocc = new TrivialIoCC();

        static void Main(string[] args)
        {
            var theme = Menu();

            switch (theme)
            {
                case 1: { TemplateMethod(); break; }
                case 2: { IterPlusObserv(); break; }
                case 3: { IoC(); break; }
                case 4: { AbsFabPlusBuilder(); break; }
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
                return res > labsNum ? Menu() : res;
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
            if (serializer == "xml")
                iocc.Inject<ITrivialIntf, TrivialXml>();
            else if (serializer == "json")
                iocc.Inject<ITrivialIntf, TrivialJson>();

            Console.WriteLine("В конфиге мы ждем " + serializer + " и в нашем контейнере имплементация для ITrivialIntf: " + iocc.Get<ITrivialIntf>());
            Console.WriteLine();
            Console.WriteLine("Начинаем скармливать сериализатору классы Apple, Car, Book:");

            Console.WriteLine("Apple:");

            Console.WriteLine();

            Console.WriteLine("Car:");

            Console.WriteLine();

            Console.WriteLine("Book:");


            Console.WriteLine();
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void IoC()
        {
            Console.WriteLine(new NotImplementedException().Message);
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }

        static void AbsFabPlusBuilder()
        {
            Console.WriteLine(new NotImplementedException().Message);
            Console.WriteLine("Возврат в меню завезем в следующей обнове :)");
            Console.ReadKey();
        }
    }
}
