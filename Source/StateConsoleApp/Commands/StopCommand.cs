using CommandPattern;
using StateLibrary;

namespace StateConsoleApp
{
  public class StopCommand : ICommand
  {
    private readonly StateManager _stateManager;

    public StopCommand(StateManager stateManager)
    {
      _stateManager = stateManager;
    }

    public void Execute()
    {
      _stateManager.ChangeState<StopState>();
    }
  }
}