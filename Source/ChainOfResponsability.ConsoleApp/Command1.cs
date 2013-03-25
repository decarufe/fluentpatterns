namespace ChainOfResponsability.ConsoleApp
{
  public class Command1 : IChainCommand
  {
    public void Execute(object param)
    {
      System.Console.WriteLine("Command 1");
      if (NextInChain != null) NextInChain.Execute(param);
    }

    public IChainCommand NextInChain { get; set; }
  }
}