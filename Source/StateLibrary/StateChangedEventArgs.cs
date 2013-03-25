using System;

namespace StateLibrary
{
  public class StateChangedEventArgs : EventArgs
  {
    private readonly State _previousState;
    private readonly State _newState;

    public StateChangedEventArgs(State previousState, State newState)
    {
      _previousState = previousState;
      _newState = newState;
    }

    public State PreviousState
    {
      get { return _previousState; }
    }

    public State NewState
    {
      get { return _newState; }
    }
  }
}