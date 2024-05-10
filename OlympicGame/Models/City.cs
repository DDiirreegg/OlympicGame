namespace OlympicGame.Models
{
    public class City
    {
        public int id { get; set; }
        public string city_name { get; set; }
        public ICollection<GamesCity> gamesCities { get; set; }
    }
}
