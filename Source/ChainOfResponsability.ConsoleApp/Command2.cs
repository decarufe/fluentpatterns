namespace ChainOfResponsability.ConsoleApp
{
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
      System.Console.WriteLine("Command 2 " + _message);
      if (NextInChain != null) NextInChain.Execute();
    }

    public ICommand NextInChain { get; set; }
  }
}