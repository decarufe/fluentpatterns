namespace ChainOfResponsability.ConsoleApp
{
  public class Command1 : IChainCommand
  {
    public void Execute()
    {
      System.Console.WriteLine("Command 1");
      if (NextInChain != null) NextInChain.Execute();
    }

    public IChainCommand NextInChain { get; set; }
  }
}