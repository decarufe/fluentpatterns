using System;
using System.Linq;
using StateLibrary;

namespace StateConsoleApp
{
  public class IdleState : State
  {
    public override void OnExitState()
    {
      Logger.LogInfo("Exit Idle State");
    }

    public override void OnEnterState(object parameter)
    {
      Logger.LogInfo("Enter Idle State");
      Console.Write("Type run or stop: ");
      string response = Console.ReadLine() ?? String.Empty;
      if (response.Equals("run", StringComparison.InvariantCultureIgnoreCase))
        StateManager.ChangeState<RunningState>();
      else if (response.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
        StateManager.ChangeState<StopState>();
      else
        StateManager.ChangeState<InvalidState>("Invalid Command");
    }
  }
}