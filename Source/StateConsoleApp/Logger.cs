using System;

namespace StateConsoleApp
{
  public static class Logger
  {
    public static void LogInfo(string message)
    {
      Log(message, ConsoleColor.DarkGray);
    }

    public static void LogError(string message)
    {
      Log(message, ConsoleColor.Red);
    }

    private static void Log(string message, ConsoleColor color)
    {
      var keepColor = Console.ForegroundColor;
      Console.ForegroundColor = color;
      Console.WriteLine(message);
      Console.ForegroundColor = keepColor;
    }
  }
}