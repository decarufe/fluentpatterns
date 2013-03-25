using System;
using System.Collections.Generic;
using System.Linq;

namespace StateLibrary
{
  public class StateManagerBuild : IBuild<StateManager>
  {
    private readonly List<State> _states = new List<State>(); 

    public StateManagerBuild RegisterState<T>(Func<T> state) where T : State
    {
      _states.Add(state());
      return this;
    }

    public StateManager Build()
    {
      return new StateManager(_states);
    }
  }
}