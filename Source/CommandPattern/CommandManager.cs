using System.Collections.Generic;
using System.Windows.Input;

namespace CommandPattern
{
  public class CommandManager
  {
    private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

    public CommandManager Register(string name, ICommand command)
    {
      _commands.Add(name, command);
      return this;
    }

    public void ExecuteCommand(string name)
    {
      _commands[name].Execute(null);
    }
  }
}