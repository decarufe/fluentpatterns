﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsability
{
    public class Chain<T> where T: ILink<T>
    {
      private readonly List<T> _hanlders = new List<T>();

      public Chain<T> Add<THandler>() where THandler : T, new()
      {
        return Add<THandler>(() => new THandler());
      }

      public Chain<T> Add<THandler>(Func<THandler> instance) where THandler : T
      {
        var handler = instance();
        if (_hanlders.Count > 0) _hanlders.Last().NextInChain = handler;
        _hanlders.Add(handler);
        return this;
      }

      public T Build()
      {
        return _hanlders.First();
      }
    }

  public interface ILink<T> where T : ILink<T>
  {
    T NextInChain { get; set; }
  }
}
