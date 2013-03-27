using System;
using System.Threading;
using FluentPatterns.Library;

namespace StateConsoleApp
{
  public class RunningState : State
  {
    public override void OnExitState()
    {
      Logger.LogInfo("Exit Running State");
    }

    public override void OnEnterState(object parameter)
    {
      Logger.LogInfo("Enter Running State");
      Console.Write("Running");
      for (int i = 0; i < 10; i++)
      {
        Thread.Sleep(100);
        Console.Write(".");
      }
      Console.WriteLine();
      StateManager.ChangeState<IdleState>();
    }
  }
}