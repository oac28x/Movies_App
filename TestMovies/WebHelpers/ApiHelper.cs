using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestMovies.Models;
using TestMovies.Services;

namespace TestMovies.WebHelpers
{
    public class ApiHelper : ApiClient, IApiHelperService
    {
        //const string BASE_URL = "http://api.themoviedb.org/3{0}?api_key={1}&{2}";
        public ApiHelper()
        {

        }

        public async Task<PoularMoviesModel> GetPopularMovies(string lang, int page)
        {
            string config = $"language={lang}&page={page}";
            string rawResponse = await SendRequest("/movie/popular", config, "GET");
            return JsonConvert.DeserializeObject<PoularMoviesModel>(rawResponse);  
        }

        //Need to map model or could return JObject
        public async Task<object> GetMovieDetails(string movieId, string lang)
        {
            string config = $"language={lang}";
            string rawResponse = await SendRequest($"/movie/{movieId}", config, "GET");
            return JsonConvert.DeserializeObject<object>(rawResponse);
        }

        public async Task<VideosModel> GetTrailers(int movieId, string lang)
        {
            string config = $"language={lang}";
            string rawResponse = await SendRequest($"/movie/{movieId}/videos", config, "GET");
            return JsonConvert.DeserializeObject<VideosModel>(rawResponse);
        }
    }
}
