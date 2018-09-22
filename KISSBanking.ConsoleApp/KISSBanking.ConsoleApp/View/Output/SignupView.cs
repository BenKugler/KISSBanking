using KISSBanking.ConsoleApp.View.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISSBanking.ConsoleApp.Output.View
{
  /// <summary>
  /// 
  /// </summary>
  class SignupView
  {
    /// <summary>
    /// Console output for main menu header
    /// </summary>
    public static void MainMenuHeader()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "New user", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, "Signup with KISS Banking", true);
    }

    /// <summary>
    /// Console output for main menu selection
    /// </summary>
    public static void MainMenuSelections()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "1 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Enter new credentials", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "2 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Back to home", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "0 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Exit", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, "> ", false);
    }

    /// <summary>
    /// Console output for username prompt
    /// </summary>
    public static void Username()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Enter a username", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }

    /// <summary>
    /// Console output for password prompt
    /// </summary>
    public static void Password()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Enter a password", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }

    /// <summary>
    /// Console output for password prompt
    /// </summary>
    public static void VerifyPassword()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Verify new password", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }
  }
}
