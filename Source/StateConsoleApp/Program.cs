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
      var stateManager = new StateManagerBuilder()
        .RegisterState(() => new IdleState())
        .RegisterState(() => new RunningState())
        .RegisterState(() => new InvalidState())
        .RegisterState(() => new StopState())
        .Start<IdleState>();

      Console.WriteLine();
      stateManager.Terminate();
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
  }
}
