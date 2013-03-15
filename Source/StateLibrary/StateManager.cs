using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateLibrary
{
  public class StateManager
  {
    private State mCurrentState;

    public State ChangeState<T>(object parameter = null) where T : State, new()
    {
      Terminate();

      mCurrentState = Activator.CreateInstance<T>();
      mCurrentState.StateManager = this;
      mCurrentState.OnInitialize(parameter);

      return null;
    }

    public void Terminate()
    {
      if (mCurrentState != null)
      {
        mCurrentState.OnTerminate();
        mCurrentState = null;
      }
    }

    public bool CurrentStateIs<T>()
    {
      return mCurrentState is T;
    }
  }
}
