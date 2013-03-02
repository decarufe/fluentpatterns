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
}
