namespace ChainOfResponsability.ConsoleApp
{
  public class Command1 : ICommand
  {
    public void Execute()
    {
      System.Console.WriteLine("Command 1");
      if (NextInChain != null) NextInChain.Execute();
    }

    public ICommand NextInChain { get; set; }
  }
}