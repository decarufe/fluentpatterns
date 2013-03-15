using System;
using System.Collections.Generic;
using System.Linq;

namespace StateLibrary
{
  public class StateManagerBuilder
  {
    private List<State> _states = new List<State>(); 

    public StateManagerBuilder RegisterState<T>(Func<T> state) where T : State
    {
      _states.Add(state());
      return this;
    }

    public StateManager Start<T>()
    {
      var stateManager = new StateManager(_states);
      var startState = _states.Single(t => t is T);
      startState.StateManager = stateManager;
      startState.OnEnterState(null);
      return stateManager;
    }
  }
}