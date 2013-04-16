using System;

namespace ChainOfResponsability.ConsoleApp
{
  public class Command2 : ChainCommand
  {
    private readonly string _message;

    public Command2(string message)
    {
      _message = message;
    }

    public override void Execute(object param)
    {
      System.Console.WriteLine("Command 2 " + _message);
      if (NextInChain != null) NextInChain.Execute(param);
    }
  }
}