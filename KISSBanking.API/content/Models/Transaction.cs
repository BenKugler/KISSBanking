using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSBanking.API.Models
{
  /// <summary>
  /// Class that represents a transaction
  /// </summary>
  public class Transaction
  {
    /// <summary>
    /// Enum type representing the two types of account transactions
    /// </summary>
    public enum Type { WITHDRAW, DEPOSIT }

    /// <summary>
    /// Current transaction type
    /// </summary>
    public Type TransactionType { get; set; }

    /// <summary>
    /// Amount that is being transfered
    /// </summary>
    public Money Amount { get; set; }

    /// <summary>
    /// UsedId from the user that is making the transaction
    /// </summary>
    public int UserId { get; set; }
  }
}
