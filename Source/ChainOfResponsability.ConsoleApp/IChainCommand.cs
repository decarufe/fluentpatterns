using CommandPattern;

namespace ChainOfResponsability.ConsoleApp
{
  public interface IChainCommand : ICommand, ILink<IChainCommand>
  {
  }
}