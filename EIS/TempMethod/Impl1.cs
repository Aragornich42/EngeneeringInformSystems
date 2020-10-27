using System;
using System.Collections.Generic;
using System.Text;

namespace TempMethod
{
  public class Impl1 : Abstract
  {
    public override void Operation1()
    {
      Console.WriteLine("Impl1 operation 1");
    }

    public override void Operation2()
    {
      Console.WriteLine("Impl1 operation 2");
    }

    public override void Operation3()
    {
      Console.WriteLine("Impl1 operation 3");
    }
  }
}
