using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluentPatterns.Library.Tests
{
  [TestClass]
  public class StateManagerBuilderTests
  {
    [TestMethod]
    public void Calling_Build_on_an_empty_StateManagerBuilder_should_throw()
    {
      var chain = new StateManagerBuilder();

      chain.Invoking(c => c.Build())
           .ShouldThrow<Exception>();
    }

    [TestMethod]
    public void Calling_Build_should_create_states_throw()
    {
      var firstState = new Mock<State1>();
      var secondState = new Mock<State2>();

      var chain = new StateManagerBuilder()
        .RegisterState(() => firstState.Object)
        .RegisterState(() => secondState.Object)
        .Build();

      firstState.Verify();
      secondState.Verify();
    }

    public class State1 : State
    {
      public override void OnExitState()
      {
        throw new NotImplementedException();
      }

      public override void OnEnterState(object parameter)
      {
        throw new NotImplementedException();
      }
    }

    public class State2 : State
    {
      public override void OnExitState()
      {
        throw new NotImplementedException();
      }

      public override void OnEnterState(object parameter)
      {
        throw new NotImplementedException();
      }
    }
  }
}