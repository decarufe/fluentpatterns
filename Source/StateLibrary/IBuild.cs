namespace StateLibrary
{
  public interface IBuild<out T>
  {
    T Build();
  }
}