using System;
using Microsoft.CSharp.RuntimeBinder;

namespace Model.Visitor
{
  /// <summary>
  ///   Provide extension methods used to implement the Visitor design pattern.
  /// </summary>
  public static class VisitorExtensions
  {
    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another.
    /// </summary>
    /// <typeparam name="T">The type of object to create.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains a single
    ///   parameter of the the type of object to visit, it will be called dynamically to produce the desired object.
    ///   If no such method exists in the <paramref name="visitorFactory" />, this method will throw an exception or
    ///   return a default object depending on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the
    ///   <paramref name="visitorFactory" /> to the type produced by this method and the factory was configured to rethrow
    ///   the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in
    ///   the provided <paramref name="visitorFactory" /> and the factory was configured to rethrow
    ///   the exception.
    /// </exception>
    public static T Accept<T>(this object visitable, VisitorFactory visitorFactory)
    {
      try
      {
        return ((dynamic)visitorFactory).Visit((dynamic)visitable);
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<T>(visitable, invalidCastException);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<T>(visitable, runtimeBinderException);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a VisitorFactory and produce
    ///   an object from the visitation of another by providing an extra parameter.
    /// </summary>
    /// <typeparam name="T">The type of object to create.</typeparam>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitorFactory">The visitor factory used to create the objects.</param>
    /// <param name="parameter1">The extra parameter.</param>
    /// <returns>
    ///   If <paramref name="visitorFactory" /> contains a Visit method whose signature contains one
    ///   parameter of the the type of object to visit and another corresponding to the extra parameter, it will be
    ///   called dynamically to produce the desired object. If no such method exists in the
    ///   <paramref name="visitorFactory" />, this method will throw an exception or return a default object depending
    ///   on how the factory was configured.
    /// </returns>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the
    ///   <paramref name="visitorFactory" /> to the type produced by this method and the factory was configured to rethrow
    ///   the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in
    ///   the provided <paramref name="visitorFactory" /> and the factory was configured to rethrow
    ///   the exception.
    /// </exception>
    public static T Accept<T>(this object visitable, VisitorFactory visitorFactory, object parameter1)
    {
      try
      {
        return ((dynamic)visitorFactory).Visit((dynamic)visitable, (dynamic)parameter1);
      }
      catch (InvalidCastException invalidCastException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<T>(visitable, invalidCastException, parameter1);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitorFactory.Rethrow)
        {
          throw;
        }
        return visitorFactory.CreateFallbackObject<T>(visitable, runtimeBinderException, parameter1);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a Visitor.
    /// </summary>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitor">The visitor used to visit the objects.</param>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the
    ///   <paramref name="visitor" /> to the type produced by this method and the visitor was configured to
    ///   rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in
    ///   the provided <paramref name="visitor" /> and the visitor was configured to rethrow the
    ///   exception.
    /// </exception>
    public static void Accept(this object visitable, Visitor visitor)
    {
      try
      {
        ((dynamic)visitor).Visit((dynamic)visitable);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable, runtimeBinderException);
      }
    }

    /// <summary>
    ///   Extension method providing the generic mechanism used to visit objects using a Visitor and an extra parameter.
    /// </summary>
    /// <param name="visitable">The object to visit.</param>
    /// <param name="visitor">The visitor used to visit the objects.</param>
    /// <param name="parameter1">The extra parameter.</param>
    /// <exception cref="System.InvalidCastException">
    ///   Failed to cast the object created by the
    ///   <paramref name="visitor" /> to the type produced by this method and the visitor was configured to
    ///   rethrow the exception.
    /// </exception>
    /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">
    ///   No matching Visit method exists in
    ///   the provided <paramref name="visitor" /> and the visitor was configured to rethrow the
    ///   exception.
    /// </exception>
    public static void Accept(this object visitable, Visitor visitor, object parameter1)
    {
      try
      {
        ((dynamic)visitor).Visit((dynamic)visitable, (dynamic)parameter1);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable, runtimeBinderException, parameter1);
      }
    }

    public static void Accept(this object visitable, Visitor visitor, object parameter1, object parameter2)
    {
      try
      {
        ((dynamic)visitor).Visit((dynamic)visitable, (dynamic)parameter1, (dynamic)parameter2);
      }
      catch (RuntimeBinderException runtimeBinderException)
      {
        if (visitor.Rethrow)
        {
          throw;
        }
        visitor.Fallback(visitable, runtimeBinderException, parameter1, parameter2);
      }
    }
  }
}