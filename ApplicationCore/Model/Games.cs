using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class Games
    {
        public int id { get; set; }
        public int games_year { get; set; }
        public string games_name { get; set; }
        public string season { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<GamesCompetitor> gamesCompetitors { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<City> citys { get; set; }


    }
}
