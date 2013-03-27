namespace FluentPatterns.Library
{
  public abstract class State
  {
    public StateManager StateManager { get; set; }

    public abstract void OnExitState();

    public abstract void OnEnterState(object parameter);
  }
}
