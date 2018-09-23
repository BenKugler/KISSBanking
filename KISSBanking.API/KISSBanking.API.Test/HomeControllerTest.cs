using KISSBanking.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KISSBanking.API.Test
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index()
    {
      HomeController home = new HomeController();
      ViewResult result = home.Index() as ViewResult;
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Error()
    {
      HomeController home = new HomeController();
      ViewResult result = home.Error() as ViewResult;
      Assert.IsNotNull(result);
    }
  }
}
