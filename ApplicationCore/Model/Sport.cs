using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class Sport
    {
        public int id { get; set; }
        public string sport_name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Event> events { get; set; }
    }
}
