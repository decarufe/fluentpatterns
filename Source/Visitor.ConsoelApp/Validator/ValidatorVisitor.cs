using System;
using Model.Visitor;

namespace VisitorConsoelApp.Validator
{
  public class ValidatorVisitor : Visitor
  {
    public ValidatorVisitor(bool rethrow) : base(rethrow)
    {
    }

    public void Visit(IntValidation validation, ValidatorParam value)
    {
      Console.WriteLine("Int validation");
      try
      {
        validation.Validate(value.IntValue);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    public void Visit(StringValidation validation, ValidatorParam value)
    {
      Console.WriteLine("String validation");
      try
      {
        validation.Validate(value.StringValue);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}