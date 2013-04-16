using System;
using System.Collections.Generic;
using System.Linq;
using FluentPatterns.Library;

namespace StateConsoleApp
{
  static class Program
  {
    private static CommandManager _commandManager;
    private static StateManager _stateManager;

    static void Main()
    {
      _stateManager = new StateManagerBuilder()
        .RegisterState(() => new IdleState())
        .RegisterState(() => new RunningState())
        .RegisterState(() => new InvalidState())
        .RegisterState(() => new StopState())
        .Build();

      _stateManager.StateChanged += StateManagerOnStateChanged;

      _commandManager = new CommandManager()
        .Register("run", new RunCommand(_stateManager))
        .Register("stop", new StopCommand(_stateManager));

      _stateManager.ChangeState<IdleState>();

      Console.WriteLine();
      _stateManager.Terminate();
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }

    private static void StateManagerOnStateChanged(object sender, StateChangedEventArgs args)
    {
      if (args.NewState is IdleState)
      {
        Console.Write("Type run or stop: ");
        string response = Console.ReadLine() ?? String.Empty;
        try
        {
          _commandManager.ExecuteCommand(response.ToLower());
        }
        catch (KeyNotFoundException)
        {
          _stateManager.ChangeState<InvalidState>("Invalid Command");
        }
      }
    }
  }
}
