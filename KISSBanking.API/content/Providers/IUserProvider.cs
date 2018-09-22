using KISSBanking.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSBanking.API.Providers
{
  /// <summary>
  /// Interface of user service provider
  /// </summary>
  public interface IUserProvider
  {
    List<User> GetUsers();
  }
}
