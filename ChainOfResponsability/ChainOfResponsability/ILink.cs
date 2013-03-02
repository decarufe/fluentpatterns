namespace ChainOfResponsability
{
  public interface ILink<T> where T : ILink<T>
  {
    T NextInChain { get; set; }
  }
}