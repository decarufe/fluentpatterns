using System;
using System.Collections.Generic;
using System.Linq;

namespace StateLibrary
{
  public class StateManager
  {
    private readonly Dictionary<Type, State> _states = new Dictionary<Type, State>(); 
    private State _currentState;

    public StateManager(IEnumerable<State> states)
    {
      foreach (var state in states)
      {
        _states.Add(state.GetType(), state);
      }
    }

    public void ChangeState<T>(object parameter = null) where T : State
    {
      Terminate();

      _currentState = _states[typeof(T)];
      _currentState.StateManager = this;
      _currentState.OnEnterState(parameter);
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
