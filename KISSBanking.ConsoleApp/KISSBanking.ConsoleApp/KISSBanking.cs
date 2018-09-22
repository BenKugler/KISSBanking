using KISSBanking.ConsoleApp.Presenter;
using KISSBanking.ConsoleApp.View;

namespace KISSBanking.ConsoleApp
{
  class KISSBanking
  {
    /// <summary>
    /// Creates the view and passes it to the presenter
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      KISSBankingView KISSView = new KISSBankingView();
      KISSBankingPresenter KISSPresenter = new KISSBankingPresenter(KISSView);
      KISSView.Home();
    }
  }
}
