using System;
using System.Threading;
using StateLibrary;

namespace StateConsoleApp
{
  public class RunningState : State
  {
    public override void OnExitState()
    {
      Console.WriteLine("Exit Running State");
    }

    public override void OnEnterState(object parameter)
    {
      Console.WriteLine("Enter Running State");
      Thread.Sleep(2000);
      StateManager.ChangeState<IdleState>();
    }
  }
}