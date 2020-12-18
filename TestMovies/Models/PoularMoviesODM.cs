using System;
using Newtonsoft.Json;
using TestMovies.ViewModels.Base;

namespace TestMovies.Models
{
    public class PoularMoviesModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public MovieModel[] Movies { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }

    public class MovieModel: Observable
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public object OiginalTitle { get; set; }

        [JsonProperty("overview")]
        public object Overview { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackImg { get; set; }

        [JsonProperty("poster_path")]
        public string PosterImg { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("adult")]
        public bool IsAdult { get; set; }

        [JsonProperty("vote_average")]
        public string VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        


        public string PosterImgUrl { get { return $"https://image.tmdb.org/t/p/w500{PosterImg}"; } }
        public decimal PopularityAsDecimal { get { return Convert.ToDecimal(Popularity); } }
        public decimal VoteAverageAsDecimal { get { return Convert.ToDecimal(VoteAverage); } }

        private bool itemSelected = false;
        public bool ItemSelected {
            get => itemSelected;
            set
            {
                itemSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
