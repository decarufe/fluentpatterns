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

    public virtual void OnTerminate()
    {

    }

    public virtual void OnInitialize(object parameter)
    {

    }

    protected void ChangeState<T>(object parameter = null) where T : State, new()
    {
      StateManager.ChangeState<T>(parameter);
    }
  }
}
