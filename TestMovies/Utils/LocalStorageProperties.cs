using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Settings.Abstractions;
using TestMovies.Services;
using Xamarin.Forms;

namespace TestMovies.Utils
{
    public class LocalStorageProperties : IPropertiesService
    {
        const string FILE_NAME = "Settings";
        private readonly Lazy<ISettings> _settings;

        public LocalStorageProperties(Lazy<ISettings> settings)
        {
            _settings = settings;
        }

        public ISettings AppSettings { get => _settings.Value; }

        public void AddOrUpdateValue(string id, object data)
        {
            AppSettings.AddOrUpdateValue(id, JsonConvert.SerializeObject(data), FILE_NAME);
        }

        public T GetValueOrDefault<T>(string id)
        {
            return JsonConvert.DeserializeObject<T>(AppSettings.GetValueOrDefault(id, string.Empty, FILE_NAME));
        }

        public void DeleteValue(string id)
        {
            Task.Run(() => AppSettings.Remove(id, FILE_NAME));
        }

        public void ClearAll()
        {
            Task.Run(() => AppSettings.Clear(fileName: FILE_NAME));
        }
    }
}
