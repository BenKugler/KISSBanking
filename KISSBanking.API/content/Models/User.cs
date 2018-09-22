using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSBanking.API.Models
{
  /// <summary>
  /// Class that represents a user
  /// </summary>
  public class User
  {
    public string mUsername;
    public string mPassword;
    private readonly Account mcAccounts;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="username">Username of new user</param>
    /// <param name="password">Password of new user</param>
    public User(string username, string password)
    {
      mUsername = username;
      mPassword = password;
      mcAccounts = new Account();
    }

    /// <summary>
    /// Gets the users account
    /// </summary>
    /// <returns>USers account</returns>
    public Account GetUserAccount ()
    {
      return mcAccounts;
    }
  }
}
