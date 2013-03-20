using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateLibrary
{
  public class StateManager
  {
    private Dictionary<Type, State> _states = new Dictionary<Type, State>(); 
    private State mCurrentState;

    public StateManager(IEnumerable<State> states)
    {
      foreach (var state in states)
      {
        _states.Add(state.GetType(), state);
      }
    }

    public State ChangeState<T>(object parameter = null) where T : State
    {
      Terminate();

      mCurrentState = _states[typeof(T)];
      mCurrentState.StateManager = this;
      mCurrentState.OnEnterState(parameter);

      return null;
    }

    public void Terminate()
    {
      if (mCurrentState != null)
      {
        mCurrentState.OnExitState();
        mCurrentState = null;
      }
    }

    public bool CurrentStateIs<T>()
    {
      return mCurrentState is T;
    }
  }
}
