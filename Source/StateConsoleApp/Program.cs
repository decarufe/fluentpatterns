using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern;
using StateLibrary;

namespace StateConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var commandManager = new CommandManager();
      var stateManager = new StateManagerBuilder()
        .RegisterState(() => new IdleState(commandManager))
        .RegisterState(() => new RunningState())
        .RegisterState(() => new InvalidState())
        .RegisterState(() => new StopState())
        .Build();

      commandManager.Register("run", new RunCommand(stateManager));
      commandManager.Register("stop", new StopCommand(stateManager));

      stateManager.ChangeState<IdleState>();

      Console.WriteLine();
      stateManager.Terminate();
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
  }
}
