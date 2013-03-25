using System;
using System.Collections.Generic;
using System.Linq;
using CommandPattern;
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
    }
  }
}