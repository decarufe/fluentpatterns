using FluentPatterns.Library;

namespace StateConsoleApp
{
  public class StopState : State
  {
    public override void OnExitState()
    {
      Logger.LogInfo("Exit Stop State");
    }

    public override void OnEnterState(object parameter)
    {
      Logger.LogInfo("Enter Stop State");
    }
  }
}