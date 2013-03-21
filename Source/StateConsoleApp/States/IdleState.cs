using System;
using System.Collections.Generic;
using System.Linq;
using CommandPattern;
using StateLibrary;

namespace StateConsoleApp
{
  public class IdleState : State
  {
    private readonly CommandManager _commandManager;

    public IdleState(CommandManager commandManager)
    {
      _commandManager = commandManager;
    }

    public override void OnExitState()
    {
      Logger.LogInfo("Exit Idle State");
    }

    public override void OnEnterState(object parameter)
    {
      Logger.LogInfo("Enter Idle State");
      Console.Write("Type run or stop: ");
      string response = Console.ReadLine() ?? String.Empty;
      try
      {
        _commandManager.ExecuteCommand(response.ToLower());
      }
      catch (KeyNotFoundException)
      {
        StateManager.ChangeState<InvalidState>("Invalid Command");
      }
    }
  }
}