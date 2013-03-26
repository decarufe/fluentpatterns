using System;

namespace VisitorConsoelApp.Validator
{
  public class StringValidation : IValidation
  {
    private Func<string, bool> _rule;

    public StringValidation(Func<string, bool> rule)
    {
      _rule = rule;
    }

    public void Validate(object obj)
    {
      if (!_rule((string)obj)) throw new Exception(string.Format("String validation failed for {0}", obj));
    }
  }
}