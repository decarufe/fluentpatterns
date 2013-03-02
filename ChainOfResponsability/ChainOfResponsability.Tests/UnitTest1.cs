using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainOfResponsability.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var chain = new Chain<ICommand>()
        .Add<Command1>()
        .Add<Command2>(() => new Command2("Test"))
        .Build();

      chain.Execute();

      chain = new Chain<ICommand>()
        .Add<Command2>()
        .Add<Command1>()
        .Build();

      chain.Execute();
    }
  }

  public interface ICommand : ILink<ICommand>
  {
    void Execute();
  }

  public class Command1 : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Command 1");
      if (NextInChain != null) NextInChain.Execute();
    }

    public ICommand NextInChain { get; set; }
  }

  public class Command2 : ICommand
  {
    private readonly string _message;

    public Command2(string message)
    {
      _message = message;
    }

    public Command2()
    {
    }

    public void Execute()
    {
      Console.WriteLine("Command 2 " + _message);
      if (NextInChain != null) NextInChain.Execute();
    }

    public ICommand NextInChain { get; set; }
  }
}
