using System;
using Microsoft.CSharp.RuntimeBinder;

namespace Model.Visitor
{
  /// <summary>
  ///   This abstract class provides the baseline to design generic dynamic visitors. These concrete visitors must
  ///   implement a Visit method that accepts an argument of the type to visit.
  /// </summary>
  /// <seealso cref="VisitorExtensions.Accept(object, Visitor)" />
  /// <seealso cref="VisitorExtensions.Accept(object, Visitor, object)" />
  /// <remarks>
  ///   The code from this class was inspired by the
  ///   <a href="http://www.codeproject.com/Articles/112944/Polymorphic-Extension-Visitor-with-C">
  ///     polymorphic extension
  ///     visitor
  ///   </a>
  ///   .
  /// </remarks>
  public class Visitor
  {
    /// <summary>
    ///   Creates the visitor.
    /// </summary>
    /// <param name="rethrow">
    ///   True, if an exception should be thrown when no matching Visit method is found;
    ///   false, if a default object should be returned when no matching Visit method is found.
    /// </param>
    protected Visitor(bool rethrow)
    {
      Rethrow = rethrow;
    }

    /// <summary>
    ///   Controls if a missing Visit method throws an exception (true) or if it executes the default fallback mechanism
    ///   and returns a default object (false).
    /// </summary>
    public bool Rethrow { get; private set; }

    /// <summary>
    ///   This method is used as a fallback mechanism should the visitor fail to provide a valid Visit method. It is
    ///   automatically invoked by the <see cref="VisitorExtensions.Accept(object, Visitor)" />
    ///   method whenever an exception is caught for a visitor that does not rethrow exceptions.
    /// </summary>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <remarks>This method can be overridden to wrap the caught exception in other, more significant objects.</remarks>
    public virtual void Fallback(object visitable, Exception exception)
    {
    }

    /// <summary>
    ///   This method is used to create fallback objects should the visitor fail to provide a valid Visit method. It
    ///   is automatically invoked by the <see cref="VisitorExtensions.Accept(object, Visitor, object)" />
    ///   method whenever an exception is caught for a visitor that does not rethrow exceptions.
    /// </summary>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <param name="parameter1">The first parameter sent to the Visit method.</param>
    /// <remarks>This method can be overridden to wrap the caught exception in other, more significant objects.</remarks>
    public virtual void Fallback(object visitable, Exception exception, object parameter1)
    {
      Fallback(visitable, exception);
    }

    public void Fallback(object visitable, Exception exception, object parameter1, object parameter2)
    {
      Fallback(visitable, exception, parameter1);
    }
  }
}