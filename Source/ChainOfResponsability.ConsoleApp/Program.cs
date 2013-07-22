using System;
using FluentPatterns.Library;

namespace ChainOfResponsability.ConsoleApp
{
  internal static class Program
  {
    private static void Main()
    {
      var chain = new ChainBuilder<ChainCommand>()
        .Add<Command1>()
        .Add<Command2>(() => new Command2("Test"))
        .Build();
      chain.Execute(null);
      
      var command1 = new Command1();
      var command2 = new Command2("Test");
      command1.NextInChain = command2;
      command1.Execute(null);

      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }
  }
}