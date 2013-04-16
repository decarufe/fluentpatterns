using System;

namespace ChainOfResponsability.ConsoleApp
{
  public class Command1 : ChainCommand
  {
    public override void Execute(object param)
    {
      System.Console.WriteLine("Command 1");
      if (NextInChain != null) NextInChain.Execute(param);
    }
  }
}