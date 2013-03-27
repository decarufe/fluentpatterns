﻿using System;

namespace ChainOfResponsability.ConsoleApp
{
  public class Command2 : IChainCommand
  {
    private readonly string _message;

    public Command2(string message)
    {
      _message = message;
    }

    public void Execute(object param)
    {
      System.Console.WriteLine("Command 2 " + _message);
      if (NextInChain != null) NextInChain.Execute(param);
    }

    public IChainCommand NextInChain { get; set; }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public event EventHandler CanExecuteChanged;

    protected virtual void OnCanExecuteChanged()
    {
      EventHandler handler = CanExecuteChanged;
      if (handler != null) handler(this, EventArgs.Empty);
    }
  }
}