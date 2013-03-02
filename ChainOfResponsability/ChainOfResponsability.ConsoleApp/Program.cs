using System;

namespace ChainOfResponsability.ConsoleApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      ICommand chain = new Chain<ICommand>()
        .Add<Command1>()
        .Add<Command2>(() => new Command2("Test"))
        .Build();

      chain.Execute();

      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }
  }
}