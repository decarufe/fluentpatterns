namespace VisitorConsoelApp.Validator
{
  public class ValidatorParam
  {
    private readonly int _intValue;
    private readonly string _stringValue;

    public ValidatorParam(int intValue, string stringValue)
    {
      _intValue = intValue;
      _stringValue = stringValue;
    }

    public int IntValue
    {
      get { return _intValue; }
    }

    public string StringValue
    {
      get { return _stringValue; }
    }
  }
}