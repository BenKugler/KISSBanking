using Microsoft.AspNetCore.Mvc;
using KISSBanking.API.Providers;
using KISSBanking.API.Models;
using System.Linq;
using System.Net;

namespace KISSBanking.API.Controllers
{
  /// <summary>
  /// Controller routes for User operations
  /// </summary>
  [Route("api/[controller]")]
  public class TransactionController : Controller
  {
    private readonly IUserProvider mcUserProvider;

    /// <summary>
    /// Default constructor to create the User Provider
    /// </summary>
    /// <param name="userProvider">User provider from services</param>
    public TransactionController(IUserProvider userProvider)
    {
      mcUserProvider = userProvider;
    }

    /// <summary>
    /// Using index, gets a user account
    /// </summary>
    /// <param name="userId">Index of user</param>
    /// <returns>Request code, if valid, users account is returned with it</returns>
    [HttpGet("[action]/{userId}")]
    public IActionResult GetAccount(int userId)
    {
      Account userAccount;
      IActionResult resultCode = StatusCode((int)HttpStatusCode.BadRequest);

      if ((userAccount = GetUserAccount(userId)) != null)
      {
        resultCode = StatusCode((int)HttpStatusCode.Accepted, userAccount);
      }

      return resultCode;
    }

    /// <summary>
    /// Creates a new transaction for specified user
    /// </summary>
    /// <param name="newTransaction">New transaction information</param>
    /// <returns>Request code</returns>
    [HttpPost("[action]")]
    public IActionResult CreateTransaction([FromBody]Transaction newTransaction)
    {
      Account userAccount;
      IActionResult resultCode = StatusCode((int)HttpStatusCode.BadRequest);

      if ((userAccount = GetUserAccount(newTransaction.UserId)) != null)
      {
        if (userAccount.MakeTransaction(newTransaction))
        {
          resultCode = StatusCode((int)HttpStatusCode.Accepted);
        }
      }

      return resultCode;
    }

    /// <summary>
    /// Gets a valid Account if UserId is within the range of avalible users
    /// </summary>
    /// <param name="UserId">Current user ID</param>
    /// <returns>USer account</returns>
    private Account GetUserAccount(int UserId)
    {
      Account userAccount = null;
      if (UserId < mcUserProvider.GetUsers().Count)
      {
        userAccount = mcUserProvider.GetUsers().ElementAt(UserId).GetUserAccount();
      }
      return userAccount;
    }
  }
}
