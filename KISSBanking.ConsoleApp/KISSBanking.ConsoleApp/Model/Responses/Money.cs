namespace KISSBanking.ConsoleApp.Models.Responses
{
  /// <summary>
  /// Class that represents a money object
  /// </summary>
  public class Money
  {
    public decimal mBalance;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="balance"></param>
    public Money(decimal balance)
    {
      mBalance = balance;
    }

    /// <summary>
    /// Overloaded operator to handle adding Money objects
    /// </summary>
    /// <param name="current">Current Money object</param>
    /// <param name="deposit">New Deposit Money object</param>
    /// <returns>New Money object that represents the addition of the two parameters</returns>
    public static Money operator +(Money current, Money deposit)
    {
      return new Money(current.mBalance + deposit.mBalance);
    }

    /// <summary>
    /// Overloaded operator to handle adding Money objects
    /// </summary>
    /// <param name="current">Current Money object</param>
    /// <param name="withdraw">New Withdraw Money object</param>
    /// <returns>New Money object that represents the subtraction of the two parameters</returns>
    public static Money operator -(Money current, Money withdraw)
    {
      return new Money(current.mBalance - withdraw.mBalance);
    }

    /// <summary>
    /// Overloaded operator to handle comparing Money objects
    /// </summary>
    /// <param name="current">Current Money object</param>
    /// <param name="comparator">Money object that the Current Money object if being compared too</param>
    /// <returns>Whether current money object is less then the comparator Money object </returns>
    public static bool operator <(Money current, Money comparator)
    {
      return current.mBalance < comparator.mBalance;
    }

    /// <summary>
    /// Overloaded operator to handle comparing Money objects
    /// </summary>
    /// <param name="current">Current Money object</param>
    /// <param name="comparator">Money object that the Current Money object if being compared too</param>
    /// <returns>Whether current money object is less then the comparator Money object </returns>
    public static bool operator >(Money current, Money comparator)
    {
      return current.mBalance > comparator.mBalance;
    }
  }
}
