using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class Medal
    {
        public int id { get; set; }
        public string medal_name { get; set; }
       
        public ICollection<Event> events { get; set; }
        public ICollection<GamesCompetitor> gamesCompetitors { get; set; }
    }
}
