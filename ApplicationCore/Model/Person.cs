using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class Person
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<GamesCompetitor> gamesCompetitors { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<NocRegion> nocRegions { get; set; }

    }
}
