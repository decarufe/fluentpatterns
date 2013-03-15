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

    public State ChangeState<T>(object parameter = null) where T : State, new()
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

    public StateManager RegisterState<T>(Func<T> state) where T: State
    {
      _states.Add(typeof (T), state());
      return this;
    }

    public State Build()
    {
      var nullState = new NullState();
      nullState.StateManager = this;
      nullState.OnEnterState(null);
      return nullState;
    }
  }

  public class NullState : State
  {
    public override void OnExitState()
    {
      Console.WriteLine("Exit Null State");
    }

    public override void OnEnterState(object parameter)
    {
      Console.WriteLine("Enter Null State");
    }
  }
}
