using System;
using System.Windows.Input;
using FluentPatterns.Library;

namespace ChainOfResponsability.ConsoleApp
{
  public abstract class ChainCommand : ICommand, ILink<ChainCommand>
  {
    public abstract void Execute(object parameter);

    protected virtual void OnCanExecuteChanged()
    {
      EventHandler handler = CanExecuteChanged;
      if (handler != null) handler(this, EventArgs.Empty);
    }

    public virtual event EventHandler CanExecuteChanged;

    public virtual bool CanExecute(object parameter)
    {
      return true;
    }

    public virtual ChainCommand NextInChain { get; set; }
  }
}