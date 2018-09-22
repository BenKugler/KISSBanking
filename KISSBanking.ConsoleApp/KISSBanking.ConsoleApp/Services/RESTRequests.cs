using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KISSBanking.ConsoleApp.Services
{
  /// <summary>
  /// Handles request to REST API
  /// These functions where used in a previous project I used, 
  /// only returns had to be changed
  /// </summary>
  class RESTRequests
  {
    HttpClient mClient;
    UriBuilder mRestService;

    /// <summary>
    /// Default constructor
    /// </summary>
    public RESTRequests()
    {
      string baseURL = "http://localhost:5000/";
      mRestService = new UriBuilder(string.Format(baseURL, string.Empty));
      mClient = new HttpClient
      {
        MaxResponseContentBufferSize = 256000
      };

    }

    /// <summary>
    /// Generic Post request
    /// </summary>
    /// <typeparam name="T">Post request type</typeparam>
    /// <param name="path">Controller path</param>
    /// <param name="requestType">Object to be serialized</param>
    /// <returns>Task with tuple containing boolean result and message</returns>
    public async Task<Tuple<bool, string>> Post<T>(string path, T requestType)
    {
      string requestURL;
      string message = null;
      bool bResult = false;
      HttpResponseMessage response = null;

      mRestService.Path = path;
      requestURL = mRestService.ToString();

      using (var httpClient = new HttpClient())
      {
        try
        {
          response = await mClient.PostAsync(
          requestURL,
          new StringContent(
            JsonConvert.SerializeObject(requestType),
            Encoding.UTF8,
            "application/json")
            );
        }
        catch (Exception)
        {
          response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
          {
            Content = new StringContent(
              "Sorry, KISS Banking services are not running right now!"
              )
          };
        }
      }

      if (response.IsSuccessStatusCode)
      {
        bResult = true;
      }

      message = response.Content.ReadAsStringAsync().Result;


      return new Tuple<bool, string>(bResult, message);
    }

    /// <summary>
    /// Generic Get Request
    /// </summary>
    /// <typeparam name="T">Get request type</typeparam>
    /// <param name="path">Controller path</param>
    /// <returns>Task with response</returns>
    public async Task<T> Get<T>(string path)
    {
      string requestURL;
      T getResponse = default(T);

      mRestService.Path = path;

      requestURL = mRestService.ToString();

      HttpResponseMessage response = await mClient.GetAsync(requestURL);

      if (response.IsSuccessStatusCode)
      {
        string responseJson = response.Content.ReadAsStringAsync().Result;
        getResponse = JsonConvert.DeserializeObject<T>(responseJson);
      }

      return getResponse;

    }
  }
}
