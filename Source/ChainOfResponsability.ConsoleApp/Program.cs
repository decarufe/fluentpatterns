using System;
using FluentPatterns.Library;

namespace ChainOfResponsability.ConsoleApp
{
  internal static class Program
  {
    private static void Main()
    {
      IChainCommand chain = new Chain<IChainCommand>()
        .Add<Command1>()
        .Add<Command2>(() => new Command2("Test"))
        .Build();

      chain.Execute(null);

      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }
  }
}