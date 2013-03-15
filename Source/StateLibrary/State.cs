using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateLibrary
{
  public abstract class State
  {
    public StateManager StateManager { get; set; }

    public abstract void OnExitState();

    public abstract void OnEnterState(object parameter);

    protected void ChangeState<T>(object parameter = null) where T : State, new()
    {
      StateManager.ChangeState<T>(parameter);
    }
  }
}
