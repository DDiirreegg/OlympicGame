using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models
{
    public class City
    {
        public int id { get; set; }
        public string city_name { get; set; }

        
        public ICollection<Games> games { get; set; }
    }
}
