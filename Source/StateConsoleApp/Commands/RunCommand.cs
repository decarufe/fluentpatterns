﻿using CommandPattern;
using StateLibrary;

namespace StateConsoleApp
{
  public class RunCommand : ICommand
  {
    private readonly StateManager _stateManager;

    public RunCommand(StateManager stateManager)
    {
      _stateManager = stateManager;
    }

    public void Execute()
    {
      _stateManager.ChangeState<RunningState>();
    }
  }
}