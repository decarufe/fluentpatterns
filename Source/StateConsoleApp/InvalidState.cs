using System;
using StateLibrary;

namespace StateConsoleApp
{
  public class InvalidState : State
  {
    public override void OnExitState()
    {
      Logger.LogInfo("Exit Faulted State");
    }

    public override void OnEnterState(object parameter)
    {
      Logger.LogInfo("Enter Faulted State");
      var message = (string)parameter;
      Logger.LogError(message);
      StateManager.ChangeState<IdleState>();
    }
  }
}