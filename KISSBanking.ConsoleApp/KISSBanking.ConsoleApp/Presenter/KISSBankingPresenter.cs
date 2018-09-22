using KISSBanking.ConsoleApp.Model;
using KISSBanking.ConsoleApp.Models.Responses;
using KISSBanking.ConsoleApp.View.Interfaces;
using System;
using System.Threading.Tasks;

namespace KISSBanking.ConsoleApp.Presenter
{
  /// <summary>
  /// View presenter, communicates between model and view
  /// </summary>
  class KISSBankingPresenter
  {
    private KISSBankingModel mcModel;
    private IView mcInterfaceView;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="view"></param>
    public KISSBankingPresenter(IView view)
    {
      mcModel = new KISSBankingModel();
      mcInterfaceView = view;
      CreateHandlers();
    }

    /// <summary>
    /// Creates event handlers
    /// </summary>
    private void CreateHandlers()
    {
      mcInterfaceView.LoginEventRaised += LoginEventHandler;
      mcInterfaceView.SignupEventRaised += SignupEventHandler;
      mcInterfaceView.TransactionEventRaised += TransactionEventHandler;
      mcInterfaceView.GetAccountEventRaised += GetAccountEventHandler;
      mcInterfaceView.GetUsernameEventRaised += GetUsernameEventHandler;
      mcInterfaceView.LogoutEventRaised += LogoutEventHander;
    }

    /// <summary>
    /// Handles login request
    /// </summary>
    /// <param name="username">User username</param>
    /// <param name="password">User password</param>
    /// <returns>Task with boolean result</returns>
    private Task<Tuple<bool, string>> LoginEventHandler(string username, string password) =>
      mcModel.LoginAsync(username, password);

    /// <summary>
    /// Signup even handler
    /// </summary>
    /// <param name="username">User username</param>
    /// <param name="password">User password</param>
    /// <param name="vertfyPassword">User verify password</param>
    /// <returns>Tuple task with boolean result and error message</returns>
    private Task<Tuple<bool, string>> SignupEventHandler
      (string username, string pass, string vertfyPass) =>
      mcModel.SignupAsync(username, pass, vertfyPass);

    /// <summary>
    /// Transaction event handler
    /// </summary>
    /// <param name="newTransaction">New transaction</param>
    /// <returns>Task with boolean result</returns>
    private Task<bool> TransactionEventHandler(Transaction newTransaction) => 
      mcModel.MakeTransactionAsync(newTransaction);

    /// <summary>
    /// Get account event handler
    /// </summary>
    /// <returns>Task with user account</returns>
    private Task<Account> GetAccountEventHandler() => mcModel.GetAccount();

    /// <summary>
    /// Get username event handler
    /// </summary>
    /// <returns>User username</returns>
    private string GetUsernameEventHandler() => mcModel.GetUsername();

    /// <summary>
    /// Logout event handler
    /// </summary>
    /// <returns>boolean result</returns>
    private bool LogoutEventHander() => mcModel.Logout();
  }
}
