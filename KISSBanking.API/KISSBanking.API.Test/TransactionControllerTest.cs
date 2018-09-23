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
  public class TransactionControllerTest
  {
    IUserProvider _UserProvider = new UserProvider(new List<User>
      {
        new User("tempUser", "pass")
      });

    /// <summary>
    /// Test get account route
    /// </summary>
    [TestMethod]
    public void GetAccountTest()
    {
      TransactionController transaction = new TransactionController(_UserProvider);

      ObjectResult result = transaction.GetAccount(0) as ObjectResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
    }

    /// <summary>
    /// Test deposit transaction route
    /// </summary>
    [TestMethod]
    public void CreateDepositTransactionTest()
    {
      TransactionController transaction = new TransactionController(_UserProvider);
      Transaction goodTestTransaction = new Transaction
      {
        Amount = new Money(1000),
        TransactionType = Transaction.Type.DEPOSIT,
        UserId = 0
      };
      StatusCodeResult result = transaction.CreateTransaction(goodTestTransaction) as StatusCodeResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
    }

    /// <summary>
    /// Test withdraw transaction route
    /// </summary>
    [TestMethod]
    public void CreateWithdrawTransactionTest()
    {
      TransactionController transaction = new TransactionController(_UserProvider);

      Transaction depositTransaction = new Transaction
      {
        Amount = new Money(1000),
        TransactionType = Transaction.Type.DEPOSIT,
        UserId = 0
      };

      Transaction goodTestTransaction = new Transaction
      {
        Amount = new Money(1000),
        TransactionType = Transaction.Type.WITHDRAW,
        UserId = 0
      };

      Transaction badTestTransaction = new Transaction
      {
        Amount = new Money(100000),
        TransactionType = Transaction.Type.WITHDRAW,
        UserId = 0
      };
      StatusCodeResult result = transaction.CreateTransaction(depositTransaction) as StatusCodeResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
      result = transaction.CreateTransaction(goodTestTransaction) as StatusCodeResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.Accepted);
      result = transaction.CreateTransaction(badTestTransaction) as StatusCodeResult;
      Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
    }
  }
}
