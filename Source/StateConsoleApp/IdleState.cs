using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateLibrary;

namespace StateConsoleApp
{
  public class IdleState : State
  {
    public override void OnExitState()
    {
      Console.WriteLine("Exit Idle State");
    }

    public override void OnEnterState(object parameter)
    {
      Console.WriteLine("Enter Idle State");
      Console.Write("Type run to start: ");
      string response = Console.ReadLine() ?? String.Empty;
      if (response.Equals("run", StringComparison.InvariantCultureIgnoreCase))
        StateManager.ChangeState<RunningState>();
      else
        StateManager.ChangeState<FaultedState>("Invalid Command");
    }
  }
}
