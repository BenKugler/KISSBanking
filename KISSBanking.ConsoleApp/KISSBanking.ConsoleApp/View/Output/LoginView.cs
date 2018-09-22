using KISSBanking.ConsoleApp.View.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISSBanking.ConsoleApp.Output.View
{
  /// <summary>
  /// 
  /// </summary>
  class LoginView
  {
    /// <summary>
    /// Console output for main menu header
    /// </summary>
    public static void MainMenuHeader()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Welcome to KISSBanking", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, " Keep It Simple Stupid Banking", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, " Welcome to KISS banking, worlds simplest banking, time limited accounts and no encryption. Banking done right.", true);
    }

    /// <summary>
    /// Console output for main menu selection
    /// </summary>
    public static void MainMenuSelections ()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "1 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Login", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "2 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Signup", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "0 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Exit", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, "> ", false);
    }

    /// <summary>
    /// Console output for username prompt
    /// </summary>
    public static void Username ()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Enter your username", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }

    /// <summary>
    /// Console output for password prompt
    /// </summary>
    public static void Password()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Enter your password", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }
  }
}
