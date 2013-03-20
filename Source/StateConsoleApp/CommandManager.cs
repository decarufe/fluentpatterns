using System.Collections.Generic;

namespace StateConsoleApp
{
  public class CommandManager
  {
    private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

    public void Register(string name, ICommand command)
    {
      _commands.Add(name, command);
    }

    public void ExecuteCommand(string name)
    {
      _commands[name].Execute();
    }
  }
}