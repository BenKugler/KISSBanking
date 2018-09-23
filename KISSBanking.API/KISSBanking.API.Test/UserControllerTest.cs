using KISSBanking.API.Controllers;
using KISSBanking.API.Models;
using KISSBanking.API.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;

namespace KISSBanking.API.Test
{
  [TestClass]
  public class UserControllerTest
  {
    /// <summary>
    /// Test create user route
    /// </summary>
    [TestMethod]
    public void CreateUserTest()
    {
      UserController userController = new UserController(new UserProvider());
      User testUser = new User("tempUser", "pass");
      ObjectResult result;

      result = userController.CreateUser(testUser) as ObjectResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
    }

    /// <summary>
    /// Test user login route
    /// </summary>
    [TestMethod]
    public void LoginTest()
    {
      User testUser = new User("tempUser", "pass");
      UserController userController = new UserController(
        new UserProvider(new List<User>
          {
            testUser
          }));

      ObjectResult result;

      result = userController.Login(testUser) as ObjectResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
      Assert.AreEqual(result.Value, 0);
    }
  }
}
