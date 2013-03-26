using System;

namespace VisitorConsoelApp.Validator
{
  public class IntValidation : IValidation
  {
    private readonly Func<int, bool> _rule;

    public IntValidation(Func<int, bool> rule)
    {
      _rule = rule;
    }

    public Exception Exception
    {
      get { return new ArgumentOutOfRangeException(); }
    }

    public void Validate(object obj)
    {
      if (!_rule((int)obj)) throw Exception;
    }
  }
}