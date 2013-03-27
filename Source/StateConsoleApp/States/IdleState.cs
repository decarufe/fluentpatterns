using FluentPatterns.Library;

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
    }
  }
}