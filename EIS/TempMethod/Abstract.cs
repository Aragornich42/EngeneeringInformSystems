using System;

namespace TempMethod
{
  public abstract class Abstract
  {
    public void StartOperations()
    {
      Operation1();
      Operation2();
      Operation3();
    }

    public abstract void Operation1();

    public abstract void Operation2();

    public virtual void Operation3()
    {
      Console.WriteLine("Abstract operation 3");
    }
  }
}
