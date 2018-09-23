using System;
using System.Threading.Tasks;
using KISSBanking.ConsoleApp.Models.Responses;
using KISSBanking.ConsoleApp.View.Interfaces;
using KISSBanking.ConsoleApp.Presenter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KISSBanking.ConsoleApp.Services;
using System.Linq;

namespace KISSBanking.ConsoleApp.Test
{
  [TestClass]
  public class ConsoleAppTest : IView
  {
    public event Func<string, string, Task<Tuple<bool, string>>> LoginEventRaised;
    public event Func<string, string, string, Task<Tuple<bool, string>>> SignupEventRaised;
    public event Func<Transaction, Task<bool>> TransactionEventRaised;
    public event Func<Task<Account>> GetAccountEventRaised;
    public event Func<string> GetUsernameEventRaised;
    public event Func<bool> LogoutEventRaised;

    public void Home()
    {

    }

    /// <summary>
    /// Calls REST API to add user
    /// </summary>
    /// <param name="user"></param>
    private void AddUser(string user)
    {
      RESTRequests rest = new RESTRequests();
      var result = rest.Post("/api/User/CreateUser", new User(user, "testPass"));
      result.Wait();
    }

    private static Random random = new Random();
    /// <summary>
    /// Generates random username
    /// </summary>
    /// <param name="length">Length of name</param>
    /// <returns>Random generated username</returns>
    private static string RandomString(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// Runs signup event handler
    /// </summary>
    [TestMethod]
    public void Signup()
    {
      KISSBankingPresenter KISSPresenter = new KISSBankingPresenter(this);
      var signupTest = SignupEventRaised.Invoke(RandomString(5), "testPass", "testPass");
      signupTest.Wait();
      Assert.AreEqual(signupTest.Result.Item1, true);
    }

    /// <summary>
    /// Runs login, get username and logout event handler
    /// </summary>
    [TestMethod]
    public void LoginUsernameSignout()
    {
      KISSBankingPresenter KISSPresenter = new KISSBankingPresenter(this);
      string user = RandomString(5);
      AddUser(user);
      var loginTest = LoginEventRaised.Invoke(user, "testPass");
      loginTest.Wait();
      Assert.AreEqual(loginTest.Result.Item1, true);
      var username = GetUsernameEventRaised.Invoke();
      Assert.AreEqual(username, user);
      var signout = LogoutEventRaised.Invoke();
      Assert.AreEqual(signout, true);
    }

    /// <summary>
    /// Runs login event handler
    /// </summary>
    [TestMethod]
    public void CreateTransaction()
    {
      KISSBankingPresenter KISSPresenter = new KISSBankingPresenter(this);
      string user = RandomString(5);
      AddUser(user);
      var loginTest = LoginEventRaised.Invoke(user, "testPass");
      loginTest.Wait();
      var tranaction = TransactionEventRaised.Invoke(new Transaction
      {
        Amount = new Money(1000),
        TransactionType = Transaction.Type.DEPOSIT,
        UserId = 0
      });
      tranaction.Wait();
      Assert.AreEqual(tranaction.Result, true);
    }
  }
}
