using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TestMovies.Models;
using TestMovies.Services;
using Xamarin.Essentials;

namespace TestMovies.WebHelpers
{
    public abstract class ApiClient : IDisposable
    {
        const string API_KEY = "Api_key";
        const string BASE_URL = "http://api.themoviedb.org/3{0}?api_key={1}&{2}";

        public ApiClient(){ }

        public void Dispose()
        {
            //Unsuscrive eventsd and finalize objects


            //Call GC
            GC.SuppressFinalize(this);
        }

        public async Task<string> SendRequest(string url, string confing, string method)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available
            }

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(BASE_URL, url, API_KEY, confing));
            httpWebRequest.Method = method;
            httpWebRequest.ContentType = "application/json";

            string response = string.Empty;

            try
            {
                using (WebResponse res = await httpWebRequest.GetResponseAsync())
                {
                    using (Stream strReader = res.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            response = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException wex)
            {
                HttpWebResponse exResponse = (HttpWebResponse)wex.Response;

                switch (exResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.InternalServerError:

                        break;

                    case HttpStatusCode.BadRequest:

                        break;
                    default:
                        break;
                }
                //Do some log and extra actions
#if DEBUG
                System.Diagnostics.Debug.WriteLine(wex.HelpLink);
                System.Diagnostics.Debug.WriteLine(wex.Message);
#else
                ex..
#endif
            }

            return response;
        }
    }
}
