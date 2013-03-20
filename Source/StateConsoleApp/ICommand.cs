using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainOfResponsability;

namespace StateConsoleApp
{
  public interface ICommand
  {
    void Execute();
  }
}
