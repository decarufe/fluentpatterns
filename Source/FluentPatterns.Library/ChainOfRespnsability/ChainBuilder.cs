using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentPatterns.Library
{
    public class ChainBuilder<T> : IBuild<T> where T: ILink<T>
    {
      private readonly List<T> _hanlders = new List<T>();

      public ChainBuilder<T> Add<THandler>() where THandler : T, new()
      {
        return Add(() => new THandler());
      }

      public ChainBuilder<T> Add<THandler>(Func<THandler> instance) where THandler : T
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
}
