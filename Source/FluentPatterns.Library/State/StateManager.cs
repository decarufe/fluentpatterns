using System;
using System.Collections.Generic;

namespace FluentPatterns.Library
{
  public class StateManager
  {
    private readonly Dictionary<Type, State> _states = new Dictionary<Type, State>(); 
    private State _currentState;

    public event EventHandler<StateChangedEventArgs> StateChanged;

    protected virtual void OnStateChanged(StateChangedEventArgs e)
    {
      EventHandler<StateChangedEventArgs> handler = StateChanged;
      if (handler != null) handler(this, e);
    }

    public StateManager(IEnumerable<KeyValuePair<Type, State>> states)
    {
      foreach (var state in states)
      {
        _states.Add(state.Key, state.Value);
      }
    }

    public void ChangeState<T>(object parameter = null) where T : State
    {
      State lastState = _currentState;
      Terminate();

      _currentState = _states[typeof(T)];
      _currentState.StateManager = this;
      _currentState.OnEnterState(parameter);

      OnStateChanged(new StateChangedEventArgs(lastState, _currentState));
    }

    public void Terminate()
    {
      if (_currentState != null)
      {
        _currentState.OnExitState();
        _currentState = null;
      }
    }
  }
}
