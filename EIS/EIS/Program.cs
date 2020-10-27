using System;
using TempMethod;

namespace EIS
{
  class Program
  {
    static void Main(string[] args)
    {

      Abstract impl1 = new Impl1();
      Impl2 impl2 = new Impl2();

      impl1.StartOperations();
      Console.WriteLine();
      impl2.StartOperations();

      Console.ReadKey();
    }
  }
}
