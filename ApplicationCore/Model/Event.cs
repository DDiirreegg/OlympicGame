using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class Event
    {
        public int id { get; set; }
        public int sport_id { get; set; }
        public string event_name { get; set; }
        public Sport sport { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Medal> medals { get; set; }
    }
}
