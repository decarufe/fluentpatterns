using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluentPatterns.Library.Tests
{
  [TestClass]
  public class ChainOfResponsabilityTests
  {
    [TestMethod]
    public void Calling_Build_on_an_empty_chain_should_throw()
    {
      var chain = new ChainBuilder<Link>();

      chain.Invoking(c => c.Build())
           .ShouldThrow<Exception>();
    }

    [TestMethod]
    public void A_single_link_chain_should_not_have_next()
    {
      var chain = new ChainBuilder<Link>()
        .Add<LinkImpl>()
        .Build();

      chain.NextInChain.Should().BeNull();
    }
    
    [TestMethod]
    public void A_multi_link_chain_should_have_next()
    {
      var chain = new ChainBuilder<Link>()
        .Add<LinkImpl>()
        .Add<LinkImpl>()
        .Build();

      chain.NextInChain.Should().BeOfType<LinkImpl>();
    }

    [TestMethod]
    public void A_chain_built_from_lambda_should_call_custom_constructor()
    {
      var link = new Mock<LinkCustom>();

      var chain = new ChainBuilder<Link>()
        .Add(() => link.Object.Create())
        .Build();

      link.Verify(m => m.Create());
    }
  }

  public class Link : ILink<Link>
  {
    public virtual Link NextInChain { get; set; }
  }

  public class LinkImpl : Link
  {
  }

  public abstract class LinkCustom : Link
  {
    public abstract LinkCustom Create();
  }
}