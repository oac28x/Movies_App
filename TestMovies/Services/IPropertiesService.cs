using System;
namespace TestMovies.Services
{
    public interface IPropertiesService
    {
        void AddOrUpdateValue(string id, object data);

        T GetValueOrDefault<T>(string id);

        void DeleteValue(string id);

        void ClearAll();
    }
}
