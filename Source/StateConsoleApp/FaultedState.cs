using System;
using StateLibrary;

namespace StateConsoleApp
{
  public class FaultedState : State
  {
    public override void OnExitState()
    {
      Console.WriteLine("Exit Faulted State");
    }

    public override void OnEnterState(object parameter)
    {
      Console.WriteLine("Enter Faulted State");
    }
  }
}