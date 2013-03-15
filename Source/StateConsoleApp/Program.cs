using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateLibrary;

namespace StateConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var state = new StateManager()
        .RegisterState(() => new IdleState())
        .RegisterState(() => new RunningState())
        .RegisterState(() => new FaultedState())
        .Build();

      state.StateManager.ChangeState<IdleState>();

      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
  }
}
