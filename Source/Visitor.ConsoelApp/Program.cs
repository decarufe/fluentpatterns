using System;
using System.Collections.Generic;
using System.Linq;
using Model.Visitor;
using VisitorConsoelApp.Validator;

namespace VisitorConsoelApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var validations = new List<IValidation>
      {
        new IntValidation(i => i < 10), 
        new StringValidation(s => s.Length < 10)
      };

      var validatorParam = new ValidatorParam(10, "0123456789");
      var validatorVisitor = new ValidatorVisitor(true);

      foreach (var validation in validations)
      {
        validation.Accept(validatorVisitor, validatorParam);
      }

      Console.ReadLine();
    }
  }
}
