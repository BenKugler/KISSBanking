using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KISSBanking.ConsoleApp.Models.Responses;
using KISSBanking.ConsoleApp.Services;
using System.Linq;

namespace KISSBanking.ConsoleApp.Model
{
  /// <summary>
  /// Console Model, holds business logic and info
  /// </summary>
  public class KISSBankingModel
  {
    private int mCurrentUserId;
    private string mLoggedInUser;
    private RESTRequests mcRequests;

    /// <summary>
    /// Default constructor
    /// </summary>
    public KISSBankingModel()
    {
      mcRequests = new RESTRequests();
      mLoggedInUser = "";
      mCurrentUserId = -1;
    }

    /// <summary>
    /// Resets usre information
    /// </summary>
    public bool Logout ()
    {
      mLoggedInUser = "";
      mCurrentUserId = -1;
      return true;
    }

    /// <summary>
    /// Sends request to Signup user 
    /// </summary>
    /// <param name="username">New user username</param>
    /// <param name="pass">New user password</param>
    /// <param name="vertfyPass">New user verify password</param>
    /// <returns>Tuple task with boolean result and error message</returns>
    public async Task<Tuple<bool, string>> SignupAsync(string username, string pass, string vertfyPass)
    {
      Tuple<bool, string> userResult = null;
      User newUser;

      if (!pass.Equals(vertfyPass))
      {
        userResult = new Tuple<bool, string>(false, "Passwords didn't match");
      }
      else
      {
        newUser = new User(username, pass);
        userResult = await mcRequests.Post("/api/User/CreateUser", newUser);
      }
      return userResult;
    }

    /// <summary>
    /// Sends request to login user
    /// </summary>
    /// <param name="username">User username</param>
    /// <param name="pass">User password</param>
    /// <returns>Task with boolean result</returns>
    public async Task<Tuple<bool, string>> LoginAsync(string username, string pass)
    {
      Tuple<bool, string> userResult = null;
      User newUser;
      string message = null;
      newUser = new User(username, pass);
      userResult = await mcRequests.Post("/api/User/Login", newUser);

      if (userResult.Item1)
      {
        mCurrentUserId = int.Parse(userResult.Item2);
        mLoggedInUser = username;
      }
      else
      {
        message = userResult.Item2;
      }

      if (string.IsNullOrEmpty(userResult.Item2))
      {
        message = "Incorrect credentials";
      }

      return new Tuple<bool, string>(userResult.Item1, message);
    }

    /// <summary>
    /// Sends request to get current user's account
    /// </summary>
    /// <returns>Task with users account</returns>
    public async Task<Account> GetAccount ()
    {
      Account accountResult = null;
      accountResult = await mcRequests.Get<Account>("/api/Transaction/GetAccount/" + mCurrentUserId);
      return accountResult;
    }

    /// <summary>
    /// Gets the currently logged in username
    /// </summary>
    /// <returns>Username if user is logged int</returns>
    public string GetUsername() => mLoggedInUser;

    /// <summary>
    /// Sends request to make a transaction
    /// </summary>
    /// <param name="newTransaction">User's new transaction</param>
    /// <returns>Task with boolean result</returns>
    public async Task<bool> MakeTransactionAsync(Transaction newTransaction)
    {
      newTransaction.UserId = mCurrentUserId;
      await mcRequests.Post("/api/Transaction/CreateTransaction", newTransaction);
      return true;
    }
  }
}
