using System;
using Newtonsoft.Json;

namespace TestMovies.Models
{
    public class TrailersModel
    {
        [JsonProperty("id")]
        public int MovieId { get; set; }

        [JsonProperty("results")]
        public MovieModel[] Videos { get; set; }
    }

    public class VideosModel
    {
        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("site")]
        public int Site { get; set; }

        [JsonProperty("key")]
        public int VideoKey { get; set; }

        [JsonProperty("type")]
        public int VideoType { get; set; }
    }
}
