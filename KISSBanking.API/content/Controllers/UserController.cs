using System;
using Microsoft.AspNetCore.Mvc;
using KISSBanking.API.Models;
using System.Net;
using KISSBanking.API.Providers;
using System.Collections.Generic;
using System.Linq;

namespace KISSBanking.API.Controllers
{
  /// <summary>
  /// Controller routes for User operations
  /// </summary>
  [Route("api/[controller]")]
  public class UserController : Controller
  {
    private readonly IUserProvider mcUserProvider;

    /// <summary>
    /// Default constructor to create the User Provider
    /// </summary>
    /// <param name="userProvider">User provider from services</param>
    public UserController(IUserProvider userProvider)
    {
      this.mcUserProvider = userProvider;
    }

    /// Tries to creates a new user if credentials are valid
    /// </summary>
    /// <param name="newUser">New user object that is going to be added to the cached instance</param>
    /// <returns>Response code as well as a response message</returns>
    [HttpPost("[action]")]
    public IActionResult CreateUser([FromBody]User newUser)
    {
      List<User> user = mcUserProvider.GetUsers();
      var acc = new Account();
      Tuple<bool, string> response = CreateAccount(newUser);
      IActionResult resultCode = StatusCode((int)HttpStatusCode.BadRequest, response.Item2);

      if (response.Item1)
      {
        resultCode = StatusCode((int)HttpStatusCode.Accepted, response.Item2);
      }

      return resultCode;
    }

    /// <summary>
    /// Tries to find the specified user and returns a status code
    /// </summary>
    /// <param name="login">Credentials of user trying to login</param>
    /// <returns>Status code; 200 if found, if not 400</returns>
    [HttpPost("[action]")]
    public IActionResult Login([FromBody]User login)
    {
      IActionResult code = StatusCode((int)HttpStatusCode.BadRequest);
      int user;
      if ((user = FindUser(login)) != -1)
      {
        code = StatusCode((int)HttpStatusCode.Accepted, user);
      }
      return code;
    }

    /// <summary>
    ///  Creates a new user if username is unique
    /// </summary>
    /// <param name="newUser">New user credentials</param>
    /// <param name="userList">List of active users</param>
    /// <returns>bool - Whether opertation was a success; string - message from result</returns>
    private Tuple<bool, string> CreateAccount(User newUser)
    {
      List<User> userList = mcUserProvider.GetUsers();
      bool bValidUsername = true;
      string message = "";
      if (string.IsNullOrWhiteSpace(newUser.mPassword) || string.IsNullOrWhiteSpace(newUser.mUsername))
      {
        bValidUsername = false;
        message = "Invalid Username or Password";
      }
      else
      {
        foreach (var user in userList)
        {
          if (user.mUsername == newUser.mUsername)
          {
            bValidUsername = false;
            message = "Username already being used";
          }
        }
      }

      if (bValidUsername)
      {
        userList.Add(newUser);
        message = "User created";
      }
      return new Tuple<bool, string>(bValidUsername, message);
    }

    /// <summary>
    /// Uses id as an index to get an account
    /// </summary>
    /// <param name="id">Unique id for user</param>
    /// <param name="userList">List of active users</param>
    /// <returns>User object if it exist, if not, then User will be null</returns>
    private User GetAccount(int id)
    {
      List<User> userList = mcUserProvider.GetUsers();
      User requestedAccount = null;
      if (userList.ElementAtOrDefault(id) != null)
      {
        requestedAccount = userList[id];
      }
      return requestedAccount;
    }

    /// <summary>
    /// Finds a user 
    /// </summary>
    /// <param name="user">User trying to find</param>
    /// <param name="userList">List of active users</param>
    /// <returns>Valid user id or -1 if none exist</returns>
    private int FindUser(User user)
    {
      List<User> userList = mcUserProvider.GetUsers();
      int userId = -1;
        for (int i = 0; i < userList.Count; i++)
        {
        if (userList[i].mUsername == user.mUsername &&
          userList[i].mPassword == user.mPassword)
        {
          userId = i;
          i = userList.Count;
        }
      }
      return userId;
    }
  }
}
