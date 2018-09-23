using KISSBanking.API.Models;
using KISSBanking.API.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSBanking.API.Providers
{
  /// <summary>
  /// This user provider class is here to represent a database instance, but in cached memory
  /// </summary>
  public class UserProvider : IUserProvider
  {
    private List<User> Users { get; set; }

    /// <summary>
    /// Initlizes the database
    /// </summary>
    public UserProvider(List<User> preMade = null)
    {
      if (preMade == null)
      {
        Users = new List<User>();
      }
      else
      {
        Users = preMade;
      }
    }

    /// <summary>
    /// Acts like a databas eand returns the instance of users
    /// </summary>
    /// <returns>List of active cached users</returns>
    public List<User> GetUsers()
    {
      if (Users == null)
      {
        Users = new List<User>();
      }
      return Users;
    }
  }
}
