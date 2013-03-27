using System;
using System.Windows.Input;
using FluentPatterns.Library;

namespace StateConsoleApp
{
  public class RunCommand : ICommand
  {
    private readonly StateManager _stateManager;

    public RunCommand(StateManager stateManager)
    {
      _stateManager = stateManager;
    }

    public void Execute(object param)
    {
      _stateManager.ChangeState<RunningState>();
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public event EventHandler CanExecuteChanged;

    protected virtual void OnCanExecuteChanged()
    {
      EventHandler handler = CanExecuteChanged;
      if (handler != null) handler(this, EventArgs.Empty);
    }
  }
}