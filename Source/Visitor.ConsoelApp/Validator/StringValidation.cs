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

    public Exception Exception
    {
      get { return new FormatException(); }
    }

    public void Validate(object obj)
    {
      if (!_rule((string)obj)) throw Exception;
    }
  }
}