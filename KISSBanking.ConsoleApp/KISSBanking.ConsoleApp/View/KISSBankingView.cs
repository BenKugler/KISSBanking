using KISSBanking.ConsoleApp.Models.Responses;
using KISSBanking.ConsoleApp.Output.View;
using KISSBanking.ConsoleApp.View.Interfaces;
using KISSBanking.ConsoleApp.View.Output;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KISSBanking.ConsoleApp.View
{
  /// <summary>
  /// View to KISS Banking Console app
  /// </summary>
  public class KISSBankingView : IView
  {
    const int EXIT = 0;

    private Account mcAccount;
    private string mError;

    public event Func<string, string, Task<Tuple<bool, string>>> LoginEventRaised;
    public event Func<string, string, string, Task<Tuple<bool, string>>> SignupEventRaised;
    public event Func<Transaction, Task<bool>> TransactionEventRaised;
    public event Func<Task<Account>> GetAccountEventRaised;
    public event Func<string> GetUsernameEventRaised;
    public event Func<bool> LogoutEventRaised;

    #region Home
    /// <summary>
    /// Handles outputing front end information for Home
    /// </summary>
    public void Home()
    {
      const int LOGIN = 1;
      const int SIGNUP = 2;
      bool bValidLoginResult = true;

      int selection;
      List<int> rules = new List<int> { EXIT, LOGIN, SIGNUP };

      while (true)
      {
        Console.Title = "KISS Banking - Home";
        Console.Clear();
        LoginView.MainMenuHeader();

        if (!bValidLoginResult)
        {
          ConsoleHelper.ConsoleWriteColor(ConsoleColor.Red, mError, true);
          bValidLoginResult = true;
        }

        selection = ConsoleHelper.ValidateSelection(
          LoginView.MainMenuSelections, rules
          );

        switch (selection)
        {
          case LOGIN:
            bValidLoginResult = Login();
            break;
          case SIGNUP:
            Signup();
            break;
          case EXIT:
            Exit();
            break;
        }
      }
    }

    /// <summary>
    /// Handles login sequence
    /// </summary>
    private bool Login()
    {
      string password;
      string username;
      bool bResult;
      Task<Tuple<bool, string>> loginResult = null;

      Console.Title = "KISS Banking - Login";
      Console.Clear();

      LoginView.Username();
      username = Console.ReadLine();

      LoginView.Password();
      password = ConsoleHelper.GetConsolePassword();

      loginResult = LoginEventRaised.Invoke(username, password);
      loginResult.Wait();
      bResult = loginResult.Result.Item1;
      if (loginResult.Result.Item1)
      {
        Account();
      }
      else
      {
        mError = loginResult.Result.Item2;
      }

      return bResult;
    }

    #endregion

    #region Sign up 
    /// <summary>
    /// Handles signup sequence
    /// </summary>
    private void Signup()
    {
      const int CREDS = 1;
      const int BACK = 2;
      int selection;

      List<int> rules = new List<int> { EXIT, CREDS, BACK };

      Console.Title = "KISS Banking - Signup";
      SignupView.MainMenuHeader();

      selection = ConsoleHelper.ValidateSelection(
        SignupView.MainMenuSelections, rules
        );

      switch (selection)
      {
        case CREDS:
          CreateNewUser();
          break;
        case BACK:
          break;
        case EXIT:

          break;
      }
    }

    /// <summary>
    /// Handles new user creation fields
    /// </summary>
    private void CreateNewUser()
    {
      string username;
      string pass;
      string verifyPass;
      Task<Tuple<bool, string>> newUserResult = null;

      Console.Clear();

      SignupView.Username();
      username = Console.ReadLine();

      SignupView.Password();
      pass = ConsoleHelper.GetConsolePassword();

      SignupView.VerifyPassword();
      verifyPass = ConsoleHelper.GetConsolePassword();

      newUserResult = Task.Run(()
        => SignupEventRaised.Invoke(username, pass, verifyPass));

      newUserResult.Wait();

      Console.Clear();

      if (!newUserResult.Result.Item1)
      {
        ConsoleHelper.ConsoleWriteColor(
          ConsoleColor.Red, newUserResult.Result.Item2, true
          );
        Signup();
      }
    }

    #endregion


    #region Account

    /// <summary>
    /// Handles Account information
    /// </summary>
    private void Account()
    {
      const int MAKE_TRANSACTION = 1;
      const int VIEW_TRANSACTION = 2;
      const int REFRESH = 3;
      const int LOGOUT = 4;
      const int LOGOUT_EXIT = 0;

      int selection;
      bool bLoggedIn = true;

      List<int> rules = new List<int>
      { MAKE_TRANSACTION, VIEW_TRANSACTION, REFRESH, LOGOUT, LOGOUT_EXIT };

      Console.Title = "KISS Banking - Account";

      while (bLoggedIn)
      {
        mcAccount = Task.Run(() => GetAccountEventRaised.Invoke()).Result;

        Console.Clear();

        AccountView.MainMenuHeader(GetUsernameEventRaised.Invoke());
        AccountView.AccountAmount(mcAccount.mcAccountBalance.mBalance.ToString());

        selection = ConsoleHelper.ValidateSelection(
          AccountView.MainMenuSelections, rules
          );

        switch (selection)
        {
          case MAKE_TRANSACTION:
            MakeTransaction();
            break;
          case VIEW_TRANSACTION:
            DisplayTransactions();
            break;
          case REFRESH:
            break;
          case LOGOUT:
            Logout();
            bLoggedIn = false;
            break;
          case LOGOUT_EXIT:
            bLoggedIn = false;
            Exit();
            break;
        }
      }
    }

    /// <summary>
    /// Handles new transactions
    /// </summary>
    private void MakeTransaction()
    {
      const int WITHDRAW = 1;
      const int DEPOSIT = 2;

      Transaction newTransaction = new Transaction();
      int selection;
      decimal transferAmount;
      bool bValidDecimal = true;
      List<int> rules = new List<int> { WITHDRAW, DEPOSIT };

      Console.Clear();
      AccountView.AccountAmount(mcAccount.mcAccountBalance.mBalance.ToString());

      selection = ConsoleHelper.ValidateSelection(AccountView.TransactionTypeMenu, rules);

      if (selection == WITHDRAW)
      {
        newTransaction.TransactionType = Transaction.Type.WITHDRAW;
      }
      else
      {
        newTransaction.TransactionType = Transaction.Type.DEPOSIT;
      }

      do
      {
        Console.Clear();
        if (!bValidDecimal)
        {
          ConsoleHelper.ConsoleWriteColor(ConsoleColor.Red, "Invalid Amount, must be a decimal number", true);
        }
        AccountView.TransactionAmount();
      } while (!(bValidDecimal = decimal.TryParse(Console.ReadLine(), out transferAmount)));

      newTransaction.Amount = new Money(transferAmount);
      Task.Run(() => TransactionEventRaised.Invoke(newTransaction)).Wait();
    }

    /// <summary>
    /// Displays transaction history
    /// </summary>
    private void DisplayTransactions()
    {
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.White, "Transaction History", true);
      AccountView.AccountAmount(mcAccount.mcAccountBalance.mBalance.ToString());
      AccountView.ViewTransactions(mcAccount.mcTransactions);
      Console.ReadLine();
    }

    /// <summary>
    /// Logs user out
    /// </summary>
    private void Logout()
    {
      bool bLoggedOut = Task.Run(() => LogoutEventRaised.Invoke()).Result;
    }

    /// <summary>
    /// Exits program
    /// </summary>
    private void Exit()
    {
      Logout();
      ConsoleHelper.ConsoleWriteColor(ConsoleColor.Cyan, "Thanks for using KISS Banking", true);
      Environment.Exit(0);
    }

    #endregion
  }
}
