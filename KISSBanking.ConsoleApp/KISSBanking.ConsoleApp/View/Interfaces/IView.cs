using KISSBanking.ConsoleApp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KISSBanking.ConsoleApp.View.Interfaces
{
  /// <summary>
  /// 
  /// </summary>
  public interface IView
  {

    /// <summary>
    /// Starts up the view
    /// </summary>
    void Home();

    /// <summary>
    /// Raises login event
    /// </summary>
    event Func<string, string, Task<Tuple<bool, string>>> LoginEventRaised;

    /// <summary>
    /// Raises signup event
    /// </summary>
    event Func<string, string, string, Task<Tuple<bool, string>>> SignupEventRaised;

    /// <summary>
    /// Raises transaction event
    /// </summary>
    event Func<Transaction, Task<bool>> TransactionEventRaised;

    /// <summary>
    /// Raises get account event
    /// </summary>
    event Func<Task<Account>> GetAccountEventRaised;

    /// <summary>
    /// Rases get username event
    /// </summary>
    event Func<string> GetUsernameEventRaised;

    /// <summary>
    /// Raises logout event
    /// </summary>
    event Func<bool> LogoutEventRaised;
  }
}
