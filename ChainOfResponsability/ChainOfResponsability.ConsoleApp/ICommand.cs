namespace ChainOfResponsability.ConsoleApp
{
  public interface ICommand : ILink<ICommand>
  {
    void Execute();
  }
}