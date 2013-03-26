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

    public void Validate(string value)
    {
      Console.WriteLine("String validation");
      if (!_rule(value)) throw new Exception(string.Format("String validation failed for {0}", value));
    }
  }
}