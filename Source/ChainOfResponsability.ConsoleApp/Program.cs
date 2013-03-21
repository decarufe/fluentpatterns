using System;

namespace ChainOfResponsability.ConsoleApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      IChainCommand chain = new Chain<IChainCommand>()
        .Add<Command1>()
        .Add<Command2>(() => new Command2("Test"))
        .Build();

      chain.Execute();

      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }
  }
}