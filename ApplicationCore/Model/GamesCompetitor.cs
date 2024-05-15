using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class GamesCompetitor
    {
        public int id { get; set; }
        public int games_id { get; set; }
        public int person_id { get; set; }
        public int age { get; set; }

        [JsonIgnore]
        /*[IgnoreDataMember]*/
        public ICollection<Medal> medals { get; set; }

        public Games games { get; set; }

        public Person person { get; set; }

    }
}
