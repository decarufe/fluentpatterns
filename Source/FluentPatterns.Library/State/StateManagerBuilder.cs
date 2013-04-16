using System;
using System.Collections.Generic;

namespace FluentPatterns.Library
{
  public class StateManagerBuilder : IBuild<StateManager>
  {
    private readonly List<State> _states = new List<State>(); 

    public StateManagerBuilder RegisterState<T>(Func<T> state) where T : State
    {
      _states.Add(state());
      return this;
    }

    public StateManager Build()
    {
      if (_states.Count < 2) throw new InvalidOperationException("At least 2 statesare required to build a state manager");
      return new StateManager(_states);
    }
  }
}