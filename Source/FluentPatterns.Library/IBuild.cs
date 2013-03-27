namespace FluentPatterns.Library
{
  public interface IBuild<out T>
  {
    T Build();
  }
}