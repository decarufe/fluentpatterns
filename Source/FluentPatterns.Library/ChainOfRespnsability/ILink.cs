namespace FluentPatterns.Library
{
  public interface ILink<T> where T : ILink<T>
  {
    T NextInChain { get; set; }
  }
}