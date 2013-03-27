using System.Windows.Input;
using FluentPatterns.Library;

namespace ChainOfResponsability.ConsoleApp
{
  public interface IChainCommand : ICommand, ILink<IChainCommand>
  {
  }
}