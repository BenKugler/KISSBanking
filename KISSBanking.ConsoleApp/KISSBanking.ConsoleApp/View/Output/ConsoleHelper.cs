using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace KISSBanking.ConsoleApp.View.Output
{
  /// <summary>
  /// Useful methods for console output
  /// </summary>
  public class ConsoleHelper
  {
    /// <summary>
    /// Colors output
    /// </summary>
    /// <param name="color">Output color</param>
    /// <param name="content">Output content</param>
    /// <param name="bNewLine">Whether a newline should be used</param>
    public static void ConsoleWriteColor(
      ConsoleColor color,
      string content,
      bool bNewLine)
    {
      Console.ForegroundColor = color;
      if (bNewLine)
      {
        Console.WriteLine(content);
      }
      else
      {
        Console.Write(content);
      }
      Console.ResetColor();
    }

    /// <summary>
    /// Gets the console secure password.
    /// </summary>
    /// <returns>String with user password</returns>
    public static string GetConsolePassword()
    {
      StringBuilder pass = new StringBuilder();
      ConsoleKeyInfo consoleKey;
      bool bTyping = true;

      while (bTyping)
      {
        consoleKey = Console.ReadKey(true);
        if (consoleKey.Key == ConsoleKey.Enter)
        {
          Console.WriteLine();
          bTyping = false;
        }
        else if (consoleKey.Key == ConsoleKey.Backspace)
        {
          if (pass.Length > 0)
          {
            Console.Write("\b\0\b");
            pass.Length--;
          }

          continue;
        }
        else
        {
          Console.Write('*');
          pass.Append(consoleKey.KeyChar);
        }
      }

      return pass.ToString();
    }

    /// <summary>
    /// Validates user selection for menu choices
    /// </summary>
    /// <param name="method">Choice menu method</param>
    /// <param name="errorMessage">Error message on wrong selection</param>
    /// <param name="rules">Menu rules matches</param>
    /// <returns>User selection</returns>
    public static int ValidateSelection(
      Action method,
      List<int> rules,
      string errorMessage = null)
    {
      string choice;
      bool result = true;
      int userChoiceInt = -1;

      if (errorMessage == null)
      {
        errorMessage = "Input must be a valid number";
      }

      do
      {
        if (!result)
        {
          ConsoleWriteColor(ConsoleColor.Red, errorMessage, true);
        }

        method.Invoke();

        choice = Console.ReadLine();
        result = int.TryParse(choice, out userChoiceInt);

        if (!rules.Contains(userChoiceInt))
        {
          result = false;
        }
        Console.Clear();
      } while (!result);

      return userChoiceInt;
    }
  }
}
