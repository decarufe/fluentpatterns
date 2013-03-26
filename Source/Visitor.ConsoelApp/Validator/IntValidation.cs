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

    public void Validate(object obj)
    {
      if (!_rule((int)obj)) throw new Exception(string.Format("Int validation failed for {0}", obj));
    }
  }
}