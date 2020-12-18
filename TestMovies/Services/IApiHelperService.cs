using System;
using System.Threading.Tasks;
using TestMovies.Models;

namespace TestMovies.Services
{
    public interface IApiHelperService
    {
        Task<PoularMoviesModel> GetPopularMovies(string lang, int page);
    }
}
