using Microsoft.AspNetCore.Mvc;

namespace KISSBanking.API.Controllers
{
  /// <summary>
  /// Controller to return views and resources
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Standard view
    /// </summary>
    /// <returns>View/Resources</returns>
    public IActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// Error View
    /// </summary>
    /// <returns>View/Error Resources</returns>
    public IActionResult Error()
    {
      return View();
    }
  }
}
