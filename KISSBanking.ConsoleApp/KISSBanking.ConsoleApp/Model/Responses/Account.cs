using System.Collections.Generic;

namespace KISSBanking.ConsoleApp.Models.Responses
{
  /// <summary>
  /// Clas represents a users account
  /// </summary>
  public class Account
  {
    public Money mcAccountBalance;
    public List<Transaction> mcTransactions;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="newBalance">New balance amount, defaults to 0</param>
    public Account(decimal newBalance = 0)
    {
      mcAccountBalance = new Money(newBalance);
      mcTransactions = new List<Transaction>();
    }

    /// <summary>
    /// Makes a transaction, either a Withdraw or deposit
    /// </summary>
    /// <param name="newTransaction">Transaction being made on the current account</param>
    /// <returns>Whether the transaction was successful or not</returns>
    public bool MakeTransaction(Transaction newTransaction)
    {
      bool bValidTransaction = true;
      if (newTransaction.TransactionType == Transaction.Type.WITHDRAW)
      {
        if (newTransaction.Amount > mcAccountBalance)
        {
          bValidTransaction = false;
        }
        else
        {
          WithDraw(newTransaction);
        }
      }
      else
      {
        Deposit(newTransaction);
      }

      if (bValidTransaction)
      {
        mcTransactions.Add(newTransaction);
      }

      return bValidTransaction;
    }

    /// <summary>
    /// Commits a deposit
    /// </summary>
    /// <param name="deposit">Deposit transaction</param>
    private void Deposit(Transaction deposit)
    {
      mcAccountBalance += deposit.Amount;
    }

    /// <summary>
    /// Commits a withdraw
    /// </summary>
    /// <param name="withdraw">Widthdraw transaction</param>
    private void WithDraw(Transaction withdraw)
    {
      mcAccountBalance -= withdraw.Amount;
    }
  }
}
