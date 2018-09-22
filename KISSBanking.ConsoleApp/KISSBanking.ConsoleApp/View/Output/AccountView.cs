using KISSBanking.ConsoleApp.Models.Responses;
using KISSBanking.ConsoleApp.View.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISSBanking.ConsoleApp.Output.View
{
  /// <summary>
  /// 
  /// </summary>
  class AccountView
  {
    /// <summary>
    /// Console output for main menu header
    /// </summary>
    public static void MainMenuHeader(string username)
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Hello " + username + ", welcome to KISS Banking", true);
    }

    /// <summary>
    /// Console output for main menu selection
    /// </summary>
    public static void MainMenuSelections()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "1 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Make Transaction", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "2 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "View Transactions", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "3 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Refresh", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "4 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Logout", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "0 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Logout & Exit", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, "> ", false);
    }

    /// <summary>
    /// Console output for transaction type menu
    /// </summary>
    public static void TransactionTypeMenu()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Choose Transaction Type", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "1 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Withdraw", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "2 ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Deposit", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Gray, "> ", false);
    }

    /// <summary>
    ///  Console output for account balance
    /// </summary>
    /// <param name="amount">Account balance</param>
    public static void AccountAmount(string amount)
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Balance - ", false);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "$" + amount, true);
    }

    /// <summary>
    ///  Console output for transaction amount
    /// </summary>
    public static void TransactionAmount()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Transaction Amount", true);
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "> ", false);
    }

    /// <summary>
    ///  Console output for transaction history
    /// </summary>
    /// <param name="transactions">List of transaction history</param>
    public static void ViewTransactions(List<Transaction> transactions)
    {
      if (transactions.Count == 0)
      {
        ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "You haven't made any transactions yet", true);
      }
      else
      {
        ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Transaction Type".PadRight(20) + "Amount", true);
        foreach (Transaction transaction in transactions)
        {
          if (transaction.TransactionType == Transaction.Type.DEPOSIT)
          {
            ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "DEPOSIT".PadRight(20), false);
          }
          else
          {
            ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "WITHDRAW".PadRight(20), false);
          }
          ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, transaction.Amount.mBalance.ToString(), true);
        }
      }
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Return...", false);
    }
  }
}
