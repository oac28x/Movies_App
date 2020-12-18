using System;
using System.Threading.Tasks;

namespace TestMovies.Services
{
    public interface IApiClientService
    {
        string SendRequest(string url, string method);
    }
}
